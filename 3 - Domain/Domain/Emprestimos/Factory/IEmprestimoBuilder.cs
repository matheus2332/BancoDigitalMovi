using System;
using Domain.Clientes;

namespace Domain.Emprestimos.Factory
{
    public interface IEmprestimoBuilder
    {
        Emprestimo Build();

        EmprestimoBuilder WithCliente(Cliente cliente);

        EmprestimoBuilder WithDataDoEmprestimo(DateTime dataDoEmprestimo);

        EmprestimoBuilder WithId(Guid id);

        EmprestimoBuilder WithValor(decimal valor);
    }
}