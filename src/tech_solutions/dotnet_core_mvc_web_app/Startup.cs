using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using TechSolutionsLibs.Repository;
using TechSolutionsLibs.Repository.Interface;

namespace dotnet_core_mvc_web_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private Container container = new Container();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            #region Simple Injector reference: https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html
            //enable .net core simpleinjector
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation()
                    .AddPageModelActivation()
                    .AddTagHelperActivation();
            });
            #endregion Simple Injector
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            #region Simple Injector reference: https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html

            app.UseSimpleInjector(container, options =>
            {
                options.UseLogging();
            });


            InitializeContainer();

            // Always verify the container
            container.Verify();
            #endregion
        }

        private void InitializeContainer()
        {
            //Tech Solutions 
            container.Register<IDBSettings, DBSettings>(Lifestyle.Scoped);
            container.Register<IEmployeeActivityDBContext, EmployeeActivityDBContext>(Lifestyle.Scoped);
            container.Register<IEmployeeActivityRepository, EmployeeActivityRepository>(Lifestyle.Scoped);
            container.Register<IEmployeeActivityByDapperRepository, EmployeeActivityByDapperRepository>(Lifestyle.Scoped);
        }
    }
}
