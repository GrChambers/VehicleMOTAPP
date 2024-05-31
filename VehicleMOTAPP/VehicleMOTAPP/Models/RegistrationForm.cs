using System.ComponentModel.DataAnnotations;

namespace VehicleMOTAPP.Models
{
    public class RegistrationForm
    {
        [Required]
        public string Registration { get; set; }
    }
}
