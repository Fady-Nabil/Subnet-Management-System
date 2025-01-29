using Microsoft.EntityFrameworkCore;
using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.Domain.Interfaces;

namespace SubnetIpManagement.Infrastructure.Data.Repositories
{
    public class IPAddressRepository(ApplicationDbContext context) : IIPAddressRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<IpAddress>> GetAllIPsBySubnetIdAsync(int subnetId)
        {
            return await _context.IpAddresses
                .Where(ip => ip.SubnetId == subnetId)
                .Include(s => s.Subnet)
                .ThenInclude(u => u.User)
                .ToListAsync();
        }

        public async Task<IpAddress?> GetIPAddressByIdAsync(int ipId)
        {
            return await _context.IpAddresses
                .Include(s => s.Subnet)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(p => p.IpId == ipId);
        }

        public async Task AddIPAddressAsync(IpAddress ipAddress)
        {
            _context.IpAddresses.Add(ipAddress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIPAddressAsync(IpAddress ipAddress)
        {
            _context.IpAddresses.Update(ipAddress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIPAddressAsync(int ipId)
        {
            var ipAddress = await _context.IpAddresses.FindAsync(ipId);
            if (ipAddress != null)
            {
                _context.IpAddresses.Remove(ipAddress);
                await _context.SaveChangesAsync();
            }
        }
    }
}
