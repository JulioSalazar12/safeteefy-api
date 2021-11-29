using System.ComponentModel.DataAnnotations;

namespace safeteefy_api.Guardians.Resources
{
    public class SaveGuardianResource
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(60)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}