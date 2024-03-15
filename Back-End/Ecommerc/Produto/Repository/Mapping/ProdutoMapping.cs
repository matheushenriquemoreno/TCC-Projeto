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
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(1000);

            builder.Navigation(x => x.Imagens).AutoInclude();

            builder.HasMany(p => p.Imagens)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto);

            builder.HasOne(x => x.Categoria).
                 WithMany(c => c.Produtos)
                .HasForeignKey(x => x.IdCategoria)
                .IsRequired();
        }
    }
}
