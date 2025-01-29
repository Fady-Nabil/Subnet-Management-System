using System.Net;

namespace SubnetIpManagement.API.Helpers
{
    public static class IPNetworkHelper
    {
        public static List<string> GetIPAddresses(string cidr)
        {
            string[] parts = cidr.Split('/');
            string baseIp = parts[0];
            int subnetMask = int.Parse(parts[1]);

            uint ip = IpToUint(baseIp);
            uint mask = ~(uint.MaxValue >> subnetMask);

            uint startIp = ip & mask;
            uint endIp = startIp | ~mask;

            var ipAddresses = new List<string>();
            for (uint i = startIp; i <= endIp; i++)
            {
                ipAddresses.Add(UintToIp(i));
            }

            return ipAddresses;
        }

        private static uint IpToUint(string ip)
        {
            return (uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(ip).Address);
        }

        private static string UintToIp(uint ip)
        {
            return IPAddress.Parse(ip.ToString()).ToString();
        }
    }

}
