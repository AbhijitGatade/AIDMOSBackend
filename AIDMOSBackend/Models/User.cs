using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Models;

[Table("users")]
public partial class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("id", TypeName = "numeric(18, 0)")]
    public decimal Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string? Username { get; set; }

    [Column("password")]
    [StringLength(50)]
    public string? Password { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string? Status { get; set; }

    [Column("usertype")]
    [StringLength(50)]
    public string? Usertype { get; set; }

    [Column("businessid", TypeName = "numeric(18, 0)")]
    public decimal? Businessid { get; set; }

    [Column("email")]
    [StringLength(500)]
    public string? Email { get; set; }

    [Column("mobileno")]
    [StringLength(500)]
    public string? Mobileno { get; set; }


    public DataTable GetUserModules(decimal userid, IConfiguration configuration)
    {
        GlobalClass gc = new GlobalClass(configuration);
        string query = "SELECT M.*, ISNULL(UM.id, 0) AS mappingid FROM modules AS M LEFT OUTER JOIN usermodulemapping AS UM ";
        query += "ON M.id = UM.moduleid AND UM.userid = " + userid + " ORDER BY M.srno";
        DataTable dtable = gc.GetDataTable(query);
        return dtable;
    }

}
