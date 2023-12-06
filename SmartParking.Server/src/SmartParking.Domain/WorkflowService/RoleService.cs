using SmartParking.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Workflow.Application.Contracts.Dtos;
using Workflow.Application.Contracts.Services;

namespace SmartParking.WorkflowService
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<SysRole> _roleRepository;
        private readonly IObjectMapper _objectMapper;

        public RoleService(IObjectMapper objectMapper, IRepository<SysRole> roleRepository)
        {
            _objectMapper = objectMapper;
            _roleRepository = roleRepository;
        }

        public async Task<List<WorkflowRoleDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetListAsync();
            return _objectMapper.Map<List<SysRole>, List<WorkflowRoleDto>>(roles);
        }
    }
}
