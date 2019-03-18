using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Repositories;
using Data.RepositoryEntity;
using Domain.Clientes;
using Domain.Emprestimos;
using Domain.Emprestimos.Factory;
using Dtos.Dto;
using FluentValidation.TestHelper;
using Moq;
using Services.Clientes;
using Services.Emprestimos;
using Services.UbsServices;
using Services.UbsServices.Validator;
using Xunit;

namespace Tests.Services
{
    public class EmprestimoServicesTests
    {
        private Guid ClienteId => Guid.NewGuid();

        [Fact]
        public void Criar_emprestimo_corretamente()
        {
            var formDto = GetServiceEmprestimo().Save(new EmprestimoFormDto
            {
                ValorDoEmprestimo = 100,
                ClienteId = ClienteId,
                DataDoEmprestimo = DateTime.Now,
            });

            Assert.True(formDto.ValidationSucceeded);
        }

        [Fact]
        public void Criar_emprestimo_com_cliente_sem_limite_disponivel()
        {
            var formDto = GetServiceEmprestimo().Save(new EmprestimoFormDto
            {
                ValorDoEmprestimo = 600,
                ClienteId = ClienteId,
                DataDoEmprestimo = DateTime.Now,
            });

            Assert.False(formDto.ValidationSucceeded);
        }

        [Fact]
        public void Criar_emprestimo_com_valor_igual_zero()
        {
            var formDto = GetServiceEmprestimo().Save(new EmprestimoFormDto
            {
                ValorDoEmprestimo = 0,
                ClienteId = ClienteId,
                DataDoEmprestimo = DateTime.Now,
            });

            Assert.False(formDto.ValidationSucceeded);
        }

        [Fact]
        public void Get_emprestimos()
        {
            var emprestimos = GetServiceEmprestimo().GetMeusEmprestimos(ClienteId);
            Assert.True(emprestimos.Any());
        }

        [Fact]
        public void Gerar_arquivo()
        {
            var emprestimos = GetServiceEmprestimo().GerarAquivo();
            Assert.True(emprestimos.Any());
        }

        private Cliente GetCliente()
        {
            var cliente = new Cliente();
            cliente.SetLimiteDeEmprestimo(100);
            cliente.SetNome("Matheus");
            cliente.SetId(ClienteId);
            return cliente;
        }

        private EmprestimoServices GetServiceEmprestimo()
        {
            var repositoryEmprestimo = new Mock<IEmprestimoRepository>();
            var repositoryCliente = new Mock<IClienteRepository>();
            var clienteServicesMoq = new Mock<IClienteServices>();

            var clientes = PopularCliente();
            var emprestimos = PopularEmprestimo(clientes.FirstOrDefault());

            repositoryCliente.Setup(x => x.Get(It.IsAny<Expression<Func<Cliente, bool>>>())).Returns(clientes.AsQueryable);
            repositoryEmprestimo.Setup(x => x.Get(It.IsAny<Expression<Func<Emprestimo, bool>>>())).Returns(emprestimos.AsQueryable);
            clienteServicesMoq.Setup(c => c.GetById(It.IsAny<Guid>())).Returns(clientes.FirstOrDefault());
            repositoryCliente.Setup(x => x.GetAll()).Returns(clientes.AsQueryable);

            return new EmprestimoServices(repositoryEmprestimo.Object, clienteServicesMoq.Object, new EmprestimoBuilder(), new EmprestimoValidator(repositoryCliente.Object));
        }

        private List<Cliente> PopularCliente()
        {
            return new List<Cliente>()
            {
                GetCliente()
            };
        }

        private List<Emprestimo> PopularEmprestimo(Cliente cliente)
        {
            return new List<Emprestimo>()
            {
                new Emprestimo(Guid.NewGuid(), cliente, DateTime.Now, 10m)
            };
        }
    }
}