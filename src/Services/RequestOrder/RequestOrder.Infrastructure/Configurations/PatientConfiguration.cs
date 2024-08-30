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
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(12);
        builder.Property(x => x.DateOfBirth).IsRequired();

        // Address
        builder.ComplexProperty(x => x.Address, addressBuilder =>
           {
               addressBuilder.Property(x => x.Address1).HasMaxLength(100).IsRequired();
               addressBuilder.Property(x => x.Country).HasMaxLength(50);
               addressBuilder.Property(x => x.State).HasMaxLength(50);
               addressBuilder.Property(x => x.Zip).HasMaxLength(8).IsRequired();
               addressBuilder.Property(x => x.Country).HasMaxLength(35).IsRequired();
           });

        // Insurance
        builder.ComplexProperty(x => x.Insurance, insuranceBuilder =>
        {
            insuranceBuilder.Property(x => x.InsuranceCompany).HasMaxLength(100).IsRequired();
            insuranceBuilder.Property(x => x.InsuranceGroup).HasMaxLength(50).IsRequired();
            insuranceBuilder.Property(x => x.InsurancePolicy).HasMaxLength(50).IsRequired();
        });
    }
}
