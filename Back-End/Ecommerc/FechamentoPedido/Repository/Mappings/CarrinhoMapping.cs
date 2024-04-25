using FechamentoPedido.Entities.Carrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FechamentoPedido.Repository.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<CarinhoCompra>
    {
        public void Configure(EntityTypeBuilder<CarinhoCompra> builder)
        {
            builder.Property(x => x.IdCliente).IsRequired();

            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Carinho)
                .HasForeignKey(item => item.IdCarinho);

            builder.Navigation(x => x.Produtos).AutoInclude();
        }
    }
}
