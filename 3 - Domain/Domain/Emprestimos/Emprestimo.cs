using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Domain.Base;
using Domain.Clientes;

namespace Domain.Emprestimos
{
    public class Emprestimo : BaseEntity<Guid>, IEmprestimo
    {
        public Emprestimo()
        {
        }

        public Emprestimo(Guid id, Cliente cliente, DateTime dataDoEmprestimo, decimal valor)
        {
            SetId(id);
            SetCliente(cliente);
            SetDataDoEmprestimo(dataDoEmprestimo);
            SetValor(valor);
        }

        public Cliente Cliente { get; private set; }

        public Guid ClienteId { get; private set; }
        public DateTime DataDoEmprestimo { get; private set; }
        public decimal Valor { get; private set; }

        public void SetCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                AddErro("O cliente não foi informado");
                return;
            }

            Cliente = cliente;
            ClienteId = cliente.Id;
        }

        public void SetDataDoEmprestimo(DateTime dataDoEmprestimo)
        {
            DataDoEmprestimo = dataDoEmprestimo;
        }

        public void SetValor(decimal valor)
        {
            if (valor <= 0)
            {
                AddErro("O valor do emprestimo deve ser maior que 0.");
                return;
            }
            Valor = valor;
        }
    }
}