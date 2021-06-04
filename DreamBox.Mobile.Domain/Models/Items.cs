using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DreamBox.Mobile.Domain.Models
{
    public class Items
    {

        [Key]
        public int Id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
    }
}
