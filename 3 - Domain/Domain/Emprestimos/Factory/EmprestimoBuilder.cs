using System;
using Domain.Clientes;

namespace Domain.Emprestimos.Factory
{
    public class EmprestimoBuilder : IEmprestimoBuilder
    {
        private Cliente Cliente { get; set; }
        private DateTime DataDoEmprestimo { get; set; }
        private Guid Id { get; set; }
        private decimal Valor { get; set; }

        public Emprestimo Build() => new Emprestimo(Id, Cliente, DataDoEmprestimo, Valor);

        public EmprestimoBuilder WithCliente(Cliente cliente)
        {
            Cliente = cliente;
            return this;
        }

        public EmprestimoBuilder WithDataDoEmprestimo(DateTime dataDoEmprestimo)
        {
            DataDoEmprestimo = dataDoEmprestimo;
            return this;
        }

        public EmprestimoBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public EmprestimoBuilder WithValor(decimal valor)
        {
            Valor = valor;
            return this;
        }
    }
}