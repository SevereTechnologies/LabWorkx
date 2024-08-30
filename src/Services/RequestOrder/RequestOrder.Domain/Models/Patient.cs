namespace RequestOrder.Domain.Models;

public class Patient : Entity<PatientId>
{
    private const int minAge = 18;

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Phone { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; } = default!;
    public string Gender { get; private set; } = default!;
    public string SSN { get; private set; } = default!;
    public Insurance Insurance { get; private set; } = default!;
    public Address Address { get; private set; } = default!;

    public static Patient Create(PatientId id, string firstName, string lastName, string phone, DateTime dob, string gender, string ssn, Insurance insurance, Address address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);
        ArgumentException.ThrowIfNullOrWhiteSpace(gender);
        ArgumentException.ThrowIfNullOrWhiteSpace(ssn);
        
        int minYear = DateTime.Now.AddYears(-18).Year;
        //ArgumentOutOfRangeException.ThrowIfLessThan(dob.Year, minYear);
        if (dob.Year < minYear)
        {
            throw new ArgumentOutOfRangeException(nameof(dob), $"Patient must be {minAge} years old or older.");
        }

        var patient = new Patient
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            DateOfBirth = dob,
            Gender = gender,
            SSN = ssn,
            Insurance = insurance,
            Address = address
        };

        return patient;
    }
}
