using SubnetIpManagement.Domain.Entities;

namespace SubnetIpManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
