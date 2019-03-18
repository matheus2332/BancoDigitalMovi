using Data.Data;
using Data.RepositoryEntity;
using Domain.Emprestimos.Factory;
using Dtos.Dto;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Clientes;
using Services.Emprestimos;

namespace GerarArquivo
{
    public class DependenceInjection
    {
        public IEmprestimoServices EmprestimoServices()
        {
            return ResolverInjecaoDeDepencias().GetService<IEmprestimoServices>();
        }

        private ServiceProvider ResolverInjecaoDeDepencias()
        {
            return new ServiceCollection()
                .AddLogging().
                AddSingleton<IContextApplication, ContextApplication>().
                AddSingleton<IEmprestimoBuilder, EmprestimoBuilder>().
                AddSingleton<IClienteServices, ClienteServices>().
                AddSingleton<IEmprestimoServices, EmprestimoServices>().
                AddSingleton<IEmprestimoBuilder, EmprestimoBuilder>().
                AddSingleton<IEmprestimoRepository, EmprestimoRepository>().
                AddSingleton<IClienteRepository, ClienteRepository>().
                AddSingleton<IValidator<EmprestimoFormDto>, EmprestimoValidator>()
                .AddDbContext<ContextApplication>((options => options.UseSqlServer(ConnectionString.GetConnectionString())))
                .BuildServiceProvider();
        }
    }
}