namespace RequestOrder.Infrastructure.Configurations;

public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
{
    public void Configure(EntityTypeBuilder<Procedure> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                procedureId => procedureId.Value,
                databaseId => ProcedureId.Of(databaseId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Specimen).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CPT).IsRequired().HasMaxLength(20);
    }
}
