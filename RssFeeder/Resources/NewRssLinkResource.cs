using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RssFeeder.Data;

namespace RssFeeder.Resources
{
    public class NewRssLinkResource
    {
        [Required]
        [RegularExpression(@"\S+", ErrorMessage = "No spaces are allowed before or after the URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Display(Name = "Description (100 characters max)")]
        [DataType(DataType.Text)]
        [RegularExpression(@"\S+", ErrorMessage = "No spaces are allowed before or after the description")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description { get; set; }
    }
}
