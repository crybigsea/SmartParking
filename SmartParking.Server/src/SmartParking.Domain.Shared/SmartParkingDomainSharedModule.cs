using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SmartParking
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainSharedModule)
        )]
    public class SmartParkingDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            SmartParkingGlobalFeatureConfigurator.Configure();
            SmartParkingModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SmartParkingDomainSharedModule>();
            });
        }
    }
}
