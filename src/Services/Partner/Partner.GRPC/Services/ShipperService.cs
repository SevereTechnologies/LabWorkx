using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Partner.GRPC.Data;
using Partner.GRPC.Models;

namespace Partner.GRPC.Services;

public class ShipperService(PartnerContext dbcontext, ILogger<ShipperService> logger) : ShipperProtoServie.ShipperProtoServieBase
{
    public override async Task<ShipperResponse> GetShipper(GetShipperRequest request, ServerCallContext context)
    {
        var shipper = await dbcontext
            .Shippers
            .FirstOrDefaultAsync(x => x.ShipperId == new Guid(request.ShipperId));

        if (shipper == null)
        {
            shipper = new Models.Shipper { ShipperId = new Guid(), ShipperName = "No Shipper", TrackingLink = "None" };
        }

        // log info
        logger.LogInformation("Shipper retrieved : ID: {ShipperId}, NAME: {ShipperName}", shipper.ShipperId.ToString(), shipper.ShipperName);

        //convert to ShipperResponse to return
        var response = shipper.Adapt<ShipperResponse>();

        //return response
        return response;
    }

    public override async Task<ShipperResponse> CreateShipper(CreateShipperRequest request, ServerCallContext context)
    {
        var shipper = request.Shipper.Adapt<Shipper>();
        if (shipper is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbcontext.Shippers.Add(shipper);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Shipper is successfully created. : ID: {ShipperId}, NAME: {ShipperName}", shipper.ShipperId.ToString(), shipper.ShipperName);

        // mapp back to response object to return it
        var response = shipper.Adapt<ShipperResponse>();
        return response;
    }

    public override async Task<ShipperResponse> UpdateShipper(UpdateShipperRequest request, ServerCallContext context)
    {
        var shipper = request.Shipper.Adapt<Shipper>();
        if (shipper is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        dbcontext.Shippers.Update(shipper);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Shipper is successfully updated. ID: {ShipperId}, NAME: {ShipperName}", shipper.ShipperId.ToString(), shipper.ShipperName);

        // mapp back to response object to return it
        var response = shipper.Adapt<ShipperResponse>();
        return response;
    }

    public override async Task<DeleteShipperResponse> DeleteShipper(DeleteShipperRequest request, ServerCallContext context)
    {
        var shipper = await dbcontext
            .Shippers
            .FirstOrDefaultAsync(x => x.ShipperId == new Guid(request.ShipperId));

        if (shipper is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Shipper with ID: {request.ShipperId} not found"));

        // delete
        dbcontext.Shippers.Remove(shipper);
        await dbcontext.SaveChangesAsync();

        // log
        logger.LogInformation("Shipper is successfully deleted. ID: {ShipperId}, NAME: {ShipperName}", shipper.ShipperId.ToString(), shipper.ShipperName);

        return new DeleteShipperResponse { Success = true };
    }
}
