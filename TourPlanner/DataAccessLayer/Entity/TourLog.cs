using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity;

public class TourLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid TourId { get; set; }

    [ForeignKey("TourId")]
    public Tour Tour { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DateTime { get; set; }

    public string? Comment { get; set; }

    [Required]
    public int Difficulty { get; set; }

    [Required]
    [Column(TypeName = "double precision")]
    public double TotalDistance { get; set; }

    [Required]
    public TimeSpan TotalTime { get; set; }

    [Required]
    public int Rating { get; set; }
}
