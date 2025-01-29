using AutoMapper;
using SubnetIpManagement.API.Dtos;
using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.Domain.Interfaces;

namespace SubnetIpManagement.API.Services
{
    public class IPAddressService(IIPAddressRepository ipAddressRepository, IMapper mapper)
    {
        private readonly IIPAddressRepository _ipAddressRepository = ipAddressRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<GetIPAddressDto>> GetAllIPsBySubnetIdAsync(int subnetId)
        {
            var data = await _ipAddressRepository.GetAllIPsBySubnetIdAsync(subnetId);
            return _mapper.Map<IEnumerable<IpAddress>, IEnumerable<GetIPAddressDto>>(data);
        }

        public async Task<GetIPAddressDto?> GetIPAddressByIdAsync(int ipId)
        {
            var data = await _ipAddressRepository.GetIPAddressByIdAsync(ipId);
            if (data is null) return null;
            return _mapper.Map<IpAddress, GetIPAddressDto>(data);
        }

        public async Task<bool> CreateIPAddressAsync(IpAddressDto ipAddressDto)
        {
            var ipAddress = new IpAddress
            {
                IpAddressValue = ipAddressDto.IpAddressValue,
                SubnetId = ipAddressDto.SubnetId,
                CreatedUserId = ipAddressDto.CreatedUserId,
                CreatedAt = DateTime.Now
            };
            await _ipAddressRepository.AddIPAddressAsync(ipAddress);
            return true;
        }

        public async Task<bool> UpdateIPAddressAsync(int id, IpAddressDto ipAddressDto)
        {
            var getIpAddress = await _ipAddressRepository.GetIPAddressByIdAsync(id);
            if (getIpAddress is null) return false;
            getIpAddress.IpAddressValue = ipAddressDto.IpAddressValue;
            getIpAddress.SubnetId = ipAddressDto.SubnetId;
            getIpAddress.CreatedUserId = ipAddressDto.CreatedUserId;
            await _ipAddressRepository.UpdateIPAddressAsync(getIpAddress);
            return true;
        }

        public async Task<bool> DeleteIPAddressAsync(int ipId)
        {
            await _ipAddressRepository.DeleteIPAddressAsync(ipId);
            return true;
        }
    }
}
