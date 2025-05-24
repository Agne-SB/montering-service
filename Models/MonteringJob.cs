namespace MonteringService.Models
{
    public class MonteringJob
    {
        public int Id { get; set; }

        public string RefNo { get; set; } = string.Empty;

        public string Adresse { get; set; } = string.Empty;

        public DateTime? MonteringDato { get; set; }

        public string? Worker { get; set; }

        public string Status { get; set; } = "Planlagt"; // Planlagt, Utført, Retur

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
