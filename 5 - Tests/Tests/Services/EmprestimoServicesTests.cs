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
        [Fact]
        public void Save()
        {
            var formDto = GetServiceEmprestimo().Save(new EmprestimoFormDto
            {
                ValorDoEmprestimo = 100,
                ClienteId = Guid.Parse("8ff3ec78-bff0-456c-aacd-6b3242403985"),
                DataDoEmprestimo = DateTime.Now,
            });

            Assert.True(formDto.ValidationSucceeded);
        }

        private Cliente GetCliente()
        {
            var cliente = new Cliente();
            cliente.SetCpf("");
            cliente.SetLimiteDeEmprestimo(1100);
            cliente.SetNome("Jdulley");
            cliente.SetSenha("");
            cliente.SetUsuario("");
            cliente.SetId(Guid.Parse("8ff3ec78-bff0-456c-aacd-6b3242403985"));
            return cliente;
        }

        private EmprestimoServices GetServiceEmprestimo()
        {
            var repositoryEmprestimo = new Mock<IEmprestimoRepository>();
            var repositoryCliente = new Mock<IClienteRepository>();
            var clienteServicesMoq = new Mock<IClienteServices>();

            var clientes = PopularCliente();

            repositoryCliente.Setup(x => x.Get(It.IsAny<Expression<Func<Cliente, bool>>>())).Returns(clientes.AsQueryable);
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