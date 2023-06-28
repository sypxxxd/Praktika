using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Vova
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DevicePart> DevicePart { get; set; }
        public virtual DbSet<FirstDiagnostic> FirstDiagnostic { get; set; }
        public virtual DbSet<PartsToRepair> PartsToRepair { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<Specifications> Specifications { get; set; }
        public virtual DbSet<SpecificationsOfPart> SpecificationsOfPart { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Types> Types { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.phone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Device)
                .WithRequired(e => e.Client1)
                .HasForeignKey(e => e.client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasMany(e => e.FirstDiagnostic)
                .WithRequired(e => e.Device1)
                .HasForeignKey(e => e.device)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Device>()
                .HasMany(e => e.Repair)
                .WithRequired(e => e.Device1)
                .HasForeignKey(e => e.device)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevicePart>()
                .HasMany(e => e.PartsToRepair)
                .WithRequired(e => e.DevicePart)
                .HasForeignKey(e => e.idpart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DevicePart>()
                .HasMany(e => e.SpecificationsOfPart)
                .WithRequired(e => e.DevicePart)
                .HasForeignKey(e => e.idPart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Worker)
                .WithRequired(e => e.Position1)
                .HasForeignKey(e => e.position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Repair>()
                .HasMany(e => e.PartsToRepair)
                .WithRequired(e => e.Repair)
                .HasForeignKey(e => e.idRepair)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specifications>()
                .HasMany(e => e.SpecificationsOfPart)
                .WithRequired(e => e.Specifications)
                .HasForeignKey(e => e.idScpecification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpecificationsOfPart>()
                .Property(e => e.value)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Repair)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Device)
                .WithRequired(e => e.Type1)
                .HasForeignKey(e => e.type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Types>()
                .HasMany(e => e.Device)
                .WithRequired(e => e.Types)
                .HasForeignKey(e => e.type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.percentToRepair)
                .HasPrecision(5, 4);

            modelBuilder.Entity<Worker>()
                .HasMany(e => e.Device)
                .WithOptional(e => e.Worker)
                .HasForeignKey(e => e.master);
        }
    }
}
