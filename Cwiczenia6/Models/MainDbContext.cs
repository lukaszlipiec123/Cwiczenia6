using System;
using Microsoft.EntityFrameworkCore;


namespace Cwiczenia6.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public MainDbContext()
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(m => m.IdMedicament);
                m.Property(m => m.Name).IsRequired().HasMaxLength(100);
                m.Property(m => m.Description).IsRequired().HasMaxLength(100);
                m.Property(m => m.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                    new Medicament {
                        IdMedicament = 1,
                        Name = "Sample Medicament 1",
                        Description = "Sample Description 1",
                        Type = "Type 1"
                    },
                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "Sample Medicament 2",
                        Description = "Sample Description 2",
                        Type = "Type 2"
                    },
                    new Medicament
                    {
                        IdMedicament = 3,
                        Name = "Sample Medicament 3",
                        Description = "Sample Description 3",
                        Type = "Type 3"
                    }
                );

            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.IdDoctor);
                d.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
                d.Property(d => d.LastName).IsRequired().HasMaxLength(100);
                d.Property(d => d.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "JohnDoeMail1"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Dohn",
                        LastName = "Joe",
                        Email = "DohnJoeMail"
                    }
                );

            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.IdPatient);
                p.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
                p.Property(p => p.LastName).IsRequired().HasMaxLength(100);
                p.Property(p => p.BirthDate).IsRequired();

                p.HasData(
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Jan",
                        LastName = "Nowak",
                        BirthDate = DateTime.Parse("2022-03-01")
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Mariusz",
                        LastName = "Kowalski",
                        BirthDate = DateTime.Parse("2022-03-01")
                    },
                    new Patient
                    {
                        IdPatient = 3,
                        FirstName = "Anna",
                        LastName = "Wiśniewska",
                        BirthDate = DateTime.Parse("2022-03-01")
                    }
                );
            });

            modelBuilder.Entity<Prescription_Medicament>(pm =>
            {
                pm.HasKey(pm => new
                {
                    pm.IdMedicament,
                    pm.IdPrescription
                }
                );
                pm.Property(pm => pm.Dose);
                pm.Property(pm => pm.Details).IsRequired().HasMaxLength(100);

                pm.HasOne(pm => pm.Medicament).WithMany(pm => pm.Prescription_Medicaments).HasForeignKey(pm => pm.IdMedicament);
                pm.HasOne(pm => pm.Prescription).WithMany(pm => pm.Prescription_Medicaments).HasForeignKey(pm => pm.IdPrescription);

                pm.HasData(
                    new Prescription_Medicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Details = "Sample Details"
                    }
                );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(p => p.IdPrescription);
                p.Property(p => p.Date).IsRequired();
                p.Property(p => p.DueDate).IsRequired();

                p.HasOne(p => p.Patient).WithMany(p => p.Prescriptions).HasForeignKey(p => p.IdPatient);
                p.HasOne(p => p.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(p => p.IdDoctor);

                p.HasData(
                    new Prescription 
                    { 
                        IdPrescription = 1,
                        Date = DateTime.Parse("2022-03-01"),
                        DueDate = DateTime.Parse("2022-03-01"),
                        IdPatient = 1,
                        IdDoctor = 1,
                    }
                );
            });
        }

    }
}
