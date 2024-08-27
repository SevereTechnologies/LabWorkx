using Microsoft.EntityFrameworkCore;
using Partner.GRPC.Models;

namespace Partner.GRPC.Data;

public class PartnerContext : DbContext
{
    public DbSet<Lab> Labs { get; set; } = default!;
    public DbSet<Shipper> Shippers { get; set; } = default!;

    public PartnerContext(DbContextOptions<PartnerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lab>().HasData(
            new Lab { LabId = Guid.NewGuid().ToString(), LabName = "LAB ONE", Manager = "", TaxCode = 999999, Address = "", City = "Miami", State = "FL", Zip = 33154, Country = "", LabType = "Specimen", Phone = "999-888-3333", Email = "", Website = "" },
            new Lab { LabId = Guid.NewGuid().ToString(), LabName = "LAB TWO", Manager = "", TaxCode = 888888, Address = "", City = "Phoenix", State = "AZ", Zip = 85132, Country = "", LabType = "Blood", Phone = "444-222-7777", Email = "", Website = "" });

        modelBuilder.Entity<Shipper>().HasData(
            new Shipper { ShipperId = Guid.NewGuid().ToString(), ShipperName = "FedEx", TrackingLink = "www.fedex.com/tracking/" },
            new Shipper { ShipperId = Guid.NewGuid().ToString(), ShipperName = "USPS", TrackingLink = "www.usps.com/tracking/" },
            new Shipper { ShipperId = Guid.NewGuid().ToString(), ShipperName = "UPS", TrackingLink = "www.ups.com/tracking/" });

        base.OnModelCreating(modelBuilder);
    }
}
