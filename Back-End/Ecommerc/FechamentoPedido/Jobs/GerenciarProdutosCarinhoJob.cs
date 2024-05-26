using FechamentoPedido.DTOS.Integracao;
using FechamentoPedido.Entities.Carrinho;
using FechamentoPedido.Repository.Interfaces;
using FechamentoPedido.Services.Interfaces;
using Newtonsoft.Json;
using Quartz;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace FechamentoPedido.Jobs
{
    public class GerenciarProdutosCarinhoJob : IJob
    {
        private readonly IConnection _connection;
        private readonly RabbitMQ.Client.IModel _channel;
        private const string QueueCriarProduto = "Criacao-Produto";
        private const string QueueAtualizarProduto = "Atualizacao-Produto";
        private const string QueueRemoverProduto = "Remover-Produto";
        private readonly IRepositoryProdutoCarinho repositoryProdutoCarinho;

        public GerenciarProdutosCarinhoJob(IRepositoryProdutoCarinho repositoryProdutoCarinho)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };

            _connection = connectionFactory.CreateConnection("publisher-Ecommerc-Produto");

            _channel = _connection.CreateModel();
            this.repositoryProdutoCarinho = repositoryProdutoCarinho;
        }

        public Task GerenciarProdutosAtualizados()
        {
            var consumer = new EventingBasicConsumer(_channel);

            ProdutoCarinho produtoBase = repositoryProdutoCarinho.ObterOnde(x => x.IdProduto == 1036).Result;

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var produtoJson = Encoding.UTF8.GetString(body);
                
                ProdutoIntegracaoDTO produtoIntegracao = ConverterJsonProduto(produtoJson);

                ProdutoCarinho produtoBase = await repositoryProdutoCarinho.ObterOnde(x => x.IdProduto == produtoIntegracao.Id);

                if (produtoBase is null)
                {
                    await AdicionarProduto(produtoIntegracao);
                    return;
                }

                produtoBase.Preco = produtoIntegracao.Preco;
                produtoBase.Descricao = produtoIntegracao.Descricao;
                produtoBase.QuantidadeEstoque = produtoIntegracao.QuantidadeEstoque;
                produtoBase.Nome = produtoIntegracao.Nome;

                await repositoryProdutoCarinho.Atualizar(produtoBase);

                Console.WriteLine("Atualização finalizada para o produto: " + produtoIntegracao.Nome);
                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: QueueAtualizarProduto,
                        autoAck: false,
                        consumer: consumer);

            return Task.CompletedTask;
        }

        private async Task AdicionarProduto(ProdutoIntegracaoDTO produtoIntegracao)
        {
            var produtoBase = new ProdutoCarinho()
            {
                Descricao = produtoIntegracao.Descricao,
                IdProduto = produtoIntegracao.Id,
                Nome = produtoIntegracao.Nome,
                Preco = produtoIntegracao.Preco,
                QuantidadeEstoque = produtoIntegracao.QuantidadeEstoque,
                UrlImagePrincipal = produtoIntegracao.Imagens.First().Url
            };

            await repositoryProdutoCarinho.Adicionar(produtoBase);

            Console.WriteLine("Inserção finalizada para o produto: " + produtoIntegracao.Nome);
        }

        private ProdutoIntegracaoDTO ConverterJsonProduto(string produto)
        {
            return JsonConvert.DeserializeObject<ProdutoIntegracaoDTO>(produto);
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job Gerenciar Produtos Executando: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

            await Task.WhenAll(this.GerenciarProdutosAtualizados());
        }
    }
}
