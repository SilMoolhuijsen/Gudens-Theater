
using System.ComponentModel.DataAnnotations;

namespace Gudens_Theater.Models
{
    public class Person
    {
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
    }
}
