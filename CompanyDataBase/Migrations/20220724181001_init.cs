using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDataBase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<decimal>(type: "decimal(20,0)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TypeOfWorkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facilities_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facilities_TypeOfWorks_TypeOfWorkId",
                        column: x => x.TypeOfWorkId,
                        principalTable: "TypeOfWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brigades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfWorkId = table.Column<int>(type: "int", nullable: true),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brigades_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brigades_TypeOfWorks_TypeOfWorkId",
                        column: x => x.TypeOfWorkId,
                        principalTable: "TypeOfWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialUses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingMaterialId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialUses_BuildingMaterials_BuildingMaterialId",
                        column: x => x.BuildingMaterialId,
                        principalTable: "BuildingMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialUses_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialEquipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialEquipments_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brigadier_BrigadeId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<decimal>(type: "decimal(20,0)", maxLength: 15, nullable: true),
                    BrigadeId = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Brigades_BrigadeId",
                        column: x => x.BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Brigades_Brigadier_BrigadeId",
                        column: x => x.Brigadier_BrigadeId,
                        principalTable: "Brigades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BuildingMaterials",
                columns: new[] { "Id", "Measure", "Name" },
                values: new object[,]
                {
                    { 1, "kg", "sand" },
                    { 2, "kg", "cement" },
                    { 3, "pallet", "brick" },
                    { 4, "litres", "oil" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "Vadim", 375111111111m },
                    { 2, "Egor", 375113312211m }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[] { 1, "Minsk, Belarus", "BrusHouse" });

            migrationBuilder.InsertData(
                table: "TypeOfWorks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "reconstruction" },
                    { 2, "building" },
                    { 3, "lining" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "Discriminator", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, 20L, 1, "Employee", "Alex", 1000m },
                    { 2, 21L, 1, "Employee", "Bob", 1100m },
                    { 3, 22L, 1, "Employee", "John", 1200m }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Adress", "ClientId", "Name", "TypeOfWorkId" },
                values: new object[,]
                {
                    { 1, "Minsk, Belarus", 1, "Belact", 1 },
                    { 2, "Minsk, Belarus", 2, "Epam", 2 }
                });

            migrationBuilder.InsertData(
                table: "Brigades",
                columns: new[] { "Id", "FacilityId", "Name", "TypeOfWorkId" },
                values: new object[,]
                {
                    { 1, 1, "brigade of masons", 1 },
                    { 2, 2, "brigade of plasterers", 2 }
                });

            migrationBuilder.InsertData(
                table: "MaterialUses",
                columns: new[] { "Id", "BuildingMaterialId", "Count", "FacilityId" },
                values: new object[,]
                {
                    { 1, 1, 1000L, 1 },
                    { 2, 2, 100L, 2 },
                    { 3, 3, 40L, 2 },
                    { 4, 4, 50L, 2 },
                    { 5, 1, 1000L, 1 },
                    { 6, 2, 400L, 2 }
                });

            migrationBuilder.InsertData(
                table: "SpecialEquipments",
                columns: new[] { "Id", "FacilityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Amkador" },
                    { 2, 1, "Belarus" },
                    { 3, 1, "MAZ" },
                    { 4, 2, "KAMAZ" },
                    { 5, 2, "MAN" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Brigadier_BrigadeId", "CompanyId", "Discriminator", "Name", "Number", "Salary" },
                values: new object[,]
                {
                    { 4, 40L, 2, 1, "Brigadier", "Maxim", 375444874565m, 2000m },
                    { 5, 30L, 1, 1, "Brigadier", "Anton", 375444875745m, 2000m }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "BrigadeId", "CompanyId", "Discriminator", "Name", "Position", "Salary" },
                values: new object[,]
                {
                    { 6, 40L, 2, 1, "Builder", "Nikolai", "plasterer", 1300m },
                    { 7, 40L, 2, 1, "Builder", "Aleksandr", "builder", 1300m },
                    { 8, 40L, 1, 1, "Builder", "Evgeniy", "mason", 1300m },
                    { 9, 40L, 1, 1, "Builder", "Sergei", "mason", 1300m },
                    { 10, 40L, 1, 1, "Builder", "Nikolai", "builder", 1300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_FacilityId",
                table: "Brigades",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigades_TypeOfWorkId",
                table: "Brigades",
                column: "TypeOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BrigadeId",
                table: "Employees",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Brigadier_BrigadeId",
                table: "Employees",
                column: "Brigadier_BrigadeId",
                unique: true,
                filter: "[Brigadier_BrigadeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_ClientId",
                table: "Facilities",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_TypeOfWorkId",
                table: "Facilities",
                column: "TypeOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUses_BuildingMaterialId",
                table: "MaterialUses",
                column: "BuildingMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUses_FacilityId",
                table: "MaterialUses",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialEquipments_FacilityId",
                table: "SpecialEquipments",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "MaterialUses");

            migrationBuilder.DropTable(
                name: "SpecialEquipments");

            migrationBuilder.DropTable(
                name: "Brigades");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "BuildingMaterials");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "TypeOfWorks");
        }
    }
}
