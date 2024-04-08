using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        // Propriedade de navegação: um User pode ter muitos Customers
        public ICollection<Customer> Customers { get; set; }

        // Propriedade de navegação: um User pode ter muitos Services
        public ICollection<ServicesBarber> Services { get; set; }
    }
}
