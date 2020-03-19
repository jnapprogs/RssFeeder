using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace RssFeeder.Models
{
    public class RssLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "No spaces are allowed before or after the URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Display(Name = "Description (optional)")]
        [DataType(DataType.Text)]
        [StringLength(512, ErrorMessage = "Description cannot exceed 512 characters")]
        public string Description { get; set; }

        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public void ValidateDescription()
        {
            if (Description == null)
            {
                return;
            }

            string trimmedDescription = Description.Trim();
            if (trimmedDescription.Length == 0)
            {
                Description = null;
            }

            Description = trimmedDescription;
        }
    }
}
