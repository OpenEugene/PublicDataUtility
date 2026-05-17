using System.ComponentModel.DataAnnotations;

namespace OE.PDU.Module.LittleHelpBook.Models
{
    public class SubCategoryView
    {
        [Key]
        public int AttributeId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
