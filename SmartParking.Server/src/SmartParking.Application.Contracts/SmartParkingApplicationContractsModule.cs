using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace SmartParking
{
    [DependsOn(
        typeof(SmartParkingDomainSharedModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class SmartParkingApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            SmartParkingDtoExtensions.Configure();
        }
    }
}
