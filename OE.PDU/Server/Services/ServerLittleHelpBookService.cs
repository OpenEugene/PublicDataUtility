using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Shared;
using Oqtane.Models;
using OE.PDU.Module.LittleHelpBook.Models;
using OE.PDU.Module.LittleHelpBook.Repository;

namespace OE.PDU.Module.LittleHelpBook.Services
{
    public class ServerLittleHelpBookService : ILittleHelpBookService
    {
        private readonly ILittleHelpBookRepository _repository;
        private readonly ILogManager _logger;

        public ServerLittleHelpBookService(ILittleHelpBookRepository repository, ILogManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<List<Provider>> GetProvidersAsync()
        {
            return Task.FromResult(_repository.GetProviders().ToList());
        }

        public Task<Provider> GetProviderAsync(int providerId)
        {
            return Task.FromResult(_repository.GetProvider(providerId));
        }

        public Task<Provider> AddProviderAsync(Provider provider)
        {
            provider = _repository.AddProvider(provider);
            _logger.Log(Oqtane.Shared.LogLevel.Information, this, LogFunction.Create, "Provider Added {Provider}", provider);
            return Task.FromResult(provider);
        }

        public Task<Provider> UpdateProviderAsync(Provider provider)
        {
            provider = _repository.UpdateProvider(provider);
            _logger.Log(Oqtane.Shared.LogLevel.Information, this, LogFunction.Update, "Provider Updated {Provider}", provider);
            return Task.FromResult(provider);
        }

        public Task DeleteProviderAsync(int providerId)
        {
            _repository.DeleteProvider(providerId);
            _logger.Log(Oqtane.Shared.LogLevel.Information, this, LogFunction.Delete, "Provider Deleted {ProviderId}", providerId);
            return Task.CompletedTask;
        }
    }
}

