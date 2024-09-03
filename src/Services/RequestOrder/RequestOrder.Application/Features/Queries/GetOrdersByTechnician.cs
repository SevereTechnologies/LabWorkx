namespace RequestOrder.Application.Features.Queries;

public record GetOrderByTechnicianResponse(IEnumerable<OrderDto> Order, bool Success, string Message)
{
}

public record GetOrderByTechnicianQuery(Guid TechnicianId) : IQuery<GetOrderByTechnicianResponse>;

public class GetOrderByTechnicianValidator : AbstractValidator<GetOrderByTechnicianQuery>
{
    public GetOrderByTechnicianValidator()
    {
        RuleFor(x => x.TechnicianId).NotEmpty().WithMessage("TechnicianId is required");
    }
}

public class GetOrderByTechnicianHandler(IRepositoryManager manager) : IQueryHandler<GetOrderByTechnicianQuery, GetOrderByTechnicianResponse>
{
    public async Task<GetOrderByTechnicianResponse> Handle(GetOrderByTechnicianQuery query, CancellationToken cancellationToken)
    {
        var orders = await manager.Order.GetOrdersByTechnicianAsync(TechnicianId.Of(query.TechnicianId), cancellationToken);

        if (orders == null || orders.Count() == 0)
        {
            return new GetOrderByTechnicianResponse(null, false, "Order Not Found!");
        }

        //convert to dto using extension method.
        var dto = orders.ToOrderDtoList();

        return new GetOrderByTechnicianResponse(dto, true, "Order Found!");
    }
}
