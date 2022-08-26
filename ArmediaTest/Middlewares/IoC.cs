using ArmediaTest.BLL.Services;
using ArmediaTest.BLL.Services.Interfaces;
using ArmediaTest.DAL.Services;
using ArmediaTest.DAL.Services.Interfaces;

namespace ArmediaTest.Middlewares
{
    public static class IoC
    {
        public static IServiceCollection AddDependencyServices(this IServiceCollection services)
        {
            services.AddTransient<ISPService, SPService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
