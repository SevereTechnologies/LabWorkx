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
    public int Zip { get; } = default!;
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; } = default!;
}