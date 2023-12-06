using Workflow.Application.Contracts.Dtos;

namespace Workflow.Application.Contracts.Services
{
    public interface IRoleService
    {
        Task<List<WorkflowRoleDto>> GetAllRoles();
    }
}
