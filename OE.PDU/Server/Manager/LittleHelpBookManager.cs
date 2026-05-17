using System;
using System.Collections.Generic;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Interfaces;
using Oqtane.Enums;
using Oqtane.Repository;
using OE.PDU.Module.LittleHelpBook.Repository;
using System.Threading.Tasks;

namespace OE.PDU.Module.LittleHelpBook.Manager
{
    public class LittleHelpBookManager : MigratableModuleBase, IInstallable, IPortable, ISearchable
    {
        private readonly IDBContextDependencies _DBContextDependencies;

        public LittleHelpBookManager(IDBContextDependencies DBContextDependencies)
        {
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LittleHelpBookContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LittleHelpBookContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            return "";
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
        }

        public Task<List<SearchContent>> GetSearchContentsAsync(PageModule pageModule, DateTime lastIndexedOn)
        {
            return Task.FromResult(new List<SearchContent>());
        }
    }
}
