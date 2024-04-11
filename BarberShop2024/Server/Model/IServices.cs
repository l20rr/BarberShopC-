using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public interface IServices
    {
        IEnumerable<ServicesBarber> GetAllServices();
        ServicesBarber GetServicesById(int serviceId);
        Task<ServicesBarber> AddServices(ServicesBarber servicesBarber);
        ServicesBarber UpdateServices(ServicesBarber servicesBarber);
        void DeleteServices(int serviceId);
    }
}
