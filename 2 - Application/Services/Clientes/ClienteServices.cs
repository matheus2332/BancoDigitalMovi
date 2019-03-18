using System;
using System.Collections.Generic;
using System.Linq;
using Data.Data;
using Data.RepositoryEntity;
using Domain.Clientes;
using Dtos.Dto;

namespace Services.Clientes
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AlterarOLimiteDeEmprestimoDoCliente(Cliente cliente, decimal valorDoEmprestimo)
        {
            cliente.SetLimiteDeEmprestimo(cliente.LimiteDeEmprestimo - valorDoEmprestimo);
        }

        public Cliente Autenticar(string username, string senhaInformada)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(senhaInformada))
                return null;

            var user = _clienteRepository.Get(x => x.Usuario == username).FirstOrDefault();

            if (user == null) return null;
            if (!VerifyPasswordHash(senhaInformada, user.Senha)) return null;

            return user;
        }

        public Cliente GetById(Guid id) => _clienteRepository.Get(x => x.Id == id).FirstOrDefault();

        public ClienteParaEmprestimoDto GetDadosParaEmprestimo(Guid clienteId)
        {
            return _clienteRepository.Get(x => x.Id == clienteId)
                .Select(x => new ClienteParaEmprestimoDto
                {
                    Data = DateTime.Now.ToString("dd/MM/yyyy"),
                    LimiteDisponivel = $"R$ {Math.Round(x.LimiteDeEmprestimo, 2)}",
                    NomeDoCliente = x.Nome
                }).FirstOrDefault();
        }

        private static bool VerifyPasswordHash(string senhaInformada, string senhaDoUsuario)
        {
            if (senhaInformada == null) throw new ArgumentNullException("password");
            return senhaDoUsuario == senhaInformada;
        }
    }
}