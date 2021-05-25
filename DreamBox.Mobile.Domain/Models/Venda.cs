using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Vendas
    {
        [Key]
        public int Id { get; set; }

        public int usuarioId { get; set; }
        public Usuarios usuario { get; set; }

        public List<Items> Items { get; set; }

        public DateTime date { get; set; }

    }
}
