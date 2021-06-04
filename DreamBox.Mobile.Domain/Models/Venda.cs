using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Vendas
    {
       
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        public Usuarios usuario { get; set; }
         public string nome { get; set; }
         public  double preco { get; set; }
  
        public DateTime Date { get; set; }

    }
}
