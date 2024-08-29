using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Shipper : Aggregate<ShipperId>
{
    public string Name { get; private set; } = default!;
    public string Website { get; private set; } = default!;

    public static Shipper Create(string name, string website)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(website);

        var shipper = new Shipper
        {
            Name = name,
            Website = website
        };

        return shipper;
    }
}
