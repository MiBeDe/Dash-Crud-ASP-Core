using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashApp.ViewsModels
{
    public class CargoViewModel
    {
        public int Id{ get; set; }
        [Required(ErrorMessage ="Cargo é obrigatório")]
        public string Atribuicao { get; set; }
    }
}
