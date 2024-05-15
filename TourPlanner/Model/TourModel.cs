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

        public string Name { get; set; }

        public string? Description { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public string TransportType { get; set; }

        public double Distance { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        public string RouteImagePath { get; set; }
    }
}
