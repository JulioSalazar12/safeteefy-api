using System.Collections.Generic;
using safeteefy_api.Urgencies.Domain.Models;

namespace safeteefy_api.Guardians.Domain.Models
{
    public class Guardian
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public IList<Urgency> Urgencies { get; set; } = new List<Urgency>();
    }
}