using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Produto.Repository.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Entities.Produto>
    {
        public void Configure(EntityTypeBuilder<Entities.Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.QuantidadeEstoque).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(1000);

            builder.OwnsMany(
            produto => produto.Imagens,
            ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });

            builder.HasOne(x => x.Categoria).
                 WithMany(c => c.Produtos)
                .HasForeignKey(x => x.IdCategoria)
                .IsRequired();
        }
    }
}
