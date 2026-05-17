using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace OE.PDU.Module.LittleHelpBook.Models
{
    [Table("Attribute")]
    public class LhbAttribute : ModelBase
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentAttributeId { get; set; }
        public string l10N { get; set; }
    }
}
