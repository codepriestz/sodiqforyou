using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sodiqwebapplication.Migrations
{
    public partial class InitializeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<string>(nullable: true),
                    SmallThumbnail = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    OriginalThumbnail = table.Column<string>(nullable: true),
                    LargeThumbnail = table.Column<string>(nullable: true),
                    XLargeThumbnail = table.Column<string>(nullable: true),
                    XxLargeThumbnail = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    IsHeadLine = table.Column<int>(nullable: false),
                    AuthorAvatarUrl = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PinIconColor = table.Column<string>(nullable: true),
                    PinIconUrl = table.Column<string>(nullable: true),
                    PinIconWidth = table.Column<int>(nullable: false),
                    PinIconHeight = table.Column<int>(nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    CommentsEnabled = table.Column<bool>(nullable: false),
                    SubSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "oldItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<string>(nullable: true),
                    SmallThumbnail = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<string>(nullable: true),
                    OriginalThumbnail = table.Column<string>(nullable: true),
                    LargeThumbnail = table.Column<string>(nullable: true),
                    XLargeThumbnail = table.Column<string>(nullable: true),
                    XxLargeThumbnail = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    IsHeadLine = table.Column<int>(nullable: false),
                    AuthorAvatarUrl = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PinIconColor = table.Column<string>(nullable: true),
                    PinIconUrl = table.Column<string>(nullable: true),
                    PinIconWidth = table.Column<int>(nullable: false),
                    PinIconHeight = table.Column<int>(nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    CommentsEnabled = table.Column<bool>(nullable: false),
                    SubSections = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oldItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    OtherImagesUrl = table.Column<string>(nullable: true),
                    ItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OldImage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    OtherImagesUrl = table.Column<string>(nullable: true),
                    OldItemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OldImage_oldItems_OldItemId",
                        column: x => x.OldItemId,
                        principalTable: "oldItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_images_ItemId",
                table: "images",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OldImage_OldItemId",
                table: "OldImage",
                column: "OldItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "OldImage");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "oldItems");
        }
    }
}
