using Volo.Abp;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Modularity;

namespace SmartParking
{
    [DependsOn(
        typeof(SmartParkingDomainModule),
        typeof(SmartParkingApplicationContractsModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpBackgroundWorkersModule)
        )]
    public class SmartParkingApplicationModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SmartParkingApplicationModule>();
            });
        }
    }
}
