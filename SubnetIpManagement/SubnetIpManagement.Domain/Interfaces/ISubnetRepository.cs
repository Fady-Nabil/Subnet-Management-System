using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.SharedKernel.Utilities;

namespace SubnetIpManagement.Domain.Interfaces
{
    public interface ISubnetRepository
    {
        Task<PaginatedList<Subnet>> GetSubnetsAsync(int pageNumber, int pageSize, string? search = null);
        Task<PaginatedList<Subnet>> GetSubnetsAsync(int pageNumber, int pageSize);
        Task<Subnet?> GetSubnetByIdAsync(int id);
        Task AddSubnetAsync(Subnet subnet);
        Task UpdateSubnetAsync(Subnet subnet);
        Task DeleteSubnetAsync(int id);
    }
}
