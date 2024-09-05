using RequestOrder.Domain.Enums;

namespace RequestOrder.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(orderId => orderId.Value,databaseId => OrderId.Of(databaseId));
        builder.HasOne<Provider>().WithMany().HasForeignKey(x => x.ProviderId).IsRequired();
        builder.HasOne<Technician>().WithMany().HasForeignKey(x => x.TechnicianId).IsRequired();
        builder.HasOne<Patient>().WithMany().HasForeignKey(x => x.PatientId).IsRequired();
        builder.HasOne<Lab>().WithMany().HasForeignKey(x => x.LabId).IsRequired();
        builder.HasOne<Shipper>().WithMany().HasForeignKey(x => x.ShipperId).IsRequired();
        builder.HasMany(x => x.OrderItems).WithOne().HasForeignKey(x => x.OrderId);

        // Address
        builder.ComplexProperty(x => x.Address, addressBuilder =>
        {
            addressBuilder.Property(x => x.Address1).HasColumnName("Address1").HasMaxLength(100).IsRequired();
            addressBuilder.Property(x => x.Address2).HasColumnName("Address2");
            addressBuilder.Property(x => x.Country).HasColumnName("Country").HasMaxLength(50);
            addressBuilder.Property(x => x.State).HasColumnName("State").HasMaxLength(50);
            addressBuilder.Property(x => x.Zip).HasColumnName("Zip").HasMaxLength(8).IsRequired();
            addressBuilder.Property(x => x.Country).HasColumnName("Country").HasMaxLength(35).IsRequired();
        });

        // Insurance
        builder.ComplexProperty(x => x.Insurance, insuranceBuilder =>
        {
            insuranceBuilder.Property(x => x.InsuranceCompany).HasColumnName("InsuranceCompany").HasMaxLength(100).IsRequired();
            insuranceBuilder.Property(x => x.InsuranceGroup).HasColumnName("InsuranceGroup").HasMaxLength(50).IsRequired();
            insuranceBuilder.Property(x => x.InsurancePolicy).HasColumnName("InsurancePolicy").HasMaxLength(50).IsRequired();
        });

        // Payment
        builder.ComplexProperty(x => x.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(x => x.LabPaidAmount).HasColumnName("LabPaidAmount");
            paymentBuilder.Property(x => x.LabPaidDate).HasColumnName("LabPaidDate");
            paymentBuilder.Property(x => x.MedicaidPaidAmount).HasColumnName("MedicaidPaidAmount");
            paymentBuilder.Property(x => x.MedicaidPaidDate).HasColumnName("MedicaidPaidDate");
            paymentBuilder.Property(x => x.MedicarePaidAmount).HasColumnName("MedicarePaidAmount");
            paymentBuilder.Property(x => x.MedicarePaidDate).HasColumnName("MedicarePaidDate");
            paymentBuilder.Property(x => x.OtherPaidAmount).HasColumnName("OtherPaidAmount");
            paymentBuilder.Property(x => x.OtherPaidDate).HasColumnName("OtherPaidDate");
        });

        // OrderNumber
        builder.ComplexProperty(o => o.OrderNumber, numberBuilder =>
            {
                numberBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderNumber))
                    .HasMaxLength(100)
                    .IsRequired();
            });

        // OrderStatus
        builder.Property(x => x.Status)
            .HasDefaultValue(OrderStatus.Received)
            .HasConversion(
                x => x.ToString(),
                databaseStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), databaseStatus));

        builder.Property(x => x.TotalCost);
    }
}
