using System.Security.Cryptography.X509Certificates;
using FechamentoPedido.Entities.Carrinho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FechamentoPedido.Repository.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<ProdutoCarinho>
    {
        public void Configure(EntityTypeBuilder<ProdutoCarinho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdProduto).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(200);
            builder.Property(x => x.Nome).HasMaxLength(200);
        }
    }
}
