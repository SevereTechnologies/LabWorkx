namespace Partner.GRPC.Models;

/// <summary>
/// The lab.
/// </summary>
public class Lab
{
    /// <summary>
    /// Gets or sets the lab id.
    /// </summary>
    public string LabId { get; set; } = Guid.NewGuid().ToString();
    /// <summary>
    /// Gets or sets the lab name.
    /// </summary>
    public string LabName { get; set; } = default!;
    /// <summary>
    /// Gets or sets the lab type.
    /// </summary>
    public string LabType { get; set; } = default!;
    /// <summary>
    /// Gets or sets the tax code.
    /// </summary>
    public int TaxCode { get; set; } = default!;
    /// <summary>
    /// Gets or sets the manager.
    /// </summary>
    public string Manager { get; set; } = default!;
    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    public string Address { get; set; } = default!;
    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; } = default!;
    /// <summary>
    /// Gets or sets the state.
    /// </summary>
    public string State { get; set; } = default!;
    /// <summary>
    /// Gets or sets the zip.
    /// </summary>
    public int Zip { get; set; } = default!;
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    public string Country { get; set; } = default!;
    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    public string Phone { get; set; } = default!;
    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    public string Email { get; set; } = default!;
    /// <summary>
    /// Gets or sets the website.
    /// </summary>
    public string Website { get; set; } = default!;
}