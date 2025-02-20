using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaMasters",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMasters", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "BillWorkDetails",
                columns: table => new
                {
                    BillWorkDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillWorkDetails", x => x.BillWorkDetailId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRegs",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudioName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    CustomerTypeId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    WhatsappNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRegs", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMasters",
                columns: table => new
                {
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMasters", x => x.DeliveryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MachineRegs",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPaperWidth = table.Column<float>(type: "real", nullable: true),
                    MaxPaperHeight = table.Column<float>(type: "real", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineRegs", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "MainHeadRegs",
                columns: table => new
                {
                    MainHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Custom = table.Column<int>(type: "int", nullable: true),
                    RemarkStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainHeadRegs", x => x.MainHeadId);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptMasters",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNo = table.Column<int>(type: "int", nullable: true),
                    VoucherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptMasters", x => x.ReceiptId);
                });

            migrationBuilder.CreateTable(
                name: "SubHeadConditionMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainHeadId = table.Column<int>(type: "int", nullable: true),
                    MaxPage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubHeadConditionMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDetails",
                columns: table => new
                {
                    TransactionDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    AccountHeadId = table.Column<int>(type: "int", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    DrCr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetails", x => x.TransactionDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMains",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voucherno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TallyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMains", x => x.VoucherId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionStaffDetails",
                columns: table => new
                {
                    TransactionStaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    Mode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionStaffDetails", x => x.TransactionStaffId);
                });

            migrationBuilder.CreateTable(
                name: "UpdateSubHeadDetails",
                columns: table => new
                {
                    UpdateSubHeadDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubHeadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateSubHeadDetails", x => x.UpdateSubHeadDetailId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderAdvanceDetails",
                columns: table => new
                {
                    WorkOrderAdvanceDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    AdvanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvanceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderAdvanceDetails", x => x.WorkOrderAdvanceDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderAlbumSizeDetails",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderAlbumSizeDetails", x => x.WorkOrderId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderDetails",
                columns: table => new
                {
                    WoDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WoStatus = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    WoDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WoTime = table.Column<float>(type: "real", nullable: true),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CTime = table.Column<float>(type: "real", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    WorkOrderId = table.Column<int>(type: "int", nullable: true),
                    WorkflowNo = table.Column<int>(type: "int", nullable: true),
                    CStatus = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderDetails", x => x.WoDetailId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderMasters",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    WorkTypeId = table.Column<int>(type: "int", nullable: true),
                    NoOfPhoto = table.Column<int>(type: "int", nullable: true),
                    WDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkStatus = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: true),
                    CStatus = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    NoOfCopies = table.Column<int>(type: "int", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true),
                    WNo = table.Column<int>(type: "int", nullable: true),
                    SeId = table.Column<int>(type: "int", nullable: true),
                    OrderVia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderMasters", x => x.WorkOrderId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTaxDetails",
                columns: table => new
                {
                    WorkOrderTaxDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTaxDetails", x => x.WorkOrderTaxDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTimeDetails",
                columns: table => new
                {
                    WorkOrderTimeDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTimeDetails", x => x.WorkOrderTimeDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTypes",
                columns: table => new
                {
                    WorkTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialOrNot = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTypes", x => x.WorkTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignment",
                columns: table => new
                {
                    TaskAssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkOrderAlbumSizeDetails1WorkOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignment", x => x.TaskAssignmentId);
                    table.ForeignKey(
                        name: "FK_TaskAssignment_WorkOrderAlbumSizeDetails_WorkOrderAlbumSizeDetails1WorkOrderId",
                        column: x => x.WorkOrderAlbumSizeDetails1WorkOrderId,
                        principalTable: "WorkOrderAlbumSizeDetails",
                        principalColumn: "WorkOrderId");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderAdvanceModeDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    DetailInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderAdvanceModeDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_WorkOrderAdvanceModeDetails_WorkOrderAlbumSizeDetails_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrderAlbumSizeDetails",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignment_WorkOrderAlbumSizeDetails1WorkOrderId",
                table: "TaskAssignment",
                column: "WorkOrderAlbumSizeDetails1WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderAdvanceModeDetails_WorkOrderId",
                table: "WorkOrderAdvanceModeDetails",
                column: "WorkOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaMasters");

            migrationBuilder.DropTable(
                name: "BillWorkDetails");

            migrationBuilder.DropTable(
                name: "CustomerRegs");

            migrationBuilder.DropTable(
                name: "DeliveryMasters");

            migrationBuilder.DropTable(
                name: "MachineRegs");

            migrationBuilder.DropTable(
                name: "MainHeadRegs");

            migrationBuilder.DropTable(
                name: "ReceiptMasters");

            migrationBuilder.DropTable(
                name: "SubHeadConditionMasters");

            migrationBuilder.DropTable(
                name: "TaskAssignment");

            migrationBuilder.DropTable(
                name: "TransactionDetails");

            migrationBuilder.DropTable(
                name: "TransactionMains");

            migrationBuilder.DropTable(
                name: "TransactionStaffDetails");

            migrationBuilder.DropTable(
                name: "UpdateSubHeadDetails");

            migrationBuilder.DropTable(
                name: "WorkOrderAdvanceDetails");

            migrationBuilder.DropTable(
                name: "WorkOrderAdvanceModeDetails");

            migrationBuilder.DropTable(
                name: "WorkOrderDetails");

            migrationBuilder.DropTable(
                name: "WorkOrderMasters");

            migrationBuilder.DropTable(
                name: "WorkOrderTaxDetails");

            migrationBuilder.DropTable(
                name: "WorkOrderTimeDetails");

            migrationBuilder.DropTable(
                name: "WorkTypes");

            migrationBuilder.DropTable(
                name: "WorkOrderAlbumSizeDetails");
        }
    }
}
