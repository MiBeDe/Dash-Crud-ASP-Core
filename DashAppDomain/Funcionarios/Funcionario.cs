using DashAppDomain.Cargos;
using DashAppDomain.Departamentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Funcionarios
{
    public class Funcionario : Entity
    {
        // Mapeamento Entidades
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string Endereco { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public virtual Departamento Departamento { get; private set; }
        public virtual Cargo Cargo{ get; private set; }
        
        //Construtor Vazio
        private Funcionario() { }

        public Funcionario(string nome, string cpf, string rg, string endereco, string cep, string cidade, string estado, string pais, Cargo cargo, Departamento departamento)
        {
            ValidadeValues(nome, cpf, rg ,endereco, cep, cidade, estado, pais, cargo, departamento);
            SetProperties(nome, cpf, rg, endereco, cep, cidade, estado, pais, cargo, departamento);
        }

        public void Update (string nome, string cpf, string rg, string endereco, string cep, string cidade, string estado, string pais, Cargo cargo, Departamento departamento)
        {
            ValidadeValues(nome, cpf, rg, endereco, cep, cidade, estado, pais, cargo, departamento);
            SetProperties(nome, cpf, rg, endereco, cep, cidade, estado, pais, cargo, departamento);

        }

        //Setando Valores
        private void SetProperties(string nome, string cpf, string rg, string endereco, string cep, string cidade, string estado, string pais, Cargo cargo, Departamento departamento)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            Endereco = endereco;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cargo = cargo;
            Departamento = departamento;
        }

        //Regras de validação
        private static void ValidadeValues (string nome, string cpf, string rg, string endereco, string cep, string cidade, string estado, string pais, Cargo cargo, Departamento departamento)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainException.When(string.IsNullOrEmpty(cpf) && cpf.Length < 14, "CPF Inválido");
            DomainException.When(string.IsNullOrEmpty(rg) && rg.Length < 12, "RG Inváldo");
            DomainException.When(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");
            DomainException.When(string.IsNullOrEmpty(cep) && cep.Length < 9, "CEP Inválido");
            DomainException.When(string.IsNullOrEmpty(cidade), "Cidade é obrigatório");
            DomainException.When(string.IsNullOrEmpty(estado), "Estado é obrigatório");
            DomainException.When(string.IsNullOrEmpty(pais), "País é obrigatório");
            DomainException.When(cargo == null, "Cargo é obrigatório");
            DomainException.When(departamento == null, "Departamento é obrigatório");
        }
    }
}
