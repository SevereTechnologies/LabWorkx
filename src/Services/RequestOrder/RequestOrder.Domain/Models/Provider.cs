using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Provider : Entity<ProviderId>
{
    public string ProviderName { get; set; } = default!;
    public string Manager { get; set; } = default!;
    public Address Address { get; set; } = default!;
}
