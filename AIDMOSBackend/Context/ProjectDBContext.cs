using System;
using System.Collections.Generic;
using AIDMOSBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AIDMOSBackend.Context;

public partial class ProjectDBContext : DbContext
{
    public ProjectDBContext()
    {
    }

    public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccTransactiontype> AccTransactiontypes { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Financialyear> Financialyears { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Modulemenu> Modulemenus { get; set; }
    public virtual DbSet<Usermodulemapping> Usermodulemappings { get; set; }

    public virtual DbSet<AccGroup> AccGroups { get; set; }
    public virtual DbSet<AccSchedule> AccSchedules { get; set; }
    public virtual DbSet<AccSetting> AccSettings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Taluka> Talukas { get; set; }
    public virtual DbSet<Village> Villages{ get; set; }
    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Company> Companies { get; set;}
    public virtual DbSet<Unit> Units { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=ROHAN\\SQLEXPRESS;Initial Catalog=aidmos;Integrated Security=True;TrustServerCertificate=true;");


}