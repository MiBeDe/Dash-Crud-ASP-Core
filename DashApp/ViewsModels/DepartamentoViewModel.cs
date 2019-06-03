using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashApp.ViewsModels
{
    public class DepartamentoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Departamento é obrigatório")]
        public string Setor { get; set; }
    }
}
