using System.ComponentModel.DataAnnotations;

namespace OE.PDU.Module.LittleHelpBook.Models
{
    public class CategoryView
    {
        [Key]
        public int AttributeId { get; set; }
        public string Name { get; set; }
    }
}
