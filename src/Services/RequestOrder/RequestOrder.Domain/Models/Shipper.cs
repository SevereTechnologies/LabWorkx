namespace RequestOrder.Domain.Models;

public class Shipper : Aggregate<ShipperId>
{
    public string Name { get; private set; } = default!;
    public string Website { get; private set; } = default!;

    public static Shipper Create(ShipperId id, string name, string website)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(website);

        var shipper = new Shipper
        {
            Id = id,
            Name = name,
            Website = website
        };

        return shipper;
    }
}
