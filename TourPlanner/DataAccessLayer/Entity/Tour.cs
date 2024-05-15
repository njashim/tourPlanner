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
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    public string FromLocation { get; set; } 

    [Required]
    [MaxLength(100)]
    public string ToLocation { get; set; }

    [Required]
    public string TransportType { get; set; } 

    [Required]
    [Column(TypeName = "double precision")]
    public double Distance { get; set; }

    [Required]
    public TimeSpan EstimatedTime { get; set; }

    [Required]
    public string RouteImagePath { get; set; }
}
