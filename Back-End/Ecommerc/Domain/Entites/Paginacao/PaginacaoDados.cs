namespace Domain.Entites.Paginacao;

public class PaginacaoDados<T>
{
    public IEnumerable<T> DadosPaginados { get; set; }
    public int QuantidadePaginas { get; set; }
    public int QuantidadeRegistros { get; set; }

    public PaginacaoDados(IEnumerable<T> dadosPaginados, int quantidadePaginas, int quantidadeRegistros)
    {
        DadosPaginados = dadosPaginados;
        QuantidadePaginas = quantidadePaginas;
        QuantidadeRegistros = quantidadeRegistros;
    }
}
