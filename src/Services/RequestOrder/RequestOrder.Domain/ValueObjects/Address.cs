namespace RequestOrder.Domain.ValueObjects;

public record Address
{
    /// <summary>
    /// Gets or sets the address1.
    /// </summary>
    public string Address1 { get; } = default!;
    /// <summary>
    /// Gets or sets the address2.
    /// </summary>
    public string? Address2 { get; } = default!;
    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; } = default!;
    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    public string State { get; } = default!;
    /// <summary>
    /// Gets or sets the zip.
    /// </summary>
    public string Zip { get; } = default!;
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; } = default!;

    private Address()
    {
    }

    private Address(string address1, string address2, string city, string state, string zip, string country)
    {
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
    }

    public static Address Of(string address1, string address2, string city, string state, string zip, string country)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(address1);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(zip);
        ArgumentOutOfRangeException.ThrowIfLessThan(zip.Length, 5);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(zip.Length, 8);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);

        return new Address(address1, address2, city, state, zip, country);
    }
}