namespace RequestOrder.Domain.Models;

public class Technician : Entity<TechnicianId>
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Phone { get; private set; } = default!;

    public static Technician Create(TechnicianId id, string firstName, string lastName, string phone)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);

        var technician = new Technician
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone
        };

        return technician;
    }
}
