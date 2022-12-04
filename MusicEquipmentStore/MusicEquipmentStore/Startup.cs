using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MusicEquipmentStore
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
            services.AddControllersWithViews();
            services.AddDbContext<DbContext>(d => d.UseSqlServer(Configuration.GetConnectionString("MusicStore")));s    
            services.AddControllersWithViews()
                .AddJsonOptions(d =>
                {
                    d.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    d.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}

