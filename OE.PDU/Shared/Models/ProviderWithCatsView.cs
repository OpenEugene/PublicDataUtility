using System.ComponentModel.DataAnnotations;

namespace OE.PDU.Module.LittleHelpBook.Models
{
    public class ProviderWithCatsView
    {
        [Key]
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebAddress { get; set; }
        public string EmailAddress { get; set; }
        public string HoursOfOperation { get; set; }
        public string Categories { get; set; }
        public string Subcategories { get; set; }
    }
}
