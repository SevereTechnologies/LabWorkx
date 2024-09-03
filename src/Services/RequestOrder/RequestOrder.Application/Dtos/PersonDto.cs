namespace RequestOrder.Application.Dtos;

public record PersonDto(
    string FirstName,
    string LastName,
    string EmailAddress,
    string Phone);