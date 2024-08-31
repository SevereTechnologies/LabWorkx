namespace RequestOrder.Infrastructure.Configurations;

internal class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
{
    public void Configure(EntityTypeBuilder<Technician> builder)
    {
        builder.ToTable("Technician");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                technicianId => technicianId.Value,
                databaseId => TechnicianId.Of(databaseId));

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(12);
    }
}
