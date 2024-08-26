using Grpc.Core;

namespace Partner.GRPC.Services;

public class LabService : LabProtoService.LabProtoServiceBase
{
    public override Task<LabResponse> GetLab(GetLabRequest request, ServerCallContext context)
    {
        return base.GetLab(request, context);
    }

    public override Task<LabResponse> CreateLab(CreateLabRequest request, ServerCallContext context)
    {
        return base.CreateLab(request, context);
    }

    public override Task<LabResponse> UpdateLab(UpdateLabRequest request, ServerCallContext context)
    {
        return base.UpdateLab(request, context);
    }

    public override Task<DeleteLabResponse> DeleteLab(DeleteLabRequest request, ServerCallContext context)
    {
        return base.DeleteLab(request, context);
    }
}
