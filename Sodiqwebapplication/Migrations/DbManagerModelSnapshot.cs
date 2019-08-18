﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sodiqwebapplication.Config;

namespace Sodiqwebapplication.Migrations
{
    [DbContext(typeof(DbManager))]
    partial class DbManagerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sodiqwebapplication.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageId");

                    b.Property<long?>("ItemId");

                    b.Property<string>("OtherImagesUrl");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Sodiqwebapplication.Entities.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Author");

                    b.Property<string>("AuthorAvatarUrl");

                    b.Property<bool>("CommentsEnabled");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("IsFeatured");

                    b.Property<int>("IsHeadLine");

                    b.Property<long>("ItemId");

                    b.Property<string>("LargeThumbnail");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("OriginalThumbnail");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PinIconColor");

                    b.Property<int>("PinIconHeight");

                    b.Property<string>("PinIconUrl");

                    b.Property<int>("PinIconWidth");

                    b.Property<string>("SmallThumbnail");

                    b.Property<string>("SubSections");

                    b.Property<string>("SubType");

                    b.Property<string>("Summary");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.Property<string>("WebSite");

                    b.Property<string>("XLargeThumbnail");

                    b.Property<string>("XxLargeThumbnail");

                    b.HasKey("Id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("Sodiqwebapplication.Entities.OldImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageId");

                    b.Property<long?>("OldItemId");

                    b.Property<string>("OtherImagesUrl");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("OldItemId");

                    b.ToTable("OldImage");
                });

            modelBuilder.Entity("Sodiqwebapplication.Entities.OldItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Author");

                    b.Property<string>("AuthorAvatarUrl");

                    b.Property<bool>("CommentsEnabled");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("IsFeatured");

                    b.Property<int>("IsHeadLine");

                    b.Property<long>("ItemId");

                    b.Property<string>("LargeThumbnail");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<string>("OriginalThumbnail");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PinIconColor");

                    b.Property<int>("PinIconHeight");

                    b.Property<string>("PinIconUrl");

                    b.Property<int>("PinIconWidth");

                    b.Property<string>("SmallThumbnail");

                    b.Property<string>("SubSections");

                    b.Property<string>("SubType");

                    b.Property<string>("Summary");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.Property<string>("WebSite");

                    b.Property<string>("XLargeThumbnail");

                    b.Property<string>("XxLargeThumbnail");

                    b.HasKey("Id");

                    b.ToTable("oldItems");
                });

            modelBuilder.Entity("Sodiqwebapplication.Entities.Image", b =>
                {
                    b.HasOne("Sodiqwebapplication.Entities.Item", "Item")
                        .WithMany("Images")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Sodiqwebapplication.Entities.OldImage", b =>
                {
                    b.HasOne("Sodiqwebapplication.Entities.OldItem", "OldItem")
                        .WithMany("Images")
                        .HasForeignKey("OldItemId");
                });
#pragma warning restore 612, 618
        }
    }
}