using Microsoft.AspNetCore.Builder;
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
    }
}
