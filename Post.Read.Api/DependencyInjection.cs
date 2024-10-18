using System;

namespace Post.Read.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostReadApiServices(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //  options.UseNpgsql(
            //      configuration.GetConnectionString("Pg1Cnn")
            //  ));
            return services;
        }
        
    }
}
