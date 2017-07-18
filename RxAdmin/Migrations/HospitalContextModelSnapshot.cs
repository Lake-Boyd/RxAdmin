using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RxAdmin.Data;

namespace RxAdmin.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RxAdmin.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Specialty");

                    b.HasKey("ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("RxAdmin.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Condition");

                    b.Property<int>("DoctorID");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<int>("Zip");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("RxAdmin.Models.Rx", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Email");

                    b.Property<DateTime>("FillDate");

                    b.Property<int>("PatientID");

                    b.Property<DateTime>("RefillDate");

                    b.Property<int>("RxDose");

                    b.Property<string>("RxName");

                    b.Property<bool>("Text");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("Rx");
                });

            modelBuilder.Entity("RxAdmin.Models.Patient", b =>
                {
                    b.HasOne("RxAdmin.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RxAdmin.Models.Rx", b =>
                {
                    b.HasOne("RxAdmin.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
