using System;
using Domain.Clientes;

namespace Domain.Emprestimos
{
    public interface IEmprestimo
    {
        Cliente Cliente { get; }
        DateTime DataDoEmprestimo { get; }
        decimal Valor { get; }
    }
}