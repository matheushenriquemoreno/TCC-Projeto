using System.Collections.Generic;
using Domain.Entites.Base;

namespace FechamentoPedido.Entities.Carrinho
{
    public class CarinhoCompra : EntityBase
    {
        public List<ItemCarinho> Produtos { get; set; }
        public int IdCliente { get; set; }
        public decimal Valortotal
        {
            get
            {
                return Produtos.Sum(x => x.Valortotal);
            }
        }
    }
}
