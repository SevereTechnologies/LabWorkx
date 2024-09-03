namespace RequestOrder.Application.Features.Queries;

public record GetOrderByIdResponse(OrderDto? Order, bool Success, string Message)
{
}

public record GetOrderByIdQuery(Guid OrderId) : IQuery<GetOrderByIdResponse>;

public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}

public class GetOrderByIdHandler(IRepositoryManager manager) : IQueryHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var order = await manager.Order.GetByIdAsync(OrderId.Of(query.OrderId), cancellationToken);

        if (order == null)
        {
            return new GetOrderByIdResponse(null, false, "Order Not Found!");
        }

        //convert to dto using extension method.
        var dto = order.ToOrderDto();

        return new GetOrderByIdResponse(dto, true, "Order Found!");
    }
}
