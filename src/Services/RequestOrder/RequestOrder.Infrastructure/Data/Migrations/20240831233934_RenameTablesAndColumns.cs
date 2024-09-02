using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestOrder.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesAndColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Procedures_ProcedureId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Labs_LabId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Patients_PatientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shippers_ShipperId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Technicians_TechnicianId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technicians",
                table: "Technicians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labs",
                table: "Labs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Technicians",
                newName: "Technician");

            migrationBuilder.RenameTable(
                name: "Shippers",
                newName: "Shipper");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Provider");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "Procedure");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Labs",
                newName: "Lab");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "OrderItem");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_OtherPaidDate",
            //    table: "Order",
            //    newName: "OtherPaidDate");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_OtherPaidAmount",
            //    table: "Order",
            //    newName: "OtherPaidAmount");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_MedicarePaidDate",
            //    table: "Order",
            //    newName: "MedicarePaidDate");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_MedicarePaidAmount",
            //    table: "Order",
            //    newName: "MedicarePaidAmount");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_MedicaidPaidDate",
            //    table: "Order",
            //    newName: "MedicaidPaidDate");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_MedicaidPaidAmount",
            //    table: "Order",
            //    newName: "MedicaidPaidAmount");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_LabPaidDate",
            //    table: "Order",
            //    newName: "LabPaidDate");

            //migrationBuilder.RenameColumn(
            //    name: "Payment_LabPaidAmount",
            //    table: "Order",
            //    newName: "LabPaidAmount");

            //migrationBuilder.RenameColumn(
            //    name: "Insurance_InsurancePolicy",
            //    table: "Order",
            //    newName: "InsurancePolicy");

            //migrationBuilder.RenameColumn(
            //    name: "Insurance_InsuranceGroup",
            //    table: "Order",
            //    newName: "InsuranceGroup");

            //migrationBuilder.RenameColumn(
            //    name: "Insurance_InsuranceCompany",
            //    table: "Order",
            //    newName: "InsuranceCompany");

            //migrationBuilder.RenameColumn(
            //    name: "Address_Zip",
            //    table: "Order",
            //    newName: "Zip");

            //migrationBuilder.RenameColumn(
            //    name: "Address_State",
            //    table: "Order",
            //    newName: "State");

            //migrationBuilder.RenameColumn(
            //    name: "Address_Country",
            //    table: "Order",
            //    newName: "Country");

            //migrationBuilder.RenameColumn(
            //    name: "Address_Address1",
            //    table: "Order",
            //    newName: "Address1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TechnicianId",
                table: "Order",
                newName: "IX_Order_TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipperId",
                table: "Order",
                newName: "IX_Order_ShipperId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProviderId",
                table: "Order",
                newName: "IX_Order_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PatientId",
                table: "Order",
                newName: "IX_Order_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_LabId",
                table: "Order",
                newName: "IX_Order_LabId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProcedureId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technician",
                table: "Technician",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipper",
                table: "Shipper",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider",
                table: "Provider",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lab",
                table: "Lab",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Lab_LabId",
                table: "Order",
                column: "LabId",
                principalTable: "Lab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Patient_PatientId",
                table: "Order",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Provider_ProviderId",
                table: "Order",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shipper_ShipperId",
                table: "Order",
                column: "ShipperId",
                principalTable: "Shipper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Technician_TechnicianId",
                table: "Order",
                column: "TechnicianId",
                principalTable: "Technician",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Procedure_ProcedureId",
                table: "OrderItem",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Lab_LabId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Patient_PatientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Provider_ProviderId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shipper_ShipperId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Technician_TechnicianId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Procedure_ProcedureId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technician",
                table: "Technician");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipper",
                table: "Shipper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider",
                table: "Provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lab",
                table: "Lab");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Technician",
                newName: "Technicians");

            migrationBuilder.RenameTable(
                name: "Shipper",
                newName: "Shippers");

            migrationBuilder.RenameTable(
                name: "Provider",
                newName: "Providers");

            migrationBuilder.RenameTable(
                name: "Procedure",
                newName: "Procedures");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Lab",
                newName: "Labs");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProcedureId",
                table: "Items",
                newName: "IX_Items_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "Items",
                newName: "IX_Items_OrderId");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Orders",
                newName: "Address_Zip");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Orders",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "OtherPaidDate",
                table: "Orders",
                newName: "Payment_OtherPaidDate");

            migrationBuilder.RenameColumn(
                name: "OtherPaidAmount",
                table: "Orders",
                newName: "Payment_OtherPaidAmount");

            migrationBuilder.RenameColumn(
                name: "MedicarePaidDate",
                table: "Orders",
                newName: "Payment_MedicarePaidDate");

            migrationBuilder.RenameColumn(
                name: "MedicarePaidAmount",
                table: "Orders",
                newName: "Payment_MedicarePaidAmount");

            migrationBuilder.RenameColumn(
                name: "MedicaidPaidDate",
                table: "Orders",
                newName: "Payment_MedicaidPaidDate");

            migrationBuilder.RenameColumn(
                name: "MedicaidPaidAmount",
                table: "Orders",
                newName: "Payment_MedicaidPaidAmount");

            migrationBuilder.RenameColumn(
                name: "LabPaidDate",
                table: "Orders",
                newName: "Payment_LabPaidDate");

            migrationBuilder.RenameColumn(
                name: "LabPaidAmount",
                table: "Orders",
                newName: "Payment_LabPaidAmount");

            migrationBuilder.RenameColumn(
                name: "InsurancePolicy",
                table: "Orders",
                newName: "Insurance_InsurancePolicy");

            migrationBuilder.RenameColumn(
                name: "InsuranceGroup",
                table: "Orders",
                newName: "Insurance_InsuranceGroup");

            migrationBuilder.RenameColumn(
                name: "InsuranceCompany",
                table: "Orders",
                newName: "Insurance_InsuranceCompany");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Orders",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "Orders",
                newName: "Address_Address1");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TechnicianId",
                table: "Orders",
                newName: "IX_Orders_TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShipperId",
                table: "Orders",
                newName: "IX_Orders_ShipperId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ProviderId",
                table: "Orders",
                newName: "IX_Orders_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PatientId",
                table: "Orders",
                newName: "IX_Orders_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_LabId",
                table: "Orders",
                newName: "IX_Orders_LabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technicians",
                table: "Technicians",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippers",
                table: "Shippers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labs",
                table: "Labs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderId",
                table: "Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Procedures_ProcedureId",
                table: "Items",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Labs_LabId",
                table: "Orders",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Patients_PatientId",
                table: "Orders",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Providers_ProviderId",
                table: "Orders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shippers_ShipperId",
                table: "Orders",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Technicians_TechnicianId",
                table: "Orders",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
