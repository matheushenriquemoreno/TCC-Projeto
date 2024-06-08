using System.Collections.Generic;
using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class CarinhoCompra : EntityBase
    {
        public List<ItemCarinho> Produtos { get; set; }
        public int IdCliente { get; set; }

        public void AumentarQuantidadeProduto(int idProdutoCarinho, int quantidade)
        {
            var item = this.Produtos.FirstOrDefault(x => x.IdProdutoCarinho == idProdutoCarinho);

            if(item is null)
            {
                item = new ItemCarinho(idProdutoCarinho, quantidade);

                this.Produtos.Add(item);
            }
            else
            {
                item.AumentarQuantidade(quantidade);
            }
        }

        public void DiminuirQuantidade(int idProduto, int quantidade)
        {
            var item = this.Produtos.First(x => x.IdProdutoCarinho == idProduto);

            if (item.Quantidade - quantidade == 0)
            {
                this.Produtos.Remove(item);
            }
            else
            {
                item.DiminuirQuantidade(quantidade);
            }
        }

        public void RemoverProduto(int idProduto)
        {
            var produtoRemover = this.Produtos.FirstOrDefault(x => x.IdProdutoCarinho == idProduto);
           
            Produtos.Remove(produtoRemover);
        }

        public decimal ValorTotal
        {
            get
            {
                return Produtos.Sum(x => x.Valortotal);
            }
        }
    }
}
