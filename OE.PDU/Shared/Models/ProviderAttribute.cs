using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OE.PDU.Module.LittleHelpBook.Models
{
    [Table("ProviderAttribute")]
    public class ProviderAttribute : ModelBase
    {
        [Key]
        public int ProviderAttributeId { get; set; }
        public int ProviderId { get; set; }
        public int AttributeId { get; set; }
    }
}
