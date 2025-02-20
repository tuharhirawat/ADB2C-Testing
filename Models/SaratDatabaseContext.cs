using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Sarat_Proj.Models;

public partial class SaratDatabaseContext : DbContext
{
    public SaratDatabaseContext()
    {
    }

    public SaratDatabaseContext(DbContextOptions<SaratDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accountheadmaster> Accountheadmasters { get; set; }

    public virtual DbSet<Albumsizedetail> Albumsizedetails { get; set; }

    public virtual DbSet<Areamaster> Areamasters { get; set; }

    public virtual DbSet<Billworkdetail> Billworkdetails { get; set; }

    public virtual DbSet<Customerreg> Customerregs { get; set; }

    public virtual DbSet<Deliverymaster> Deliverymasters { get; set; }

    public virtual DbSet<Deliverymode> Deliverymodes { get; set; }

    public virtual DbSet<Departmentmaster> Departmentmasters { get; set; }

    public virtual DbSet<Machinereg> Machineregs { get; set; }

    public virtual DbSet<Mainheadreg> Mainheadregs { get; set; }

    public virtual DbSet<Receiptmaster> Receiptmasters { get; set; }

    public virtual DbSet<Referencedetailsmaster> Referencedetailsmasters { get; set; }

    public virtual DbSet<Referencetypemaster> Referencetypemasters { get; set; }

    public virtual DbSet<Subheadconditionmaster> Subheadconditionmasters { get; set; }

    public virtual DbSet<Subheaddetail> Subheaddetails { get; set; }

    public virtual DbSet<Taxmaster> Taxmasters { get; set; }

    public virtual DbSet<Transactiondetail> Transactiondetails { get; set; }

    public virtual DbSet<Transactionmain> Transactionmains { get; set; }

    public virtual DbSet<Transactionstaffdetail> Transactionstaffdetails { get; set; }

    public virtual DbSet<Workorderadvancedetail> Workorderadvancedetails { get; set; }

    public virtual DbSet<Workorderadvancemodedetail> Workorderadvancemodedetails { get; set; }

    public virtual DbSet<Workorderalbumsizedetail> Workorderalbumsizedetails { get; set; }

    public virtual DbSet<Workorderdetail> Workorderdetails { get; set; }

    public virtual DbSet<Workordermaster> Workordermasters { get; set; }

    public virtual DbSet<Workordertaxdetail> Workordertaxdetails { get; set; }

    public virtual DbSet<Workordertimedetail> Workordertimedetails { get; set; }

    public virtual DbSet<Worktype> Worktypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=sarat_database;user id=root;password=root;sslmode=None", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.5.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Accountheadmaster>(entity =>
        {
            entity.HasKey(e => e.Accountheadid).HasName("PRIMARY");

            entity.ToTable("accountheadmaster");

            entity.Property(e => e.Accountheadid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Accountheadname).HasMaxLength(255);
            entity.Property(e => e.BranchId).HasColumnType("int(11)");
            entity.Property(e => e.Groupid).HasColumnType("int(11)");
            entity.Property(e => e.Type).HasMaxLength(255);
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("TypeID");
        });

        modelBuilder.Entity<Albumsizedetail>(entity =>
        {
            entity.HasKey(e => e.Sizeid).HasName("PRIMARY");

            entity.ToTable("albumsizedetails");

            entity.Property(e => e.Sizeid)
                .ValueGeneratedNever()
                .HasColumnType("int(15)")
                .HasColumnName("sizeid");
            entity.Property(e => e.Size)
                .HasMaxLength(250)
                .HasColumnName("size");
        });

        modelBuilder.Entity<Areamaster>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PRIMARY");

            entity.ToTable("areamaster");

            entity.Property(e => e.AreaId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("AreaID");
            entity.Property(e => e.AreaName).HasMaxLength(255);
        });

        modelBuilder.Entity<Billworkdetail>(entity =>
        {
            entity.HasKey(e => e.Billid).HasName("PRIMARY");

            entity.ToTable("billworkdetails");

            entity.Property(e => e.Billid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Workorderid).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Customerreg>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("PRIMARY");

            entity.ToTable("customerreg");

            entity.Property(e => e.Customerid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Address1).HasMaxLength(2500);
            entity.Property(e => e.Address2).HasMaxLength(2500);
            entity.Property(e => e.Address3).HasMaxLength(2500);
            entity.Property(e => e.Area)
                .HasMaxLength(10)
                .HasColumnName("area");
            entity.Property(e => e.Branchid).HasColumnType("int(11)");
            entity.Property(e => e.Categoryid).HasColumnType("int(11)");
            entity.Property(e => e.CustomerTypeid).HasColumnType("int(10)");
            entity.Property(e => e.Customername).HasMaxLength(1000);
            entity.Property(e => e.Discount).HasColumnType("double(15,2)");
            entity.Property(e => e.Email).HasMaxLength(2500);
            entity.Property(e => e.Mobile).HasMaxLength(500);
            entity.Property(e => e.Mode)
                .HasColumnType("int(10)")
                .HasColumnName("MODE");
            entity.Property(e => e.Phoneno).HasMaxLength(500);
            entity.Property(e => e.RateType).HasMaxLength(25);
            entity.Property(e => e.Regionid).HasColumnType("int(10)");
            entity.Property(e => e.Remarks).HasMaxLength(5000);
            entity.Property(e => e.Staffid).HasColumnType("int(11)");
            entity.Property(e => e.State)
                .HasMaxLength(2500)
                .HasColumnName("STATE");
            entity.Property(e => e.Studioname).HasMaxLength(1000);
            entity.Property(e => e.Typeid).HasColumnType("int(10)");
            entity.Property(e => e.Whatsappno)
                .HasMaxLength(20)
                .HasColumnName("whatsappno");
        });

        modelBuilder.Entity<Deliverymaster>(entity =>
        {
            entity.HasKey(e => e.Deliverytypeid).HasName("PRIMARY");

            entity.ToTable("deliverymaster");

            entity.Property(e => e.Deliverytypeid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Deliveryname).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
        });

        modelBuilder.Entity<Deliverymode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("deliverymode");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Departmentmaster>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("PRIMARY");

            entity.ToTable("departmentmaster");

            entity.Property(e => e.Departmentid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Departmentname).HasMaxLength(255);
            entity.Property(e => e.Noofwork).HasColumnType("int(11)");
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Slno)
                .HasColumnType("int(11)")
                .HasColumnName("slno");
            entity.Property(e => e.Status).HasColumnType("int(11)");
            entity.Property(e => e.Webdisplay)
                .HasColumnType("int(5)")
                .HasColumnName("webdisplay");
            entity.Property(e => e.Woeditstatus)
                .HasColumnType("int(11)")
                .HasColumnName("woeditstatus");
        });

        modelBuilder.Entity<Machinereg>(entity =>
        {
            entity.HasKey(e => e.Machineid).HasName("PRIMARY");

            entity.ToTable("machinereg");

            entity.Property(e => e.Machineid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Imagepath).HasMaxLength(255);
            entity.Property(e => e.Machinename).HasMaxLength(255);
        });

        modelBuilder.Entity<Mainheadreg>(entity =>
        {
            entity.HasKey(e => e.Mainheadid).HasName("PRIMARY");

            entity.ToTable("mainheadreg");

            entity.Property(e => e.Mainheadid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Custom)
                .HasColumnType("int(5)")
                .HasColumnName("custom");
            entity.Property(e => e.Discount).HasColumnType("int(10)");
            entity.Property(e => e.Headname).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.Remarkstatus)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(5)")
                .HasColumnName("remarkstatus");
        });

        modelBuilder.Entity<Receiptmaster>(entity =>
        {
            entity.HasKey(e => e.Receiptid).HasName("PRIMARY");

            entity.ToTable("receiptmaster");

            entity.Property(e => e.Receiptid)
                .ValueGeneratedNever()
                .HasColumnType("int(20)");
            entity.Property(e => e.Receiptno).HasColumnType("int(50)");
            entity.Property(e => e.Voucherid).HasColumnType("int(20)");
        });

        modelBuilder.Entity<Referencedetailsmaster>(entity =>
        {
            entity.HasKey(e => e.Referenceid).HasName("PRIMARY");

            entity.ToTable("referencedetailsmaster");

            entity.Property(e => e.Referenceid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("referenceid");
            entity.Property(e => e.Amount)
                .HasColumnType("double(200,0)")
                .HasColumnName("amount");
            entity.Property(e => e.Branchid)
                .HasColumnType("int(11)")
                .HasColumnName("branchid");
            entity.Property(e => e.Custid)
                .HasColumnType("int(11)")
                .HasColumnName("CUSTID");
            entity.Property(e => e.Referenceno)
                .HasMaxLength(100)
                .HasColumnName("referenceno");
            entity.Property(e => e.Referencetypeid)
                .HasColumnType("double(100,0)")
                .HasColumnName("referencetypeid");
            entity.Property(e => e.Voucherid)
                .HasMaxLength(100)
                .HasColumnName("voucherid");
        });

        modelBuilder.Entity<Referencetypemaster>(entity =>
        {
            entity.HasKey(e => e.Referencetypeid).HasName("PRIMARY");

            entity.ToTable("referencetypemaster");

            entity.Property(e => e.Referencetypeid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Referencetype)
                .HasMaxLength(20)
                .HasColumnName("referencetype");
        });

        modelBuilder.Entity<Subheadconditionmaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subheadconditionmaster");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Extrarate).HasMaxLength(255);
            entity.Property(e => e.Mainheadid).HasColumnType("int(11)");
            entity.Property(e => e.Maxpage).HasMaxLength(255);
            entity.Property(e => e.Mode).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Subheaddetail>(entity =>
        {
            entity.HasKey(e => e.Subheadid).HasName("PRIMARY");

            entity.ToTable("subheaddetails");

            entity.Property(e => e.Subheadid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Details)
                .HasMaxLength(10000)
                .HasColumnName("details");
            entity.Property(e => e.Machineid).HasColumnType("int(11)");
            entity.Property(e => e.Mainheadid).HasColumnType("int(11)");
            entity.Property(e => e.Mode)
                .HasColumnType("int(10)")
                .HasColumnName("mode");
            entity.Property(e => e.Parentsubheadid)
                .HasColumnType("int(2)")
                .HasColumnName("parentsubheadid");
            entity.Property(e => e.Ratemode)
                .HasColumnType("int(4)")
                .HasColumnName("ratemode");
            entity.Property(e => e.Status).HasColumnType("int(11)");
            entity.Property(e => e.Subhead).HasMaxLength(255);
        });

        modelBuilder.Entity<Taxmaster>(entity =>
        {
            entity.HasKey(e => e.Taxid).HasName("PRIMARY");

            entity.ToTable("taxmaster");

            entity.Property(e => e.Taxid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Mode)
                .HasColumnType("int(5)")
                .HasColumnName("mode");
            entity.Property(e => e.Taxname).HasMaxLength(255);
            entity.Property(e => e.Taxper).HasMaxLength(255);
            entity.Property(e => e.Wef).HasColumnName("wef");
        });

        modelBuilder.Entity<Transactiondetail>(entity =>
        {
            entity.HasKey(e => e.Transactiondetailsid).HasName("PRIMARY");

            entity.ToTable("transactiondetails");

            entity.Property(e => e.Transactiondetailsid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.AccountHeadId).HasColumnType("int(11)");
            entity.Property(e => e.Amount)
                .HasColumnType("double(50,4)")
                .HasColumnName("amount");
            entity.Property(e => e.DrCr).HasMaxLength(255);
            entity.Property(e => e.Narration).HasColumnType("text");
            entity.Property(e => e.Voucherid).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Transactionmain>(entity =>
        {
            entity.HasKey(e => e.Voucherid).HasName("PRIMARY");

            entity.ToTable("transactionmain");

            entity.Property(e => e.Voucherid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.BranchId)
                .HasColumnType("int(11)")
                .HasColumnName("BranchID");
            entity.Property(e => e.Mode).HasMaxLength(20);
            entity.Property(e => e.Tallyid).HasColumnType("int(11)");
            entity.Property(e => e.Voucherno).HasMaxLength(255);
        });

        modelBuilder.Entity<Transactionstaffdetail>(entity =>
        {
            entity.HasKey(e => e.Transactionstaffid).HasName("PRIMARY");

            entity.ToTable("transactionstaffdetails");

            entity.Property(e => e.Transactionstaffid)
                .ValueGeneratedNever()
                .HasColumnType("int(20)");
            entity.Property(e => e.Mode).HasColumnType("int(5)");
            entity.Property(e => e.Staffid).HasColumnType("int(20)");
            entity.Property(e => e.Voucherid).HasColumnType("int(20)");
        });

        modelBuilder.Entity<Workorderadvancedetail>(entity =>
        {
            entity.HasKey(e => e.Referencetypeid).HasName("PRIMARY");

            entity.ToTable("workorderadvancedetails");

            entity.Property(e => e.Referencetypeid)
                .ValueGeneratedNever()
                .HasColumnType("int(15)");
            entity.Property(e => e.Amount).HasColumnType("int(15)");
            entity.Property(e => e.Voucherid).HasColumnType("int(15)");
            entity.Property(e => e.Workorderid).HasColumnType("int(15)");
        });

        modelBuilder.Entity<Workorderadvancemodedetail>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PRIMARY");

            entity.ToTable("workorderadvancemodedetails");

            entity.Property(e => e.Workorderid)
                .ValueGeneratedNever()
                .HasColumnType("int(15)");
            entity.Property(e => e.Accountheadid).HasColumnType("int(15)");
            entity.Property(e => e.Mode).HasColumnType("int(5)");
        });

        modelBuilder.Entity<Workorderalbumsizedetail>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PRIMARY");

            entity.ToTable("workorderalbumsizedetails");

            entity.Property(e => e.Workorderid)
                .ValueGeneratedNever()
                .HasColumnType("int(20)")
                .HasColumnName("workorderid");
            entity.Property(e => e.Sizeid)
                .HasColumnType("int(20)")
                .HasColumnName("sizeid");
        });

        modelBuilder.Entity<Workorderdetail>(entity =>
        {
            entity.HasKey(e => e.Wodetailid).HasName("PRIMARY");

            entity.ToTable("workorderdetails");

            entity.Property(e => e.Wodetailid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Cstatus)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("cstatus");
            entity.Property(e => e.Departmentid).HasColumnType("int(11)");
            entity.Property(e => e.Descr)
                .HasMaxLength(225)
                .HasColumnName("descr");
            entity.Property(e => e.Staffid).HasColumnType("int(11)");
            entity.Property(e => e.Workflowno)
                .HasColumnType("int(15)")
                .HasColumnName("workflowno");
            entity.Property(e => e.Workorderid).HasColumnType("int(11)");
            entity.Property(e => e.Wostatus).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Workordermaster>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PRIMARY");

            entity.ToTable("workordermaster");

            entity.Property(e => e.Workorderid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Branchid).HasColumnType("int(11)");
            entity.Property(e => e.Cstatus).HasColumnType("int(11)");
            entity.Property(e => e.Customerid).HasColumnType("int(11)");
            entity.Property(e => e.Deliverytypeid).HasColumnType("int(11)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Dtime).HasMaxLength(255);
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Machineid)
                .HasColumnType("int(11)")
                .HasColumnName("machineid");
            entity.Property(e => e.Noofcopies)
                .HasColumnType("int(11)")
                .HasColumnName("noofcopies");
            entity.Property(e => e.Noofphoto).HasColumnType("int(11)");
            entity.Property(e => e.Ordervia).HasMaxLength(100);
            entity.Property(e => e.Remarks).HasColumnType("text");
            entity.Property(e => e.SeId)
                .HasColumnType("int(5)")
                .HasColumnName("SE_ID");
            entity.Property(e => e.Staffid)
                .HasColumnType("int(11)")
                .HasColumnName("staffid");
            entity.Property(e => e.Type).HasColumnType("int(11)");
            entity.Property(e => e.Wno)
                .HasColumnType("int(25)")
                .HasColumnName("wno");
            entity.Property(e => e.Workorderno).HasMaxLength(300);
            entity.Property(e => e.Workstatus).HasColumnType("int(11)");
            entity.Property(e => e.Worktypeid).HasColumnType("int(11)");
            entity.Property(e => e.Wtime).HasMaxLength(255);
        });

        modelBuilder.Entity<Workordertaxdetail>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PRIMARY");

            entity.ToTable("workordertaxdetails");

            entity.Property(e => e.Workorderid)
                .ValueGeneratedNever()
                .HasColumnType("int(15)")
                .HasColumnName("workorderid");
            entity.Property(e => e.Amount)
                .HasColumnType("double(15,2)")
                .HasColumnName("amount");
            entity.Property(e => e.Taxid)
                .HasColumnType("int(20)")
                .HasColumnName("taxid");
        });

        modelBuilder.Entity<Workordertimedetail>(entity =>
        {
            entity.HasKey(e => e.Workorderid).HasName("PRIMARY");

            entity.ToTable("workordertimedetails");

            entity.Property(e => e.Workorderid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Rbdate).HasColumnName("rbdate");
            entity.Property(e => e.Rbtime)
                .HasMaxLength(255)
                .HasColumnName("rbtime");
            entity.Property(e => e.Ybdate).HasColumnName("ybdate");
            entity.Property(e => e.Ybtime)
                .HasMaxLength(255)
                .HasColumnName("ybtime");
        });

        modelBuilder.Entity<Worktype>(entity =>
        {
            entity.HasKey(e => e.Worktypeid).HasName("PRIMARY");

            entity.ToTable("worktype");

            entity.Property(e => e.Worktypeid)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Commercialornot)
                .HasColumnType("int(5)")
                .HasColumnName("commercialornot");
            entity.Property(e => e.Discount)
                .HasColumnType("int(5)")
                .HasColumnName("discount");
            entity.Property(e => e.Typename).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
