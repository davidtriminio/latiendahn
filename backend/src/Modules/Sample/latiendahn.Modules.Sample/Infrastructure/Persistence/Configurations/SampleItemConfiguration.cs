using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using latiendahn.Modules.Sample.Domain;

namespace latiendahn.Modules.Sample.Infrastructure.Persistence.Configurations;

internal sealed class SampleItemConfiguration : IEntityTypeConfiguration<SampleItem>
{
    public void Configure(EntityTypeBuilder<SampleItem> builder)
    {
        builder.ToTable("samples");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Description).HasMaxLength(2000);
        builder.Property(x => x.CreatedOn);
        builder.Ignore(x => x.DomainEvents);
    }
}