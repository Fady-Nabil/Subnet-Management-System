using SubnetIpManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetIpManagement.Domain.Interfaces
{
    public interface IIPAddressRepository
    {
        Task<IEnumerable<IpAddress>> GetAllIPsBySubnetIdAsync(int subnetId);
        Task<IpAddress?> GetIPAddressByIdAsync(int ipId);
        Task AddIPAddressAsync(IpAddress ipAddress);
        Task UpdateIPAddressAsync(IpAddress ipAddress);
        Task DeleteIPAddressAsync(int ipId);
    }
}
