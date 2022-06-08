
using System.ComponentModel.DataAnnotations;

namespace Gudens_Theater.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Gelieve uw voornaam in te vullen")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Gelieve uw achternaam in te vullen")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Gelieve uw emailadres in te vullen")]
        public string email { get; set; }
    }
}
