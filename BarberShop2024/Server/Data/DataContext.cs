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

            // Adicionando dados iniciais para User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserEmail = "usuario1@example.com",
                    UserName = "Usuário 1",
                    UserPhone = 123456789,
                    UserAdress = "Endereço 1",
                    ShopName = "Loja 1",
                    UserPassword = "senha123",
                },
                new User
                {
                    UserId = 2,
                    UserEmail = "usuario2@example.com",
                    UserName = "Usuário 2",
                    UserPhone = 987654321,
                    UserAdress = "Endereço 2",
                    ShopName = "Loja 2",
                    UserPassword = "senha456",
                });

            // Adicionando dados iniciais para ServicesBarber
            modelBuilder.Entity<ServicesBarber>().HasData(
                new ServicesBarber
                {
                    ServiceId = 1,
                    UserId = 1,
                    ServiceName = "Corte de Cabelo Masculino",
                    ServiceDescription = "Descrição do serviço 1",
                    ServicePrice = 20.00,
                },
                new ServicesBarber
                {
                    ServiceId = 2,
                    UserId = 1,
                    ServiceName = "Corte de Cabelo Feminino",
                    ServiceDescription = "Descrição do serviço 2",
                    ServicePrice = 25.00,
                });

            // Adicionando dados iniciais para Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    UserId = 2,
                    CustomerName = "Cliente 1",
                    NIF = 123456789,
                    CustomerEmail = "cliente1@example.com",
                    Phone = "987654321",
                },
                new Customer
                {
                    CustomerId = 2,
                    UserId = 2,
                    CustomerName = "Cliente 2",
                    NIF = 987654321,
                    CustomerEmail = "cliente2@example.com",
                    Phone = "123456789",
                });

            // Adicionando dados iniciais para BookMark
            modelBuilder.Entity<BookMark>().HasData(
                new BookMark
                {
                    BookMarkId = 1,
                    CustomerId = 1,
                    ServicesSelect = "Corte de Cabelo Masculino",
                    DateBook = DateTime.Now.AddDays(1), // Data de reserva para amanhã
                },
                new BookMark
                {
                    BookMarkId = 2,
                    CustomerId = 2,
                    ServicesSelect = "Corte de Cabelo Feminino",
                    DateBook = DateTime.Now.AddDays(2), // Data de reserva para depois de amanhã
                });
        }

    }
}
