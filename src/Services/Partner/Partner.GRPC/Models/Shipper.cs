namespace Partner.GRPC.Models;

/// <summary>
/// The shipper.
/// </summary>
public class Shipper
{
    /// <summary>
    /// Gets or sets the shipper id.
    /// </summary>
    public Guid ShipperId { get; set; }
    /// <summary>
    /// Gets or sets the shipper name.
    /// </summary>
    public string ShipperName { get; set; } = default!;
    /// <summary>
    /// Gets or sets the tracking link.
    /// </summary>
    public string TrackingLink { get; set; } = default!;
}