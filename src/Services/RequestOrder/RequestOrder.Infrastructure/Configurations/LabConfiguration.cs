namespace RequestOrder.Infrastructure.Configurations;

public class LabConfiguration : IEntityTypeConfiguration<Lab>
{
    public void Configure(EntityTypeBuilder<Lab> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                labId => labId.Value,
                databaseId => LabId.Of(databaseId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Website).IsRequired().HasMaxLength(100);
    }
}
