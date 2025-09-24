
using Microsoft.EntityFrameworkCore;

namespace Final_Project1.Entities
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>().HasOne(x => x.ParentBrand).WithMany(x => x.ChildBrand).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarDetail>()
            .HasOne(x => x.CarBrand)
            .WithMany(x => x.CarDetails)
            .HasForeignKey(x => x.CarBrandId);

            modelBuilder.Entity<CarImage>()
            .HasOne(ci => ci.CarDetail)
            .WithMany(cd => cd.Images)
            .HasForeignKey(ci => ci.CarDetailId)
            .OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<Admin>().HasData(
                
                new Admin()
                {
                    Id = 1,
                    FullName = "Oğuz Selvin",
                    UserName = "admin",
                    Password = "$2a$12$XAKl1Ys7MykMQJT4nma5busReIZMTgBvpuwnJtD0LOOqlZok7gaia",
                    
                    
                }
                
            );
        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<CarBrand> Brands { get; set; }

        public DbSet<CarDetail> Details { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<Rezervation> Rezurations { get; set; }

        public DbSet<Slide> Slides { get; set; }
    }
}
