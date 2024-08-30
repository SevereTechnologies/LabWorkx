namespace RequestOrder.Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(x => x.Id);

        // convert PatientId strongTypeId valueobject to database ID
        builder.Property(x => x.Id).HasConversion(
                patientId => patientId.Value,
                databaseId => PatientId.Of(databaseId));

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.SSN).IsRequired().HasMaxLength(12);
    }
}
