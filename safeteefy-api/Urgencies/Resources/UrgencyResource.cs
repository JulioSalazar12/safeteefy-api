namespace safeteefy_api.Urgencies.Resources
{
    public class UrgencyResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ReportedAt { get; set; }

        public int GuardianId { get; set; }
    }
}