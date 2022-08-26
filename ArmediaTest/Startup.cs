using ArmediaTest.BLL.Utilities;
using ArmediaTest.DAL.Context;
using ArmediaTest.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace ArmediaTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            IoC.AddDependencyServices(services);

            //services.AddDbContext<DbTestContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            IoC.AddDependencyServices(services);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
