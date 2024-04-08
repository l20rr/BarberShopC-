using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
    public class BookMark
    {
        public int BookMarkId { get; set; } // Adicionando uma propriedade como chave primária

        public DateTime DateBook { get; set; }

        // Chave estrangeira para o Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
