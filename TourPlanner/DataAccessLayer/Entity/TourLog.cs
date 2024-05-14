using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity;

public class TourLog
{
    public int Id { get; set; }

    public int? TourId { get; set; }

    public DateTime Datetime { get; set; }

    public string? Comment { get; set; }

    public string Difficulty { get; set; } = null!;

    public double Totaldistance { get; set; }

    public TimeSpan Totaltime { get; set; }

    public int Rating { get; set; }

    public virtual Tour? Tour { get; set; }
}
