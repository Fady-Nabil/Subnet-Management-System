namespace SubnetIpManagement.API.Dtos
{
    public class GetIPAddressDto
    {
        public int IpId { get; set; }
        public required string IpAddressValue { get; set; }
        public required string SubnetName { get; set; }
        public required string CreatorEmail { get; set; }
    }
}
