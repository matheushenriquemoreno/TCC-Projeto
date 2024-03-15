using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produto.Entities;

namespace Produto.Repository.Mapping
{
    public class ImagemMapping : IEntityTypeConfiguration<Entities.Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
        }
    }
}
