using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TravelApp.Models;

namespace TravelApp.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20160502182507_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelApp.Models.Stop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("TripID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("TravelApp.Models.Trip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserName");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("TravelApp.Models.Stop", b =>
                {
                    b.HasOne("TravelApp.Models.Trip")
                        .WithMany()
                        .HasForeignKey("TripID");
                });
        }
    }
}
