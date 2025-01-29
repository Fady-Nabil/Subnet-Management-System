using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.Domain.Interfaces;
using System.Net;

namespace SubnetIpManagement.API.Services
{
    public class FileService(ISubnetRepository subnetRepository, IIPAddressRepository ipAddressRepository)
    {
        private readonly ISubnetRepository _subnetRepository = subnetRepository;
        private readonly IIPAddressRepository _ipAddressRepository = ipAddressRepository;

        public async Task ProcessSubnetFileAsync(IFormFile file)
        {
            await Task.Delay(1000);
            //if (file == null || file.Length == 0)
            //    throw new ArgumentException("File is empty or null");


            //using var stream = new StreamReader(file.OpenReadStream());
            //string line;
            //while ((line = await stream.ReadLineAsync()) != null)
            //{
            //    var columns = line.Split(',');

            //    if (columns.Length < 2)
            //    {
            //        throw new ArgumentException("Invalid CSV format. Each line should contain SubnetName and SubnetAddress.");
            //    }

            //    var subnetName = columns[0].Trim();
            //    var subnetAddress = columns[1].Trim();

            //    // Save Subnet
            //    var subnet = new Subnet
            //    {
            //        SubnetName = subnetName,
            //        SubnetAddress = subnetAddress,
            //        CreatedBy = 1, // Replace with the authenticated user ID
            //        CreatedAt = DateTime.UtcNow
            //    };

            //    await _subnetRepository.AddSubnetAsync(subnet);
            //    var ipAddresses = ConvertSubnetToIPs(subnetAddress);

            //    foreach (var ip in ipAddresses)
            //    {
            //        var ipAddress = new IpAddress
            //        {
            //            IpAddressValue = ip,
            //            SubnetId = subnet.SubnetId,
            //            CreatedBy = 1, // Replace with the authenticated user ID
            //            CreatedAt = DateTime.UtcNow
            //        };

            //        await _ipAddressRepository.AddIPAddressAsync(ipAddress);
            //    }
            // }
        }
    }
}
