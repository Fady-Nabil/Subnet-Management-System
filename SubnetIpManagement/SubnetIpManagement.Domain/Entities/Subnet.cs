
namespace SubnetIpManagement.Domain.Entities
{
    public class Subnet
    {
        public int SubnetId { get; set; }
        public required string SubnetName { get; set; }
        public required string SubnetAddress { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; } = null!;
        public ICollection<IpAddress> IPAddresses { get; set; } = null!;
    }
}
