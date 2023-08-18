using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clientes.Core.Entities
{
    public class Cliente
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CodigoCpf { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }


        // Construtor da classe

        public Cliente(int id, string nome, string sobrenome, string codigoCpf, string email, DateTime dataNascimento, string endereco, bool ativo, DateTime criadoEm)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            CodigoCpf = codigoCpf;
            Email = ValidarEmail(email);
            DataNascimento = dataNascimento;
            Endereco = endereco;
            CriadoEm = DateTime.Now;
            Ativo = true;
        }

        private string ValidarEmail(string email)
        {
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var valido = Regex.IsMatch(email, regex);

            if (valido)
            {
                return email;
            }
            else throw new Exception ($"E-mail Inválido, {email}");
            
        }

        public void InativaCliente()
        {
            this.Ativo = false;
        }
        public void UpdateCliente(string nome, string sobrenome, string endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
        }
    }


}
