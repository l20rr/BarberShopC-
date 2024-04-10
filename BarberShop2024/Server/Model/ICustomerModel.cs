using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public interface ICustomerModel
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
