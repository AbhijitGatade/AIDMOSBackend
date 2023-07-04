using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("id", TypeName = "numeric(38, 0)")]
    public decimal Id { get; set; }

    [Column("menutext")]
    [StringLength(500)]
    public string? Menutext { get; set; }

    [Column("havesubmenus")]
    public int? Havesubmenus { get; set; }

    [Column("showundermenu", TypeName = "numeric(38, 0)")]
    public decimal? Showundermenu { get; set; }

    [Column("formtoopen")]
    [StringLength(500)]
    public string? Formtoopen { get; set; }

    [Column("sequenceno")]
    public int? Sequenceno { get; set; }

    [Column("icon")]
    [StringLength(500)]
    public string? Icon { get; set; }

}
