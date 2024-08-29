namespace RequestOrder.Domain.Models;

public class Technician : Entity<TechnicianId>
{
    public string Name { get; private set; } = default!;
    public string Phone { get; private set; } = default!;

    public static Technician Create(string name, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        var technician = new Technician
        {
            Name = name,
            Phone = phone
        };

        return technician;
    }
}
