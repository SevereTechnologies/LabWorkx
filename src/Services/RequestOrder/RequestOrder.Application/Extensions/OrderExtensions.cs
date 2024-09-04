namespace RequestOrder.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<OrderDto> ProjectToOrderDtoList(this IEnumerable<Order> orders)
    {
        var dtos = orders.Select(order => new OrderDto(
                        Id: order.Id.Value,
                        OrderNumber: order.OrderNumber.Value,
                        PatientId: order.PatientId.Value,
                        TechnicianId: order.TechnicianId.Value,
                        ProviderId: order.ProviderId.Value,
                        LabId: order.LabId.Value,
                        ShipperId: order.ShipperId.Value,
                        Address: new AddressDto(
                            order.Address.Address1,
                            order.Address.Address2,
                            order.Address.City,
                            order.Address.Zip,
                            order.Address.State,
                            order.Address.Country),
                        Payment: new PaymentDto(
                            order.Payment.MedicarePaidAmount,
                            order.Payment.MedicarePaidDate,
                            order.Payment.MedicaidPaidAmount,
                            order.Payment.MedicaidPaidDate,
                            order.Payment.LabPaidAmount,
                            order.Payment.LabPaidDate,
                            order.Payment.OtherPaidAmount,
                            order.Payment.OtherPaidDate),
                        Insurance: new InsuranceDto(
                            order.Insurance.InsuranceCompany,
                            order.Insurance.InsuranceGroup,
                            order.Insurance.InsurancePolicy),
                        Status: order.Status,
                        DrivingDistance: order.DrivingDistance,
                        TotalCost: order.TotalCost,
                        OrderItems: order.OrderItems.Select(
                            x => new OrderItemDto(
                            x.OrderId.Value,
                            x.ProcedureId.Value,
                            x.Quantity,
                            x.Cost)).ToList()));

        return dtos;
    }

    public static OrderDto ProjectToOrderDto(this Order order)
    {
        var dto = new OrderDto(
                        Id: order.Id.Value,
                        OrderNumber: order.OrderNumber.Value,
                        PatientId: order.PatientId.Value,
                        TechnicianId: order.TechnicianId.Value,
                        ProviderId: order.ProviderId.Value,
                        LabId: order.LabId.Value,
                        ShipperId: order.ShipperId.Value,
                        Address: new AddressDto(
                            order.Address.Address1,
                            order.Address.Address2,
                            order.Address.City,
                            order.Address.Zip,
                            order.Address.State,
                            order.Address.Country),
                        Payment: new PaymentDto(
                            order.Payment.MedicarePaidAmount,
                            order.Payment.MedicarePaidDate,
                            order.Payment.MedicaidPaidAmount,
                            order.Payment.MedicaidPaidDate,
                            order.Payment.LabPaidAmount,
                            order.Payment.LabPaidDate,
                            order.Payment.OtherPaidAmount,
                            order.Payment.OtherPaidDate),
                        Insurance: new InsuranceDto(
                            order.Insurance.InsuranceCompany,
                            order.Insurance.InsuranceGroup,
                            order.Insurance.InsurancePolicy),
                        Status: order.Status,
                        DrivingDistance: order.DrivingDistance,
                        TotalCost: order.TotalCost,
                        OrderItems: order.OrderItems.Select(
                            x => new OrderItemDto(
                            x.OrderId.Value,
                            x.ProcedureId.Value,
                            x.Quantity,
                            x.Cost)).ToList());

        return dto;
    }
}
