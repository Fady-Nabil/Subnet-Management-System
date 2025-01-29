namespace SubnetIpManagement.API.Dtos
{
    public class IpAddressDto
    {
        public required string IpAddressValue { get; set; }
        public int SubnetId { get; set; }
        public int CreatedUserId { get; set; }
    }
}
