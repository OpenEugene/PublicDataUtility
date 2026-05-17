using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using OE.PDU.Module.LittleHelpBook.Models;
using OE.PDU.Module.LittleHelpBook.Services;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace OE.PDU.Module.LittleHelpBook.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class LittleHelpBookController : ModuleControllerBase
    {
        private readonly ILittleHelpBookService _LittleHelpBookService;

        public LittleHelpBookController(ILittleHelpBookService LittleHelpBookService, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _LittleHelpBookService = LittleHelpBookService;
        }

        // GET: api/<controller>
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<IEnumerable<Provider>> Get()
        {
            return await _LittleHelpBookService.GetProvidersAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public async Task<Provider> Get(int id)
        {
            Provider provider = await _LittleHelpBookService.GetProviderAsync(id);
            if (provider == null)
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Read, "Provider Not Found {ProviderId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            return provider;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Provider> Post([FromBody] Provider provider)
        {
            if (ModelState.IsValid)
            {
                provider = await _LittleHelpBookService.AddProviderAsync(provider);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Create, "Invalid Provider {Provider}", provider);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                provider = null;
            }
            return provider;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task<Provider> Put(int id, [FromBody] Provider provider)
        {
            if (ModelState.IsValid && provider.ProviderId == id)
            {
                provider = await _LittleHelpBookService.UpdateProviderAsync(provider);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Update, "Invalid Provider {Provider}", provider);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                provider = null;
            }
            return provider;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public async Task Delete(int id)
        {
            await _LittleHelpBookService.DeleteProviderAsync(id);
        }
    }
}
