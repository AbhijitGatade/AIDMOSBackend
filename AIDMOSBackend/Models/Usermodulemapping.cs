using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("usermodulemapping")]
public partial class Usermodulemapping
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Key]
    [Column("id", TypeName = "numeric(18, 0)")]
    public decimal Id { get; set; }

    [Column("userid", TypeName = "numeric(18, 0)")]
    public decimal? UserId { get; set; }

    [Column("moduleid", TypeName = "numeric(38, 0)")]
    public decimal? ModuleId { get; set; }

  }
