using JogoDaForca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JogoDaForca.Data.Configurations;

public class DiscoveryCharConf : IEntityTypeConfiguration<DiscoveryChar>
{
    public void Configure(EntityTypeBuilder<DiscoveryChar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn();

        builder.Property(x => x.Character)
            .HasColumnType("CHAR")
            .IsRequired();
    }
}
