namespace RequestOrder.Application.Features.Queries;

public record GetOrderByNumberResponse(OrderDto? Order, bool Success, string Message)
{
}

public record GetOrderByNumberQuery(string OrderNumber) : IQuery<GetOrderByNumberResponse>;

public class GetOrderByNumberValidator : AbstractValidator<GetOrderByNumberQuery>
{
    public GetOrderByNumberValidator()
    {
        RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("OrderNumber is required");
    }
}

public class GetOrderByNumberHandler(IRepositoryManager manager) : IQueryHandler<GetOrderByNumberQuery, GetOrderByNumberResponse>
{
    public async Task<GetOrderByNumberResponse> Handle(GetOrderByNumberQuery query, CancellationToken cancellationToken)
    {
        var order = await manager.Order.GetByNumberAsync(OrderNumber.Of(query.OrderNumber), cancellationToken);

        if (order == null)
        {
            return new GetOrderByNumberResponse(null, false, "Order Not Found!");
        }

        //convert to dto using extension method.
        var dto = order.ToOrderDto();

        return new GetOrderByNumberResponse(dto, true, "Order Found!");
    }
}