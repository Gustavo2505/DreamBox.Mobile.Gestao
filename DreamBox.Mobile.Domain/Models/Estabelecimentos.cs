using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Estabelecimentos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public string ValorCobrado { get; set; }
        public string Tipo { get; set; }

      public List<Usuarios> Usuarios { get; set; }
        

   

    }
}
