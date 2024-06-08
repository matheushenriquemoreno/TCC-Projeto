using Newtonsoft.Json;
using System.Text;
using Produto.Services.Interfaces;
using RabbitMQ.Client;

namespace Produto.Services.Implementacoes
{
    public class ServiceFilaProduto : IServiceFilaProduto
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string QueueCriarProduto = "Criacao-Produto";
        private const string QueueAtualizarProduto = "Atualizacao-Produto";
        private const string QueueRemoverProduto = "Remover-Produto";

        public ServiceFilaProduto()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            };

            _connection = connectionFactory.CreateConnection("publisher-Ecommerc-Produto");

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: QueueCriarProduto,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

            _channel.QueueDeclare(queue: QueueAtualizarProduto,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

            _channel.QueueDeclare(queue: QueueRemoverProduto,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
        }

        public Task AdicionarProdutoAtualizadoNaFila(Entities.Produto produto)
        {
            var payload = ConverterJsonProduto(produto);

            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, QueueAtualizarProduto, null, byteArray);

            return Task.CompletedTask;
        }

        public Task AdicionarProdutoCriadoNaFila(Entities.Produto produto)
        {
            var produtoJson = JsonConvert.SerializeObject(produto, Formatting.Indented);

            var byteArray = Encoding.UTF8.GetBytes(produtoJson);

            _channel.BasicPublish(string.Empty, "Produto-Criado", null, byteArray);

            return Task.CompletedTask;
        }

        public Task AdicionarProdutoRemovidoFila(int idProduto)
        {
            var payload = JsonConvert.SerializeObject(new { IdProduto = idProduto });
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, "Criacao-Produto", null, byteArray);

            return Task.CompletedTask;
        }

        private string ConverterJsonProduto(Entities.Produto produto)
        {
            return JsonConvert.SerializeObject(produto, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
    }
}
