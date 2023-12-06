using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.Modularity;

namespace WorkFlow
{
    public class WorkFlowMdoule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            ConfigureElsa(context, configuration);
        }


        private void ConfigureElsa(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var elsaSection = configuration.GetSection("Elsa");
            context.Services.AddElsa(options =>
            {
                options
                    .UseEntityFrameworkPersistence(ef =>
                        DbContextOptionsBuilderExtensions.UseSqlServer(ef, configuration.GetConnectionString("Default")))
                    .AddConsoleActivities()
                    .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                    .AddQuartzTemporalActivities()
                    .AddJavaScriptActivities()
                    .AddWorkflowsFrom<Startup>();
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
