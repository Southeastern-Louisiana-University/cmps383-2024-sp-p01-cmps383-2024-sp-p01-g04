using Microsoft.EntityFrameworkCore;
using Selu383.SP24.Api.Dtos;

namespace Selu383.SP24.Api.Hotel
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .Property(x => x.Name)
                .HasMaxLength(150);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Ritz", Address = "100 Pear dr." },
                new Hotel { Id = 2, Name = "Bates", Address = "200 Pear dr." },
                new Hotel { Id = 3, Name = "Four Seasons", Address = "300 Apple dr." },
                new Hotel { Id = 4, Name = "Hotel Cortez", Address = "400 Apple dr." }

            );
        }

    }
}
