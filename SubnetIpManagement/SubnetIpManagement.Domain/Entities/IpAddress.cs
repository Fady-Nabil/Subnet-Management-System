using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetIpManagement.Domain.Entities
{
    public class IpAddress
    {
        public int IpId { get; set; }
        public required string IpAddressValue { get; set; }
        public int SubnetId { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Subnet Subnet { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
