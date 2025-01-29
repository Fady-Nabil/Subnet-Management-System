using Microsoft.EntityFrameworkCore;
using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.Domain.Interfaces;
using SubnetIpManagement.SharedKernel.Utilities;
namespace SubnetIpManagement.Infrastructure.Data.Repositories
{
    public class SubnetRepository(ApplicationDbContext context) : ISubnetRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<PaginatedList<Subnet>> GetSubnetsAsync(int pageNumber, int pageSize, string? search = null)
        {
            var query = _context.Subnets.Include(s => s.User).AsNoTracking();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(s => s.SubnetName.Contains(search) || s.SubnetAddress.Contains(search));
            return await PaginatedList<Subnet>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PaginatedList<Subnet>> GetSubnetsAsync(int pageNumber, int pageSize)
        {
            return await GetSubnetsAsync(pageNumber, pageSize, null);
        }

        public async Task<Subnet?> GetSubnetByIdAsync(int id)
        {
            return await _context.Subnets.Include(s => s.User).FirstOrDefaultAsync(s => s.SubnetId == id);
        }

        public async Task AddSubnetAsync(Subnet subnet)
        {
            _context.Subnets.Add(subnet);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubnetAsync(Subnet subnet)
        {
            _context.Subnets.Update(subnet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubnetAsync(int id)
        {
            var subnet = await _context.Subnets.FindAsync(id);
            if (subnet != null)
            {
                _context.Subnets.Remove(subnet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
