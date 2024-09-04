namespace RequestOrder.Application.Features.Queries;

public record GetOrderByProviderResponse(IEnumerable<OrderDto> Order, bool Success, string Message)
{
}

public record GetOrderByProviderQuery(Guid ProviderId) : IQuery<GetOrderByProviderResponse>;

public class GetOrderByProviderValidator : AbstractValidator<GetOrderByProviderQuery>
{
    public GetOrderByProviderValidator()
    {
        RuleFor(x => x.ProviderId).NotEmpty().WithMessage("ProviderId is required");
    }
}

public class GetOrderByProviderHandler(IRepositoryManager manager) : IQueryHandler<GetOrderByProviderQuery, GetOrderByProviderResponse>
{
    public async Task<GetOrderByProviderResponse> Handle(GetOrderByProviderQuery query, CancellationToken cancellationToken)
    {
        var orders = await manager.Order.GetOrdersByProviderAsync(ProviderId.Of(query.ProviderId), cancellationToken);

        if (orders == null || orders.Count() == 0)
        {
            return new GetOrderByProviderResponse([], false, "Order Not Found!");
        }

        //convert to dto using extension method.
        var dto = orders.ProjectToOrderDtoList();

        return new GetOrderByProviderResponse(dto, true, "Order Found!");
    }
}
