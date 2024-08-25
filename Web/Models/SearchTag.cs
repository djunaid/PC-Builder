using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class SearchTag
    {
        [Required]
        public string Query { get; set; }
    }
}
