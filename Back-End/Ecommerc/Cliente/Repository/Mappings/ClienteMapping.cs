using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cliente.Repository.Maping
{
    public class ClienteMapping : IEntityTypeConfiguration<Entities.Cliente>
    {
        public void Configure(EntityTypeBuilder<Entities.Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(1500);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(1200);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);

                    builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Entities.Cliente>(x => x.IdEndereco).IsRequired(false);
        }
    }
}
