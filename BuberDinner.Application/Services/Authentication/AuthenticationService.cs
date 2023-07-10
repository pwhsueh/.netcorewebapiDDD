using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    AuthenticationResult IAuthenticationService.Login(string email, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // 2. Vlaidate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        // 3. create JTWT token
        return new AuthenticationResult(user, token);
    }

    AuthenticationResult IAuthenticationService.Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists");
        }

        // 2. create user (generate unique id) & persist to DB
        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };
        _userRepository.Add(user);

        // 3. create JTWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}