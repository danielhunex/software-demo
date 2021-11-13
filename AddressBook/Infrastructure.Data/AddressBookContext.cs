using Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AddressBookContext : DbContext
    {

        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);
            modelBuilder.Entity<Contact>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<Contact>()
                .Property(c => c.CreateDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<Contact>()
              .Property(c => c.UpdateDate)
              .ValueGeneratedOnAddOrUpdate()
              .HasComputedColumnSql("getutcdate()");
            base.OnModelCreating(modelBuilder);
        }
    }
}
