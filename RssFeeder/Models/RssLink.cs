using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RssFeeder.Models
{
    public class RssLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "RSS Link name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description { get; set; }

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
