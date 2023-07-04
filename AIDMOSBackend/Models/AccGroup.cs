using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("acc_groups")]
public partial class AccGroup
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    [Key]
    [Column("id", TypeName = "numeric(18, 0)")]
    public decimal Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("srno", TypeName = "numeric(18, 0)")]
    public decimal? Srno { get; set; }

    [Column("scheduleid", TypeName = "numeric(18, 0)")]
    public decimal? Scheduleid { get; set; }

    [Column("groupid", TypeName = "numeric(18, 0)")]
    public decimal? Groupid { get; set; }

    [Column("businessid", TypeName = "numeric(18, 0)")]
    public decimal? Businessid { get; set; }

  }
