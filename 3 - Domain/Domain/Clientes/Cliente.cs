using System;
using System.Collections.Generic;
using Domain.Base;
using Domain.Emprestimos;

namespace Domain.Clientes
{
    public class Cliente : BaseEntity<Guid>, ICliente
    {
        public Cliente()
        {
        }

        public Cliente(Guid id, string cpf, decimal limiteDeEmprestimo, string nome, string usuario, string senha)
        {
            SetId(id);
            SetCpf(cpf);
            SetLimiteDeEmprestimo(limiteDeEmprestimo);
            SetNome(nome);
            SetUsuario(usuario);
            SetSenha(senha);
        }

        public string Cpf { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }
        public decimal LimiteDeEmprestimo { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Usuario { get; private set; }

        public void SetCpf(string cpf)
        {
            Cpf = cpf;
        }

        public void SetLimiteDeEmprestimo(decimal limiteDeEmprestimo)
        {
            LimiteDeEmprestimo = limiteDeEmprestimo;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetSenha(string senha)
        {
            Senha = senha;
        }

        public void SetUsuario(string usuario)
        {
            Usuario = usuario;
        }
    }
}