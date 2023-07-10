using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new();

        public User? GetByEmail(string email)
        {
            return users.SingleOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            users.Add(user);
        }
    }
}