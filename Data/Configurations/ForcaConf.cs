using JogoDaForca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JogoDaForca.Data.Configurations;

public class ForcaConf : IEntityTypeConfiguration<Forca>
{
    public void Configure(EntityTypeBuilder<Forca> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn();

        builder.Property(x => x.SecretWord)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Attempts)
            .HasColumnType("INTEGER")
            .IsRequired();

        builder.Property(x => x.Done)
            .HasColumnType("BIT")
            .HasDefaultValue(0);

        builder.HasMany(x => x.DicoveryChars)
            .WithOne(d => d.Forca)
            .HasForeignKey(d=>d.ForcaId);
    }
}
