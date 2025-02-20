

using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BillWorkDetails> BillWorkDetails { get; set; }
        public DbSet<WorkOrderAdvanceDetails> WorkOrderAdvanceDetails { get; set; }
        public DbSet<WorkOrderAdvanceModeDetails> WorkOrderAdvanceModeDetails { get; set; }
        public DbSet<WorkOrderAlbumSizeDetails1> WorkOrderAlbumSizeDetails { get; set; }
        public DbSet<WorkOrderDetail> WorkOrderDetails { get; set; }
        public DbSet<WorkOrderMaster> WorkOrderMasters { get; set; }
        public DbSet<WorkOrderTaxDetails> WorkOrderTaxDetails { get; set; }
        public DbSet<WorkOrderTimeDetails> WorkOrderTimeDetails { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionMain> TransactionMains { get; set; }
        public DbSet<TransactionStaffDetail> TransactionStaffDetails { get; set; }
        public DbSet<UpdateSubHeadDetail> UpdateSubHeadDetails { get; set; }
        public DbSet<ReceiptMaster> ReceiptMasters { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<AreaMaster> AreaMasters { get; set; }
        public DbSet<CustomerReg> CustomerRegs { get; set; }
        public DbSet<DeliveryMaster> DeliveryMasters { get; set; }
        public DbSet<MachineReg> MachineRegs { get; set; }
        public DbSet<MainHeadReg> MainHeadRegs { get; set; }
        public DbSet<SubHeadConditionMaster> SubHeadConditionMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set primary keys
            modelBuilder.Entity<WorkOrderDetail>().HasKey(w => w.WoDetailId);
            modelBuilder.Entity<WorkOrderMaster>().HasKey(w => w.WorkOrderId);
            modelBuilder.Entity<TransactionDetail>().HasKey(t => t.TransactionDetailsId);
            modelBuilder.Entity<TransactionMain>().HasKey(t => t.VoucherId);
            modelBuilder.Entity<TransactionStaffDetail>().HasKey(t => t.TransactionStaffId);
            modelBuilder.Entity<ReceiptMaster>().HasKey(r => r.ReceiptId);
            modelBuilder.Entity<WorkType>().HasKey(w => w.WorkTypeId);
            modelBuilder.Entity<CustomerReg>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<DeliveryMaster>().HasKey(d => d.DeliveryTypeId);
            modelBuilder.Entity<MachineReg>().HasKey(m => m.MachineId);
            modelBuilder.Entity<MainHeadReg>().HasKey(m => m.MainHeadId);
            modelBuilder.Entity<SubHeadConditionMaster>().HasKey(s => s.Id);

            // Define relationships if required (FK Constraints)
        }
        public DbSet<TaskAssignment> TaskAssignment { get; set; } = default!;
        public DbSet<WorkOrderAdvanceDetails1> WorkOrderAdvanceDetails1 { get; set; } = default!;
    }
}
