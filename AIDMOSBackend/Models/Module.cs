using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("modules")]
public partial class Module
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id", TypeName = "numeric(38, 0)")]
    public decimal Id { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string? Title { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string? Description { get; set; }

    [Column("landingpage")]
    [StringLength(50)]
    public string? Landingpage { get; set; }

    [Column("srno", TypeName = "numeric(18, 0)")]
    public decimal? Srno { get; set; }

    [Column("referenceid", TypeName = "numeric(18, 0)")]
    public decimal? Referenceid { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string? Type { get; set; }

   }
