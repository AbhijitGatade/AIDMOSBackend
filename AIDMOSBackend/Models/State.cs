using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("states")]
public partial class State
{
    [Key]
    [Column("id", TypeName = "numeric(18, 0)")]
    public decimal Id { get; set; }

    [Column("name")]
    [StringLength(500)]
    public string? Name { get; set; }

    [Column("isdefault")]
    [StringLength(50)]
    public string? Isdefault { get; set; }

    [Column("gstcode", TypeName = "numeric(18, 0)")]
    public decimal? Gstcode { get; set; }

   }
