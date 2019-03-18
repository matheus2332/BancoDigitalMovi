using System;
using Domain.Clientes;
using Xunit;

namespace Tests.Domain
{
    public class EmprestimoTests
    {
        [Fact]
        public void Criar_emprestimo_com_valor_zero()
        {
            var emprestimo = new global::Domain.Emprestimos.Emprestimo(Guid.NewGuid(), new Cliente(), DateTime.Now, 0m);
            Assert.False(emprestimo.IsValid);
        }

        [Fact]
        public void Criar_emprestimo_corretamente()
        {
            var emprestimo = new global::Domain.Emprestimos.Emprestimo(Guid.NewGuid(), new Cliente(), DateTime.Now, 10m);
            Assert.True(emprestimo.IsValid);
        }

        [Fact]
        public void Criar_emprestimo_sem_cliente()
        {
            var emprestimo = new global::Domain.Emprestimos.Emprestimo(Guid.NewGuid(), null, DateTime.Now, 10m);
            Assert.False(emprestimo.IsValid);
        }
    }
}