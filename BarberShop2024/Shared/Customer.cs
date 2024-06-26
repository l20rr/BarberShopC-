﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop2024.Shared
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Digite o Nome!")]
        public string CustomerName { get; set; }
        public int NIF { get; set; }
        [Required(ErrorMessage = "Digite o email!")]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Digite o telefone!")]
        public string Phone { get; set; }

        // Chave estrangeira para o User
        public int UserId { get; set; }
        public User? User { get; set; }

        // Propriedade de navegação: um Customer pode ter muitas marcações
        public ICollection<BookMark>? BookMarks { get; set; }
    }
}
