using BarberShop2024.Server.Data;
using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public class CustomerModel : ICustomerModel
    {
        private readonly DataContext _context;

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteCustomer(int customerId)
        {
            var foundCustomer = _context.Customers.FirstOrDefault(e => e.CustomerId == customerId);
            if (foundCustomer == null) return;

            _context.Customers.Remove(foundCustomer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
