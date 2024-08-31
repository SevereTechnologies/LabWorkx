using RequestOrder.Domain.Enums;

namespace RequestOrder.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
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

        // Payment
        builder.ComplexProperty(x => x.Payment, paymentBuilder =>
               {
                   paymentBuilder.Property(x => x.LabPaidAmount);
                   paymentBuilder.Property(x => x.LabPaidDate);
                   paymentBuilder.Property(x => x.MedicaidPaidAmount);
                   paymentBuilder.Property(x => x.MedicaidPaidDate);
                   paymentBuilder.Property(x => x.MedicarePaidAmount);
                   paymentBuilder.Property(x => x.MedicarePaidDate);
                   paymentBuilder.Property(x => x.OtherPaidAmount);
                   paymentBuilder.Property(x => x.OtherPaidDate);
               });

        // OrderNumber
        builder.ComplexProperty(
            o => o.OrderNumber, numberBuilder =>
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
