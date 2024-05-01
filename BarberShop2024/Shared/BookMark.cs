using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
     public class BookMark
    {
        public int BookMarkId { get; set; } // Chave primária
        [Required(ErrorMessage = "Selecione o serviço!")]
        public string ServicesSelect { get; set; }

        public DateTime DateBook { get; set; }

        // Chave estrangeira para o Customer
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        
    }
}
