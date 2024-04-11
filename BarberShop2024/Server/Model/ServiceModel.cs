using BarberShop2024.Server.Data;
using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public class ServiceModel : IServices
    {
        private readonly DataContext _context;
        public async Task<ServicesBarber> AddServices(ServicesBarber servicesBarber)
        {
            var result = await _context.ServicesBarbers.AddAsync(servicesBarber);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteServices(int serviceId)
        {
            var foundService = _context.ServicesBarbers.FirstOrDefault(e => e.ServiceId == serviceId);
            if (foundService == null) return;

            _context.ServicesBarbers.Remove(foundService);
            _context.SaveChanges();
        }

        public IEnumerable<ServicesBarber> GetAllServices()
        {
            return _context.ServicesBarbers;
        }

        public ServicesBarber GetServicesById(int serviceId)
        {
            return _context.ServicesBarbers.FirstOrDefault(c => c.ServiceId == serviceId);
        }

        public ServicesBarber UpdateServices(ServicesBarber servicesBarber)
        {
            throw new NotImplementedException();
        }
    }
}
