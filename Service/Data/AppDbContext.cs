using Microsoft.EntityFrameworkCore;
using Project.Service.Models;

namespace Project.Service.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleMake>(entity =>
            {
                entity.ToTable("Makes");

                entity.Property(e => e.Id)
                    .HasColumnName("MakeId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasMany(e => e.Models)
                    .WithOne(e => e.Make)
                    .HasForeignKey(e => e.MakeId);
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("Models");

                entity.Property(e => e.Id)
                    .HasColumnName("ModelId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Abrv)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(e => e.Make)
                    .WithMany(e => e.Models)
                    .HasForeignKey(e => e.MakeId)
                    .IsRequired();
            });
        }
    }
}
