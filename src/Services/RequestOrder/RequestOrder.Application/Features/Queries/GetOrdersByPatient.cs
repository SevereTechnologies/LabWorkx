namespace RequestOrder.Application.Features.Queries;

public record GetOrderByPatientResponse(IEnumerable<OrderDto> Order, bool Success, string Message)
{
}

public record GetOrderByPatientQuery(Guid PatientId) : IQuery<GetOrderByPatientResponse>;

public class GetOrderByPatientValidator : AbstractValidator<GetOrderByPatientQuery>
{
    public GetOrderByPatientValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty().WithMessage("PatientId is required");
    }
}

public class GetOrderByPatientHandler(IRepositoryManager manager) : IQueryHandler<GetOrderByPatientQuery, GetOrderByPatientResponse>
{
    public async Task<GetOrderByPatientResponse> Handle(GetOrderByPatientQuery query, CancellationToken cancellationToken)
    {
        var orders = await manager.Order.GetOrdersByPatientAsync(PatientId.Of(query.PatientId), cancellationToken);

        if (orders == null || orders.Count() == 0)
        {
            return new GetOrderByPatientResponse([], false, "Order Not Found!");
        }

        //convert to dto using extension method.
        var dto = orders.ProjectToOrderDtoList();

        return new GetOrderByPatientResponse(dto, true, "Order Found!");
    }
}
