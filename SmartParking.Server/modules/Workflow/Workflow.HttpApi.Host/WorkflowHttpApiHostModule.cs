using Elsa;
using Elsa.Extensions;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Modularity;
using Workflow.HttpApi.Host.Activitys;

namespace Workflow.HttpApi.Host
{
    public class WorkflowHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ConfigureElsa(context, configuration);
        }


        private void ConfigureElsa(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddElsa(options =>
            {
                options
                    .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(configuration.GetConnectionString("Default")), true)
                    .AddConsoleActivities()
                    .AddHttpActivities()
                    .AddQuartzTemporalActivities()
                    .AddJavaScriptActivities()
                    .AddHttpServices()
                    .AddActivity<ApproveActivity>();
            });
            context.Services.AddElsaApiEndpoints();
            context.Services.Configure<ApiVersioningOptions>(options =>
            {
                options.UseApiBehavior = false;
            });
            Configure<AbpAntiForgeryOptions>(options =>
            {
                options.AutoValidateFilter = type => type.Assembly != typeof(Elsa.Server.Api.Endpoints.WorkflowRegistry.Get).Assembly;
            });
        }
    }
}
