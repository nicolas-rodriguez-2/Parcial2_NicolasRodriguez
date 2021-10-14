using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_ApiNicolasRodriguez.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }



        [Required] //primero las condiciones
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } //luego se muestra que chota



        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Cumpleaños")]
        public DateTime Birthday { get; set; }

    }
}
