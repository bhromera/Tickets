using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tickets.API.Data;
using Tickets.API.Services.Interfaces;
using Tickets.Application.Data.Repositories;
using Tickets.Application.Data.Repositories.Interfaces;
using Tickets.Services;

namespace Tickets.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.AddSInfrastructure(services, _configuration);
            this.AddServices(services);

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDbContext<TicketsContext>(x => x.UseSqlServer(_configuration.GetConnectionString("SqlServer")));

            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tickets.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tickets.API v1");
            });
        }

        private void AddSInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketsContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IItensCarrinhoRepository, ItensCarrinhoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<ICarrinhoServices, CarrinhoServices>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IIngressoServices, IngressoServices>();
            services.AddScoped<ILoginServices, LoginServices>();
        }
    }
}
