using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Workflow.Application.Contracts;

namespace SmartParking
{
    [DependsOn(
        typeof(SmartParkingDomainSharedModule),
        typeof(AbpObjectExtendingModule),
        typeof(WorkflowApplicationContractsModule)
    )]
    public class SmartParkingApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            SmartParkingDtoExtensions.Configure();
        }
    }
}
