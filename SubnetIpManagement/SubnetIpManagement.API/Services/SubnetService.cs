using AutoMapper;
using SubnetIpManagement.API.Dtos;
using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.Domain.Interfaces;
using SubnetIpManagement.SharedKernel.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SubnetIpManagement.API.Services
{
    public class SubnetService(ISubnetRepository subnetRepository, IMapper mapper)
    {
        private readonly ISubnetRepository _subnetRepository = subnetRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<PaginatedList<GetSubnetDto>> GetSubnetsAsync(int pageNumber, int pageSize)
        {
            var data = await _subnetRepository.GetSubnetsAsync(pageNumber, pageSize);
           return _mapper.Map<PaginatedList<Subnet>, PaginatedList<GetSubnetDto>>(data);
        }

        public async Task<GetSubnetDto?> GetSubnetByIdAsync(int subnetId)
        {
            var data = await _subnetRepository.GetSubnetByIdAsync(subnetId);
            if(data is null) return null;
            return _mapper.Map<Subnet, GetSubnetDto>(data);
        }

        public async Task<bool> CreateSubnetAsync(SubnetDto subnetDto)
        {
            var subnet = new Subnet 
            { 
                SubnetName = subnetDto.SubnetName,
                SubnetAddress = subnetDto.SubnetAddress,
                CreatedUserId = subnetDto.CreatedUserId,
                CreatedAt = DateTime.Now
            };
            await _subnetRepository.AddSubnetAsync(subnet);
            return true;
        }

        public async Task<bool> UpdateSubnetAsync(int id, SubnetDto subnetDto)
        {
            var getSubnet = await _subnetRepository.GetSubnetByIdAsync(id);
            if (getSubnet is null) return false;
            getSubnet.SubnetName = subnetDto.SubnetName;
            getSubnet.SubnetAddress = subnetDto.SubnetAddress;
            await _subnetRepository.UpdateSubnetAsync(getSubnet);
            return true;
        }

        public async Task<bool> DeleteSubnetAsync(int subnetId)
        {
            await _subnetRepository.DeleteSubnetAsync(subnetId);
            return true;
        }
    }
}
