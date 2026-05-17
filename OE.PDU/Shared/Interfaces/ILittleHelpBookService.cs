using System.Collections.Generic;
using System.Threading.Tasks;
using OE.PDU.Module.LittleHelpBook.Models;

namespace OE.PDU.Module.LittleHelpBook.Services
{
    public interface ILittleHelpBookService
    {
        Task<List<Provider>> GetProvidersAsync();
        Task<Provider> GetProviderAsync(int providerId);
        Task<Provider> AddProviderAsync(Provider provider);
        Task<Provider> UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(int providerId);
    }
}
