using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OriginFinancial.CodingChallenge.Infra.Data.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Dependents = table.Column<int>(type: "int", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    HouseOwnershipStatusID = table.Column<int>(type: "int", nullable: true),
                    Income = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusID = table.Column<int>(type: "int", nullable: false),
                    Vehicle = table.Column<int>(type: "int", nullable: false),
                    VehicleYear = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceContract",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AutoInsuranceID = table.Column<int>(type: "int", nullable: false),
                    DisabilityInsuranceID = table.Column<int>(type: "int", nullable: false),
                    HomeInsuranceID = table.Column<int>(type: "int", nullable: false),
                    LifeInsuranceID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceContract", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RiskQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRiskQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RiskQuestionAnswer = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerID = table.Column<Guid>(type: "char(36)", nullable: false),
                    RiskQuestionID = table.Column<int>(type: "int", nullable: false),
                    InsuranceContractID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRiskQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerRiskQuestion_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRiskQuestion_InsuranceContract_InsuranceContractID",
                        column: x => x.InsuranceContractID,
                        principalTable: "InsuranceContract",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRiskQuestion_RiskQuestion_RiskQuestionID",
                        column: x => x.RiskQuestionID,
                        principalTable: "RiskQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRiskQuestion_CustomerID",
                table: "CustomerRiskQuestion",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRiskQuestion_InsuranceContractID",
                table: "CustomerRiskQuestion",
                column: "InsuranceContractID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRiskQuestion_RiskQuestionID",
                table: "CustomerRiskQuestion",
                column: "RiskQuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRiskQuestion");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "InsuranceContract");

            migrationBuilder.DropTable(
                name: "RiskQuestion");
        }
    }
}
