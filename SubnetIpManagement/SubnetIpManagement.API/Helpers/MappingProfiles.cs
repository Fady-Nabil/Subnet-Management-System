using AutoMapper;
using SubnetIpManagement.API.Dtos;
using SubnetIpManagement.Domain.Entities;
using SubnetIpManagement.SharedKernel.Utilities;

namespace SubnetIpManagement.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Subnet, GetSubnetDto>()
            .ForMember(d => d.CreatorEmail, o => o.MapFrom(s => s.User.Email));

            CreateMap<PaginatedList<Subnet>, PaginatedList<GetSubnetDto>>()
            .ConstructUsing((source, context) =>
            {
                var items = context.Mapper.Map<List<GetSubnetDto>>(source.Items);
                return new PaginatedList<GetSubnetDto>(items, source.TotalCount, source.CurrentPage, source.PageSize);
            });

            CreateMap<IpAddress, GetIPAddressDto>()
            .ForMember(d => d.SubnetName, o => o.MapFrom(s => s.Subnet.SubnetName))
            .ForMember(d => d.CreatorEmail, o => o.MapFrom(s => s.User.Email));


        }

    }
}
