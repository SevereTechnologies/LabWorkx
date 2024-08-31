namespace RequestOrder.Infrastructure.Configurations;

public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.ToTable("Shipper");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                shipperId => shipperId.Value,
                databaseId => ShipperId.Of(databaseId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Website).IsRequired().HasMaxLength(100);
    }
}