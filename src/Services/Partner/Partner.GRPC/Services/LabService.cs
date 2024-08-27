using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Partner.GRPC.Data;
using Partner.GRPC.Models;
using static Grpc.Core.Metadata;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;

namespace Partner.GRPC.Services;

public class LabService(PartnerContext dbcontext, ILogger<LabService> logger) : LabProtoService.LabProtoServiceBase
{
    public override async Task<LabResponse> GetLab(GetLabRequest request, ServerCallContext context)
    {
        var lab = await dbcontext
            .Labs
            .FirstOrDefaultAsync(x => x.LabId == request.LabId);

        if (lab == null)
        {
            lab = new Lab { LabId = new Guid().ToString(), LabName = "No Lab Found" };
            TypeAdapterConfig<Lab, LabModel>.NewConfig().IgnoreNullValues(true); // don't map null values
        }

        // log info
        logger.LogInformation("Lab retrieved : ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        //convert to response
        var response = new LabResponse { Lab = lab.Adapt<LabModel>() };

        //return response
        return response;
    }

    public override async Task<LabResponse> CreateLab(CreateLabRequest request, ServerCallContext context)
    {
        var lab = request.Lab.Adapt<Lab>();
        if (lab is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request."));
        }

        dbcontext.Labs.Add(lab);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Lab is successfully created. : ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        // mapp back to response object to return it
        var response = new LabResponse { Lab = lab.Adapt<LabModel>() };

        return response;
    }

    public override async Task<LabResponse> UpdateLab(UpdateLabRequest request, ServerCallContext context)
    {
        //var lab = await dbcontext
        //    .Labs
        //    .FirstOrDefaultAsync(x => x.LabId == request.Lab.LabId);

        var lab = request.Lab.Adapt<Lab>(); // replace old with new from request

        if (lab is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Request."));
        }

        dbcontext.Labs.Update(lab);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Lab is successfully updated. ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        // mapp back to response object to return it
        TypeAdapterConfig<Lab, LabModel>.NewConfig().IgnoreNullValues(true); // don't map null values
        var response = new LabResponse { Lab = lab.Adapt<LabModel>() };

        return response;
    }

    public override async Task<DeleteLabResponse> DeleteLab(DeleteLabRequest request, ServerCallContext context)
    {
        var lab = await dbcontext
            .Labs
            .FirstOrDefaultAsync(x => x.LabId == request.LabId);

        if (lab is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"Lab with ID: {request.LabId} not found"));
        }

        // delete
        dbcontext.Labs.Remove(lab);
        await dbcontext.SaveChangesAsync();

        // log
        logger.LogInformation("Lab is successfully deleted. ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        return new DeleteLabResponse { Success = true };
    }
}
