using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomerMicroservice
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment host)
        {
            Configuration = configuration;

            string credential_path = host.ContentRootPath + "/distributedprogramming-386215-8e01b2059244.json";
            //string credential_path = @"C:\source\DP_THA\DistributedProgramming_THA\DP_THA\distributedprogramming-386215-8e01b2059244.json"; //Local: '@"C:\source\DP_THA\DistributedProgramming_THA\DP_THA\distributedprogramming-386215-8e01b2059244.json"' //Docker: '@"/app/distributedprogramming-386215-8e01b2059244.json";'
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerMicroservice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerMicroservice v1"));
            }

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
