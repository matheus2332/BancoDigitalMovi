using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Data.Data;
using Data.RepositoryEntity;
using Dtos.Dto;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Services.Emprestimos
{
    public class EmprestimoValidator : AbstractValidator<EmprestimoFormDto>
    {
        private readonly IClienteRepository _repositoryCliente;

        public EmprestimoValidator(IClienteRepository repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
            RuleFor(m => m.ValorDoEmprestimo)
                .Must((formDto, valor) => ValidarValores(valor)).WithMessage("O valor deve ser maior que 0.");

            RuleFor(m => m.ValorDoEmprestimo)
                .Must((formDto, valor) => ValidarValorDisponivel(formDto)).WithMessage("O cliente não não possui limite disponivel para esta transação.");
        }

        private bool ValidarValorDisponivel(EmprestimoFormDto formDto)
        {
            var limiteDisponivel = _repositoryCliente.Get(x => x.Id == formDto.ClienteId).Select(x => x.LimiteDeEmprestimo).FirstOrDefault();
            return limiteDisponivel >= formDto.ValorDoEmprestimo;
        }

        private bool ValidarValores(decimal valor)
        {
            return !(valor < 0);
        }
    }
}