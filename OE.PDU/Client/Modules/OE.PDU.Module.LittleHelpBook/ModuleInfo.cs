using Oqtane.Models;
using Oqtane.Modules;

namespace OE.PDU.Module.LittleHelpBook
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LittleHelpBook",
            Description = "LittleHelpBook",
            Version = "1.0.0",
            ServerManagerType = "OE.PDU.Module.LittleHelpBook.Manager.LittleHelpBookManager, OE.PDU.Server.Oqtane"
        };
    }
}
