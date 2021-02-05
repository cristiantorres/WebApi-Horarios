using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
using WebApiHorarios.Model;
using WebApiHorarios.Repositories;
using Serilog;
using Microsoft.Extensions.Logging;
using WebApiHorarios.Data;

namespace WebApiHorarios
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
            var connectionPath = Configuration.GetConnectionString("DefaultConnection");
            var path = Environment.CurrentDirectory;
            var ConnectionToAttachSql = connectionPath.Replace("%root%",path);
            services.AddTransient<IHorarioRepository, HorarioRepository>();
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(ConnectionToAttachSql));
            services.AddControllers();
      
            services.AddMvc();
        }
 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var logger = new LoggerConfiguration();

            loggerFactory.AddSerilog();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
