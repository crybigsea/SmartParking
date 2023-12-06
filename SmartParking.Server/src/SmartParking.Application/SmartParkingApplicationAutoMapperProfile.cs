using AutoMapper;
using SmartParking.Dtos.SysMenu;
using SmartParking.Dtos.SysUpdateInfo;
using SmartParking.Dtos.SysUserInfo;
using SmartParking.Entitys;
using Workflow.Application.Contracts.Dtos;

namespace SmartParking
{
    public class SmartParkingApplicationAutoMapperProfile : Profile
    {
        public SmartParkingApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<SysUserInfo, LoginOutputDto>();
            CreateMap<SysMenu, SysMenuDto>();
            CreateMap<SysUpdateFile, SysUpdateFileDto>();
            CreateMap<SysRole, WorkflowRoleDto>().ForMember(d => d.RoleID, options => options.MapFrom(o => o.Id));
        }
    }
}
