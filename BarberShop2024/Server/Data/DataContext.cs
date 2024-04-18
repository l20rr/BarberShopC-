using BarberShop2024.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BarberShop2024.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServicesBarber> ServicesBarbers { get; set; }
        public DbSet<BookMark> BookMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração dos relacionamentos

            // Relacionamento: User -> Customer (um User pode ter muitos Customers)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Customers)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Excluímos em cascata se um usuário for excluído

            // Relacionamento: User -> ServicesBarber (um User pode ter muitos Services)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Services)
                .WithOne(sb => sb.User)
                .HasForeignKey(sb => sb.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Excluímos em cascata se um usuário for excluído

            // Relacionamento: Customer -> BookMark (um Customer pode ter muitas marcações)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.BookMarks)
                .WithOne(bm => bm.Customer)
                .HasForeignKey(bm => bm.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Restringimos a exclusão em cascata para evitar conflitos

            // Definir a chave primária para ServicesBarber
            modelBuilder.Entity<ServicesBarber>()
                .HasKey(sb => sb.ServiceId);
        }

    }
}
