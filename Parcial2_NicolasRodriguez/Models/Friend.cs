using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_NicolasRodriguez.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }



        [Required] //primero las condiciones
        [Display(Name = "Nombre")]
        public string Name { get; set; } //luego se muestra que chota



        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Cumpleaños")]
        public DataType Birthday { get; set; }

    }
}
