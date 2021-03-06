using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        [ForeignKey("EstabelecimentosId")]
        public int EstabelecimentosId { get; set; }
        [JsonIgnore]
        public virtual Estabelecimentos Estabelecimentos { get; set; }
 

    }
}
