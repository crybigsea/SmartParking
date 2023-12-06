using Elsa.Attributes;
using Elsa.Design;
using Elsa.Metadata;
using Elsa.Services;
using System.Reflection;
using Workflow.Application.Contracts.Models;
using Workflow.Application.Contracts.Services;

namespace Workflow.HttpApi.Host.Activitys
{
    [Trigger(Category = "工作流", DisplayName = "审批", Description = "审批流程", Outcomes = new[] { "同意", "拒绝" })]
    public class ApproveActivity : Activity, IActivityPropertyOptionsProvider
    {
        private readonly IRoleService _roleService;

        public ApproveActivity(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [ActivityInput(
             UIHint = ActivityInputUIHints.MultiText,
             DefaultSyntax = "Json",
             SupportedSyntaxes = new[] { "Json", "Liquid" },
             IsDesignerCritical = true,
             OptionsProvider = typeof(ApproveActivity),
             Label = "角色")]
        public ICollection<string> ApproveRoles { get; set; }

        public object? GetOptions(PropertyInfo property)
        {
            if (property.Name == "ApproveRoles")
            {
                var roles = _roleService.GetAllRoles().Result;
                return roles.Select(x => new ComboSelectListItem
                {
                    Value = x.RoleID.ToString(),
                    Text = x.RoleName,
                    Disabled = false
                }).ToList();
            }

            return new List<ComboSelectListItem>();
        }
    }
}
