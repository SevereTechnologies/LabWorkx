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

        // Payment
        builder.ComplexProperty(x => x.Payment, paymentBuilder =>
               {
                   paymentBuilder.Property(x => x.CardName).HasMaxLength(50);
                   paymentBuilder.Property(x => x.CardNumber).HasMaxLength(24).IsRequired();
                   paymentBuilder.Property(x => x.Expiration).HasMaxLength(10);
                   paymentBuilder.Property(x => x.CVV).HasMaxLength(3);
                   paymentBuilder.Property(x => x.PaymentMethod);
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

        builder.Property(x => x.ChargeAmount);
    }
}
