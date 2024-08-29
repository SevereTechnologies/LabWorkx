namespace RequestOrder.Domain.Models;

public class Lab : Entity<LabId>
{
    public string Name { get; private set; } = default!;
    public string Website { get; private set; } = default!;

    public static Lab Create(string name, string website)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(website);

        var lab = new Lab
        {
            Name = name,
            Website = website
        };

        return lab;
    }
}
