namespace MonteringService.Models
{
    public class MonteringJob
    {
        public int Id { get; set; }
        public string RefNo { get; set; } = "";
        public string Adresse { get; set; } = "";
        public DateTime? MonteringDato { get; set; }
        public string? Worker { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
