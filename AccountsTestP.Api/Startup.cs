using AccountsTestP.Api.Filters;
using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Data.Repositories;
using AccountsTestP.Service.Dxos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AccountsTestP.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AccountTestPDbContext>(options =>
            {

                options.UseNpgsql(Configuration.GetConnectionString("Pstgr"),
                    npsqlOptions => npsqlOptions.MigrationsAssembly("AccountsTestP.Api"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountsHistoryRepository, AccountHistoryRepository>();
            services.AddScoped<IAccountHistoryBufferRepository, AccountHistoryBufferRepository>();
            services.AddScoped<IAccountTypeRepository,AccountTypeRepository>();
            services.AddSingleton<IAccountDxos, AccountDxos>();
            services.AddSingleton<IAccountHistorySingleDxos, AccountHistorySingleDxos>();
            services.AddSingleton<IAccountHistoryDxos, AccountHistoryDxos>();
            services.AddMediatR(typeof(AccountsTestP.Service.Services.GetAccountHistoryHandler).Assembly);
            services.AddControllers(options =>
               options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Сервис регистрации проводок", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AccountTestPDbContext>();
                context.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Сервис регистрации проводок v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
