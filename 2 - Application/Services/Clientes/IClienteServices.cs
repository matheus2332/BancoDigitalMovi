using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Domain.Clientes;
using Dtos.Dto;

namespace Services.Clientes
{
    public interface IClienteServices
    {
        void AlterarOLimiteDeEmprestimoDoCliente(Cliente emprestimoCliente, decimal formDtoValorDoEmprestimo);

        Cliente Autenticar(string username, string senhaInformada);

        Cliente GetById(Guid id);

        ClienteParaEmprestimoDto GetDadosParaEmprestimo(Guid clienteId);
    }
}