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
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using RulesForOperationProceeding.Data.IRepositories;
using RulesForOperationProceeding.Data.Repositories;

namespace RulesForOperationProceeding.Api
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
            services.AddControllers();
            services.AddDbContext<RulesForOperationProceedingDataDbContext>(options =>
            {

                options.UseNpgsql(Configuration.GetConnectionString("Pstgr"),
                    npsqlOptions => npsqlOptions.MigrationsAssembly("AccountsTestP.Api"));
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped <IOperationTypeRepository, OperationTypeRepository>();
            services.AddScoped<IOperationParameterRepositor, OperationParameterRepository>();
            services.AddScoped<IRuleRepository, RulesRepository>();
            services.AddMediatR(typeof(RulesForOperationProceeding.Services.Services.AddOperationParameterCommandHandler).Assembly);
            //services.AddControllers(options =>
            //   options.Filters.Add(new HttpResponseExceptionFilter()));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "—ервис правил дл€ формировани€ проводок", Version = "v1" });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //using (var serviceScope = app.ApplicationServices.CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetService<RulesForOperationProceedingDataDbContext>();
            //    context.Database.Migrate();
            //}

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "—ервис правил дл€ формировани€ проводок v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
