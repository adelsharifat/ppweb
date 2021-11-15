using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProjectProgress.Data;
using ProjectProgress.Data.Interface;
using ProjectProgress.Data.Repository;
using ProjectProgress.Domain.DTO.Shared;
using ProjectProgress.Service.Interface;
using ProjectProgress.Service.Service;

namespace ProjectProgress
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
            services.Configure<JwtOptions>(Configuration.GetSection(nameof(JwtOptions)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<AppDbContext>(options => {                
                options.UseSqlServer(Configuration.GetConnectionString("DefaultCS"));
                options.UseLazyLoadingProxies();
            });

            var key = Encoding.ASCII.GetBytes(Configuration["JwtOptions:SecKey"]);
            var clockSckew = Convert.ToInt32(Configuration["JwtOptions:ClockSkew"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,                
                ClockSkew = TimeSpan.FromSeconds(clockSckew)
            };


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddSingleton(tokenValidationParameters);
            services.AddSingleton<DapperContext>();



            services.AddAuthorization();



            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IItemService, ItemService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(options=> {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });


            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
