using System.Collections.Generic;
using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class CarinhoCompra : EntityBase
    {
        public List<ItemCarinho> Produtos { get; set; }
        public int IdCliente { get; set; }

        public void AumentarQuantidadeProduto(int idProduto, int quantidade)
        {
            var item = this.Produtos.FirstOrDefault(x => x.IdProduto == idProduto);

            if(item is null)
            {
                item = new ItemCarinho(idProduto, quantidade);

                this.Produtos.Add(item);
            }
            else
            {
                item.AumentarQuantidade(quantidade);
            }
        }

        public void DiminuirQuantidade(int idProduto, int quantidade)
        {
            var item = this.Produtos.First(x => x.IdProduto == idProduto);

            if (item.Quantidade - quantidade == 0)
            {
                this.Produtos.Remove(item);
            }
            else
            {
                item.DiminuirQuantidade(quantidade);
            }
        }

        public decimal Valortotal
        {
            get
            {
                return Produtos.Sum(x => x.Valortotal);
            }
        }
    }
}
