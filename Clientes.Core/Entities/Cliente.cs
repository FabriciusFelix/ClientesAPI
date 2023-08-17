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
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }



        // Construtor da classe
        public Cliente(string nome, string sobrenome, string email, DateTime dataNascimento, string endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            CriadoEm = DateTime.Now;
            Ativo = true;
        }
        
        private bool ValidarEmail(string email)
        {
            string regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, regex);
        }

        public void InativaCliente()
        {
            this.Ativo = false;
        }

    }


}
