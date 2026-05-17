using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Oqtane.Services;
using OE.PDU.Module.LittleHelpBook.Services;

namespace OE.PDU.Module.LittleHelpBook.Startup
{
    public class ClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            if (!services.Any(s => s.ServiceType == typeof(ILittleHelpBookService)))
            {
                services.AddScoped<ILittleHelpBookService, ClientLittleHelpBookService>();
            }
        }
    }
}
