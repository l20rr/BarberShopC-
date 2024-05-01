using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
    public class CombinedData
    {
        public int CustomerId { get; set; }
        public int BookMarkId { get; set; }
        public DateTime DateBook { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string ServicesSelect { get; set; }
        public int UserId { get; set; }
    }
}
