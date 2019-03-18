using Data.Data;
using Data.RepositoryEntity;
using Domain.Emprestimos.Factory;
using Dtos.Dto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Clientes;
using Services.Emprestimos;
using Services.UbsServices.Validator;

namespace Ioc
{
    public class ClassIoC
    {
        public ClassIoC(IServiceCollection services)
        {
            RegisterRepository(services);
            RegisterValidator(services);
        }

        private void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<IContextApplication, ContextApplication>();

            services.AddScoped<IEmprestimoBuilder, EmprestimoBuilder>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IEmprestimoServices, EmprestimoServices>();
            services.AddScoped<IEmprestimoBuilder, EmprestimoBuilder>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }


        private void RegisterValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<UbsFormDTO>, UbsValidator>();
            services.AddTransient<IValidator<EmprestimoFormDto>, EmprestimoValidator>();
        }
    }
}