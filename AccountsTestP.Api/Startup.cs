using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AccountsTestP.Data.AccountDbContext;
using AccountsTestP.Data.IRepositories;
using AccountsTestP.Data.Repositories;
using AccountsTestP.Service.Services;
using AccountsTestP.Domain.Queries;
using AccountsTestP.Data;
using AccountsTestP.Service.Dxos;
using MediatR;
using AutoMapper;
using AccountsTestP.Api.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

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
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountsHistoryRepository, AccountHistoryRepository>();
            services.AddScoped<IAccountDxos, AccountDxos>();
            services.AddScoped<IAccountHistoryDxos, AccountHistoryDxos>();
            services.AddMediatR(typeof(AccountsTestP.Service.Services.GetAccountHistoryHandler).Assembly);
            services.AddControllers(options =>
               options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api Router", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api Router v1");
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
