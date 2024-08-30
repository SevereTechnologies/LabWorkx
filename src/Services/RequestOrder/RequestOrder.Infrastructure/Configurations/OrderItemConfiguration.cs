namespace RequestOrder.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(
                orderItemId => orderItemId.Value,
                databaseId => OrderItemId.Of(databaseId));

        builder.HasOne<Procedure>()
            .WithMany()
            .HasForeignKey(x => x.ProcedureId);

        builder.Property(x => x.Quantity).IsRequired();

        builder.Property(x => x.Charge).IsRequired();
    }
}
