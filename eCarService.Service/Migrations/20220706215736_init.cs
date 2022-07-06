using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCarService.Service.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalServices",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 40, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServices", x => x.AdditionalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10,1)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_18",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    CarServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.CarServiceId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_21",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    CarBrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CarServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.CarBrandId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_24",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "CarServiceId");
                });

            migrationBuilder.CreateTable(
                name: "CustomOfferRequest",
                columns: table => new
                {
                    CustomReqId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CarServiceId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_2", x => x.CustomReqId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_28",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_29",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "CarServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,1)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CarServiceId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_6",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "CarServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CarServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_17",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "CarServiceId");
                });

            migrationBuilder.CreateTable(
                name: "CarBrandOffer",
                columns: table => new
                {
                    CarBrandOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarBrandId = table.Column<int>(type: "int", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrandOffer", x => x.CarBrandOfferId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_22",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "CarBrandId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_23",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_15",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_16",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    CarBrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_14",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_27",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_30",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "CarBrandId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_5",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "OfferParts",
                columns: table => new
                {
                    OfferPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferParts", x => x.OfferPartId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_25",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_26",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "ReservationsAdditionalServices",
                columns: table => new
                {
                    ResAddServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    AdditionalServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_13", x => x.ResAddServicesId);
                    table.ForeignKey(
                        name: "FK_REFERENCE_19",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                    table.ForeignKey(
                        name: "FK_REFERENCE_20",
                        column: x => x.AdditionalServiceId,
                        principalTable: "AdditionalServices",
                        principalColumn: "AdditionalServiceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBrandOffer_CarBrandId",
                table: "CarBrandOffer",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrandOffer_OfferId",
                table: "CarBrandOffer",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_CarServiceId",
                table: "CarBrands",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_UserId",
                table: "CarServices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOfferRequest_CarServiceId",
                table: "CustomOfferRequest",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOfferRequest_UserId",
                table: "CustomOfferRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferParts_OfferId",
                table: "OfferParts",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferParts_PartId",
                table: "OfferParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarServiceId",
                table: "Offers",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CarServiceId",
                table: "Parts",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OfferId",
                table: "Ratings",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarBrandId",
                table: "Reservations",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OfferId",
                table: "Reservations",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PaymentId",
                table: "Reservations",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsAdditionalServices_AdditionalServiceId",
                table: "ReservationsAdditionalServices",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsAdditionalServices_ReservationId",
                table: "ReservationsAdditionalServices",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBrandOffer");

            migrationBuilder.DropTable(
                name: "CustomOfferRequest");

            migrationBuilder.DropTable(
                name: "OfferParts");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "ReservationsAdditionalServices");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AdditionalServices");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "CarBrands");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
