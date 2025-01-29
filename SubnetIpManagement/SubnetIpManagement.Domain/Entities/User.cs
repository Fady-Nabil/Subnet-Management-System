using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetIpManagement.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public ICollection<Subnet>? Subnets { get; set; }
        public ICollection<IpAddress>? IPAddresses { get; set; }
    }
}
