using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;

namespace SmartParking
{
    [DependsOn(
        typeof(SmartParkingDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule)
    )]
    public class SmartParkingDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
