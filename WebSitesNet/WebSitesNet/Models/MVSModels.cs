using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSitesNet.Models
{
    public class MvsModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Mission")]
        public string Mission { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Vision")]
        public string Vision { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Goals")]
        public string Goals { get; set; }
    }
}