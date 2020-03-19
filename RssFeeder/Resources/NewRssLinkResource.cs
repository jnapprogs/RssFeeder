using System.ComponentModel.DataAnnotations;

namespace RssFeeder.Resources
{
    public class NewRssLinkResource
    {
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "No spaces are allowed before or after the URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Display(Name = "Description (optional)")]
        [DataType(DataType.Text)]
        [StringLength(512, ErrorMessage = "Description cannot exceed 512 characters")]
        public string Description { get; set; }
    }
}
