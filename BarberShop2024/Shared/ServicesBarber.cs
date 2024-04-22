using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
public class ServicesBarber
    {
        public int ServiceId { get; set; } // Chave primária

        public required string ServiceName { get; set; }
        public string? ServiceDescription { get; set; }
        public double ServicePrice { get; set; }

        // Chave estrangeira para o User
        public int UserId { get; set; }
        public User? User { get; set; }
    }

}
