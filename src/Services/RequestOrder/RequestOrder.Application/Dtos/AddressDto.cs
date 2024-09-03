namespace RequestOrder.Application.Dtos;

public record AddressDto(
    string Address1,
    string Address2,
    string City,
    string State,
    string ZipCode,
    string Country);
