namespace RequestOrder.Domain.Models;

public class Provider : Entity<ProviderId>
{
    public string Name { get; set; } = default!;
    public string Phone { get; set; } = default!;

    public static Provider Create(ProviderId id, string name, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        var provider = new Provider
        {
            Id = id,
            Name = name,
            Phone = phone
        };

        return provider;
    }
}
