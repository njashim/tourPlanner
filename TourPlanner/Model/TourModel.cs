namespace Model
{
    public class TourModel
    {
        public IEnumerable<TourLogModel> TourLogs { get; set; }

        public TourModel()
        {
            TourLogs = new List<TourLogModel>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string FromLocation { get; set; } = null!;

        public string ToLocation { get; set; } = null!;

        public string TransportType { get; set; } = null!;

        public double Distance { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        public string RouteImagePath { get; set; } = null!;
    }
}
