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

        public Task AdicionarMensagemDeAtualizacao(Entities.Produto produto)
        {
            var payload = ConverterJsonProduto(produto);

            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, QueueAtualizarProduto, null, byteArray);

            return Task.CompletedTask;
        }

        public Task AdicionarMensagemDeCriacao(Entities.Produto produto)
        {
            var payload = ConverterJsonProduto(produto);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, QueueCriarProduto, null, byteArray);

            return Task.CompletedTask;
        }

        public Task AdicionarMensagemRemocao(int idProduto)
        {
            var payload = JsonConvert.SerializeObject(new { IdProduto = idProduto });
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish(string.Empty, QueueRemoverProduto, null, byteArray);

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
