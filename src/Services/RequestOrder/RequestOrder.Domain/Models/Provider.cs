using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Provider : Entity<ProviderId>
{
    public string Name { get; set; } = default!;
    public string Manager { get; set; } = default!;
    public string Phone { get; set; } = default!;

    public static Provider Create(string name, string manager, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        var provider = new Provider
        {
            Name = name,
            Manager = manager,
            Phone = phone
        };

        return provider;
    }
}
