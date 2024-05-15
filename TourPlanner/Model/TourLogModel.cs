namespace Model
{
    public class TourLogModel
    {
        public Guid Id { get; set; }

        public Guid TourId { get; set; }

        public DateTime DateTime { get; set; }

        public string? Comment { get; set; }

        public int Difficulty { get; set; }

        public double TotalDistance { get; set; }

        public TimeSpan TotalTime { get; set; }

        public int Rating { get; set; }
    }
}
