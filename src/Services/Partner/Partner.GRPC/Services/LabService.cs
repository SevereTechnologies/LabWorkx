using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Partner.GRPC.Data;
using Partner.GRPC.Models;

namespace Partner.GRPC.Services;

public class LabService(PartnerContext dbcontext, ILogger<LabService> logger) : LabProtoService.LabProtoServiceBase
{
    public override async Task<LabResponse> GetLab(GetLabRequest request, ServerCallContext context)
    {
        var lab = await dbcontext
            .Labs
            .FirstOrDefaultAsync(x => x.LabId == new Guid(request.LabId));

        if (lab == null)
        {
            lab = new Lab { LabId = new Guid(), LabName = "No Lab" };
        }

        // log info
        logger.LogInformation("Lab retrieved : ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        //convert to Response to return
        var response = lab.Adapt<LabResponse>();

        //return response
        return response;
    }

    public override async Task<LabResponse> CreateLab(CreateLabRequest request, ServerCallContext context)
    {
        var lab = request.Lab.Adapt<Lab>();
        if (lab is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbcontext.Labs.Add(lab);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Lab is successfully created. : ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        // mapp back to response object to return it
        var response = lab.Adapt<LabResponse>();
        return response;
    }

    public override async Task<LabResponse> UpdateLab(UpdateLabRequest request, ServerCallContext context)
    {
        var lab = request.Lab.Adapt<Lab>();
        if (lab is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbcontext.Labs.Update(lab);
        await dbcontext.SaveChangesAsync();

        logger.LogInformation("Lab is successfully updated. ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        // mapp back to response object to return it
        var response = lab.Adapt<LabResponse>();
        return response;
    }

    public override async Task<DeleteLabResponse> DeleteLab(DeleteLabRequest request, ServerCallContext context)
    {
        var lab = await dbcontext
            .Labs
            .FirstOrDefaultAsync(x => x.LabId == new Guid(request.LabId));

        if (lab is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Lab with ID: {request.LabId} not found"));

        // delete
        dbcontext.Labs.Remove(lab);
        await dbcontext.SaveChangesAsync();

        // log
        logger.LogInformation("Lab is successfully deleted. ID: {LabId}, NAME: {LabName}", lab.LabId.ToString(), lab.LabName);

        return new DeleteLabResponse { Success = true };
    }
}
