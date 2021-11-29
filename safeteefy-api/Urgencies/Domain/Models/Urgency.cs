using safeteefy_api.Guardians.Domain.Models;

namespace safeteefy_api.Urgencies.Domain.Models
{
    public class Urgency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedAt { get; set; }

        public int GuardianId { get; set; }
        public Guardian Guardian { get; set; }
    }
}