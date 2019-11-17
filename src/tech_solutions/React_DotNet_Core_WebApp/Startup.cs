using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using TechSolutionsLibs.Repository;
using TechSolutionsLibs.Repository.Interface;

namespace React_DotNet_Core_WebApp
{
    public class Startup
    {




        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private Container container = new Container();
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });


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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            #region Simple Injector reference: https://simpleinjector.readthedocs.io/en/latest/aspnetintegration.html

            app.UseSimpleInjector(container, options =>
            {
                options.UseLogging();
            });


            InitializeContainer();

            // Always verify the container
            container.Verify();
            #endregion

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void InitializeContainer()
        {            
            //Tech Solutions 
            container.Register<IDBSettings, DBSettings>(Lifestyle.Scoped);
            container.Register<IEmployeeActivityDBContext, EmployeeActivityDBContext>(Lifestyle.Scoped);
            container.Register<IEmployeeActivityRepository, EmployeeActivityRepository>(Lifestyle.Scoped);
        }
    }
}
