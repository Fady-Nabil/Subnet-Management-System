namespace SubnetIpManagement.API.Dtos
{
    public class SubnetDto
    {
        public required string SubnetName { get; set; }
        public required string SubnetAddress { get; set; }
        public int CreatedUserId { get; set; }
    }
}
