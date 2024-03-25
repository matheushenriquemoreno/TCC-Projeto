using Quartz;

namespace FechamentoPedido.Jobs
{
    public class GerenciarProdutosCarinhoJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job executado");


            return Task.CompletedTask;
        }
    }
}
