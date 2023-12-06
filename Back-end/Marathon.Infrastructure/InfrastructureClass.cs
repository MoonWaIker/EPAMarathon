using Marathon.Infrastructure.Services;
using Marathon.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Marathon.Infrastructure
{
    public static class InfrastructureClass
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDataBase, CosmosDB>();
        }
    }
}
