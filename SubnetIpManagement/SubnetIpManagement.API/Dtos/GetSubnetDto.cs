namespace SubnetIpManagement.API.Dtos
{
    public class GetSubnetDto
    {
        public int SubnetId { get; set; }
        public required string SubnetName { get; set; }
        public required string SubnetAddress { get; set; }
        public required string CreatorEmail { get; set; }
    }
}
