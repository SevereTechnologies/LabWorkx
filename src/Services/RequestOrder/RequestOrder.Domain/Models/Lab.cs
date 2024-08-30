namespace RequestOrder.Domain.Models;

public class Lab : Entity<LabId>
{
    public string Name { get; private set; } = default!;
    public string Website { get; private set; } = default!;

    public static Lab Create(LabId id, string name, string website)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(website);

        var lab = new Lab
        {
            Id = id,
            Name = name,
            Website = website
        };

        return lab;
    }
}
