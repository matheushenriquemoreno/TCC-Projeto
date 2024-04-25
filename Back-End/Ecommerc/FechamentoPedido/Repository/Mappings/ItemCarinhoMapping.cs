using FechamentoPedido.Entities.Carrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FechamentoPedido.Repository.Mappings
{
    public class ItemCarinhoMapping : IEntityTypeConfiguration<ItemCarinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarinho> builder)
        {
            builder.HasOne(x => x.Produto)
                .WithMany(produto => produto.Itens)
                .HasForeignKey(x => x.IdProdutoCarinho);

            builder.Navigation(x => x.Produto).AutoInclude();
        }
    }
}
