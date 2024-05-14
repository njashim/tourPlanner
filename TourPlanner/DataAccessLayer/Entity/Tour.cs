using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity;

public class Tour
{
    public IEnumerable<TourLog> TourLogs { get; set; }

    public Tour()
    {
        TourLogs = new List<TourLog>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Guid { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public string FromLocation { get; set; } = null!;

    [Required]
    public string ToLocation { get; set; } = null!;

    [Required]
    public string TransportType { get; set; } = null!;

    [Required]
    public double Distance { get; set; }

    [Required]
    public TimeSpan EstimatedTime { get; set; }

    [Required]
    public string RouteImagePath { get; set; } = null!;
}
