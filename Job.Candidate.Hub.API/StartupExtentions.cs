using Microsoft.OpenApi.Models;
using Job.Candidate.Hub.API.Middlewares;
using Job.Candidate.Hub.Application;
using Job.Candidate.Hub.Infrastructure;

namespace Job.Candidate.Hub.API
{
    public static class StartupExtentions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();

        }


        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Candidate Hub API");
                });
            }

            app.UseHttpsRedirection();

            //app.UseRouting();

            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;

        }



        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Job Candidate Hub API",

                });

            });
        }
    }
}
