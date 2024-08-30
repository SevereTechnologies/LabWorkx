namespace RequestOrder.Infrastructure.Configurations;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                providerId => providerId.Value,
                databaseId => ProviderId.Of(databaseId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(12);
    }
}