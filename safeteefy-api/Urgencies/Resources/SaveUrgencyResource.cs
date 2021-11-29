using System.ComponentModel.DataAnnotations;

namespace safeteefy_api.Urgencies.Resources
{
    public class SaveUrgencyResource
    {
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public string ReportedAt { get; set; }
        
        [Required]
        public int GuardianId { get; set; }
    }
}