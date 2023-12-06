namespace WorkFlow.BuilderExtensions
{
    public static class WorkflowExtensions
    {
        public static IApplicationBuilder UseWorkflow(this IApplicationBuilder app)
        {
            return app.UseHttpActivities()
                .UseConfiguredEndpoints(endpoints =>
                {
                    endpoints.MapFallbackToPage("/_Host");
                });
        }
    }
}
