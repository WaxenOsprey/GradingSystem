using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GradingSystem.models;
using GradingSystem.data;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure DbContext with SQL Server
        services.AddDbContext<GradingSystemContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add controllers and enable JSON serialization
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null; // Keep property names as-is
        });

        // Enable CORS (Cross-Origin Resource Sharing)
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
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
            // In a production environment, you would handle errors differently (e.g., logging, user-friendly error page)
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Enable CORS
        app.UseCors("CorsPolicy");

        // Enable HTTPS redirection (optional)
        app.UseHttpsRedirection();

        // Serve static files (e.g., HTML, JS, CSS) from wwwroot
        app.UseStaticFiles();

        // Enable routing
        app.UseRouting();

        // Enable authentication and authorization (if needed)
        // app.UseAuthentication();
        // app.UseAuthorization();

        // Configure the endpoints (API controllers)
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
