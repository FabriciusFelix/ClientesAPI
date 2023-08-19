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
        public string Email { get;  private set; }
        public DateTime DataNascimento { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }



        public Cliente(int id, string nome, string sobrenome, string codigoCpf, string email, DateTime dataNascimento, string endereco, bool ativo, DateTime criadoEm)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            if (ValidaCpf(codigoCpf)) { CodigoCpf = codigoCpf; } else { throw new Exception($"CPF Inválido, {codigoCpf}"); }        
            Email = ValidarEmail(email);    
            DataNascimento = dataNascimento;
            Endereco = endereco;
            CriadoEm = DateTime.Now;
            Ativo = ativo;
        }

        public static string ValidarEmail(string email)
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
        public void UpdateCliente(string nome, string sobrenome,string email, string endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = ValidarEmail(email);
            Endereco = endereco;
        }
        public static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();


            return cpf.EndsWith(digito);
           

        }
    }


}
