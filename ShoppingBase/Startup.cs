using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using ShoppingBase.Application.AutoMapper;
using ShoppingBase.Application.Dapper.Implementation;
using ShoppingBase.Application.Dapper.Interfaces;
using ShoppingBase.Application.Implementation;
using ShoppingBase.Application.Interfaces;
using ShoppingBase.Authorization;
using ShoppingBase.Data.EF;
using ShoppingBase.Data.Entities;
using ShoppingBase.Helpers;
using ShoppingBase.Infrastructure.Interfaces;
using ShoppingBase.Services;
using ShoppingBase.SignalR;

namespace ShoppingBase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("TeduCoreApp.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

         //   services.AddMemoryCache();
            services.AddRazorPages()
             .AddRazorRuntimeCompilation();
            // services.AddMinResponse();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddRecaptcha(new RecaptchaOptions()
            {
                SiteKey = Configuration["Recaptcha:SiteKey"],
                SecretKey = Configuration["Recaptcha:SecretKey"]
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
            });

            services.AddSingleton(AutoMapperConfig.RegisterMappings().CreateMapper());
            //services.AddAuthentication()
            //    .AddFacebook(facebookOpts =>
            //    {
            //        facebookOpts.AppId = Configuration["Authentication:Facebook:AppId"];
            //        facebookOpts.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //    })
            //    .AddGoogle(googleOpts =>
            //    {
            //        googleOpts.ClientId = Configuration["Authentication:Google:ClientId"];
            //        googleOpts.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //    });
            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();

            services.AddTransient<DbInitializer>();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddControllersWithViews(options =>
            {
                //options.CacheProfiles.Add("Default",
                //    new CacheProfile()
                //    {
                //        Duration = 60
                //    });
                //options.CacheProfiles.Add("Never",
                //    new CacheProfile()
                //    {
                //        Location = ResponseCacheLocation.None,
                //        NoStore = true
                //    });
            })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                        opts => { opts.ResourcesPath = "Resources"; }
                    )
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4000")
                        .AllowCredentials();
                }));

            services.Configure<RequestLocalizationOptions>(
              opts =>
              {
                  var supportedCultures = new List<CultureInfo>
                  {
                        new CultureInfo("en-US"),
                        new CultureInfo("vi-VN")
                  };

                  opts.DefaultRequestCulture = new RequestCulture("en-US");
                  // Formatting numbers, dates, etc.
                  opts.SupportedCultures = supportedCultures;
                  // UI strings that we have localized.
                  opts.SupportedUICultures = supportedCultures;
              });

            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            //Serrvices
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            services.AddTransient<IAuthorizationHandler, BaseResourceAuthorizationHandler>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/thong-{Date}.txt");
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseMinResponse();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(routes =>
            {
             //   routes.MapHub<TeduHub>("/teduHub");

                routes.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapControllerRoute(
                    "areaRoute",
                    "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
