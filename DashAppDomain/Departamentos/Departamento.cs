using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Departamentos
{
    public class Departamento : Entity
    {
        public string Setor { get; set; }



        protected Departamento() { }


        public Departamento(string setor)
        {
            ValidateValues(setor);
            SetProperties(setor);
        }

        public void Update(string setor)
        {
            ValidateValues(setor);
            SetProperties(setor);
        }

        private void SetProperties(string setor)
        {
            Setor = setor;
        }

        private static void ValidateValues(string setor)
        {
            DomainException.When(string.IsNullOrEmpty(setor), "Setor é obrigatório");
        }

    }
}
