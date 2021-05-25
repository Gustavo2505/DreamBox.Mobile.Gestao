using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeEstabelecimento { get; set; }
        public double Valor { get; set; }

        public string Status { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public List<Vendas> Vendas { get; set; }
    }
}
