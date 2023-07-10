namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(
    Guid id,
    string Email,
    string FirstName,
    string LastName,
    string Token);
