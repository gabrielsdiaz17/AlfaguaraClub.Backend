namespace AlfaguaraClub.Backend.Api
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseCustomizedCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });
            return app;
        }
    }
}
