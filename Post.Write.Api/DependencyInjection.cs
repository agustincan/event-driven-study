using Post.Write.Api.Config;

namespace Post.Write.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostWriteApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.Configure<MongoDbConfig>(configuration.GetSection(nameof(MongoDbConfig)));
            services.Configure<ProducerConfig>(configuration.GetSection(nameof(ProducerConfig)));
            
            return services;
        }

    }
}
