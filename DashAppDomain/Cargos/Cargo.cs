using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Cargos
{
    public class Cargo : Entity
    {
        public string Atribuicao { get; set; }

        private Cargo() { }

        public Cargo (string atribuicao)
        {
            ValidateValues(atribuicao);
            SetProperties(atribuicao);

        }

        public void Update (string atribuicao)
        {
            ValidateValues(atribuicao);
            SetProperties(atribuicao);
        }

        public void SetProperties (string atribuicao)
        {
            Atribuicao = atribuicao;
        }

        private static void ValidateValues (string atribuicao)
        {
            DomainException.When(string.IsNullOrEmpty(atribuicao), "Cargo é obrigatório");
        }




    }

}
