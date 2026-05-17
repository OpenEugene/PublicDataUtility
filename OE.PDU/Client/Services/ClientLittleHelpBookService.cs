using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Oqtane.Services;
using Oqtane.Shared;
using OE.PDU.Module.LittleHelpBook.Models;

namespace OE.PDU.Module.LittleHelpBook.Services
{
    public class ClientLittleHelpBookService : ServiceBase, ILittleHelpBookService
    {
        public ClientLittleHelpBookService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("LittleHelpBook");

        public async Task<List<Provider>> GetProvidersAsync()
        {
            return await GetJsonAsync<List<Provider>>($"{Apiurl}", Enumerable.Empty<Provider>().ToList());
        }

        public async Task<Provider> GetProviderAsync(int providerId)
        {
            return await GetJsonAsync<Provider>($"{Apiurl}/{providerId}");
        }

        public async Task<Provider> AddProviderAsync(Provider provider)
        {
            return await PostJsonAsync<Provider>($"{Apiurl}", provider);
        }

        public async Task<Provider> UpdateProviderAsync(Provider provider)
        {
            return await PutJsonAsync<Provider>($"{Apiurl}/{provider.ProviderId}", provider);
        }

        public async Task DeleteProviderAsync(int providerId)
        {
            await DeleteAsync($"{Apiurl}/{providerId}");
        }
    }
}
