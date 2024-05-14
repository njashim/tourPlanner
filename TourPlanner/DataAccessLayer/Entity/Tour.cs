using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entity;

public class Tour
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Fromlocation { get; set; } = null!;

    public string Tolocation { get; set; } = null!;

    public string Transporttype { get; set; } = null!;

    public double Distance { get; set; }

    public TimeSpan Estimatedtime { get; set; }

    public string Routeimagepath { get; set; } = null!;

    public virtual ICollection<TourLog> TourLogs { get; set; } = new List<TourLog>();
}
