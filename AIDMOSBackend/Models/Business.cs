using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("businesses")]
public partial class Business
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id", TypeName = "numeric(18, 0)")]
    public decimal Id { get; set; }

    [Column("regdate", TypeName = "date")]
    public DateTime? Regdate { get; set; }

    [Column("businessname")]
    public string? Businessname { get; set; }

    [Column("ownername")]
    public string? Ownername { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("villageid", TypeName = "numeric(18, 0)")]
    public decimal? Villageid { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("mobileno")]
    [StringLength(50)]
    public string? Mobileno { get; set; }

    [Column("altmobileno")]
    [StringLength(50)]
    public string? Altmobileno { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("createdby", TypeName = "numeric(18, 0)")]
    public decimal? Createdby { get; set; }

    [Column("createdon", TypeName = "datetime")]
    public DateTime? Createdon { get; set; }

    [Column("updatedby", TypeName = "numeric(18, 0)")]
    public decimal? Updatedby { get; set; }

    [Column("updatedon", TypeName = "datetime")]
    public DateTime? Updatedon { get; set; }

    [Column("deletedby", TypeName = "numeric(18, 0)")]
    public decimal? Deletedby { get; set; }

    [Column("deletedon", TypeName = "datetime")]
    public DateTime? Deletedon { get; set; }

    [Column("purchaseentry")]
    [StringLength(50)]
    public string? Purchaseentry { get; set; }

    [Column("saleentry")]
    [StringLength(50)]
    public string? Saleentry { get; set; }

    [Column("businesstype")]
    [StringLength(50)]
    public string? Businesstype { get; set; }

    [Column("businessgstno")]
    public string? Businessgstno { get; set; }

    [Column("businesspanno")]
    public string? Businesspanno { get; set; }

    [Column("fertilizerretailerlicenseno")]
    public string? Fertilizerretailerlicenseno { get; set; }

    [Column("pesticidelicenseno")]
    public string? Pesticidelicenseno { get; set; }

    [Column("seedlicenseno")]
    public string? Seedlicenseno { get; set; }

    [Column("reportfontsize")]
    [StringLength(50)]
    public string? Reportfontsize { get; set; }

    [Column("fertilizerwholesalerlicenseno")]
    public string? Fertilizerwholesalerlicenseno { get; set; }

    [Column("bankname")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Bankname { get; set; }

    [Column("bankaccountno")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Bankaccountno { get; set; }

    [Column("bankifsccode")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Bankifsccode { get; set; }

    [Column("qrcode")]
    [StringLength(500)]
    public string? Qrcode { get; set; }

}
