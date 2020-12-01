using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HawkSoftContactsApi.Models
{
    public interface IUserContactsContext
    {
        DbSet<UserContact> Contacts { get; set; }

        Task<int> SaveChangesAsync();
    }

    public class UserContactsContext : DbContext, IUserContactsContext
    {
        public DbSet<UserContact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=contacts.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserContact>()
                .Property(e => e.ContactId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserContact>()
                .HasIndex(b => b.Username);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}