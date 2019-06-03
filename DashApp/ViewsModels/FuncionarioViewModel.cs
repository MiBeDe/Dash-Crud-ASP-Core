using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashApp.ViewsModels
{
    public class FuncionarioViewModel
    {
        public int Id{ get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "RG é obrigatório")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "País é obrigatório")]
        public string Pais { get; set; }


        public int CargoId { get; set; }
        public string CargoName { get; set; }

        public int DepartamentoId { get; set; }
        public string DepartamentoName { get; set; }


        public IEnumerable<CargoViewModel> Cargos { get; set; }

        public IEnumerable<DepartamentoViewModel> Departamentos { get; set; }

    }
}
