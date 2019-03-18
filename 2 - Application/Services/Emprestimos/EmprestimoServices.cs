using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using Data.Data;
using Data.RepositoryEntity;
using Domain.Emprestimos;
using Domain.Emprestimos.Factory;
using Dtos.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Services.Clientes;

namespace Services.Emprestimos
{
    public class EmprestimoServices : IEmprestimoServices
    {
        private readonly IClienteServices _clienteServices;
        private readonly IEmprestimoBuilder _emprestimoBuilder;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IValidator<EmprestimoFormDto> _validatorFormDto;

        public EmprestimoServices(IEmprestimoRepository emprestimoRepository, IClienteServices clienteServices, IEmprestimoBuilder emprestimoBuilder, IValidator<EmprestimoFormDto> validatorFormDto)
        {
            _emprestimoRepository = emprestimoRepository;
            _clienteServices = clienteServices;
            _emprestimoBuilder = emprestimoBuilder;
            _validatorFormDto = validatorFormDto;
        }

        public List<string> GerarAquivo()
        {
            var linhas = new List<string>();
            var dataDeGeracaoDoArquivo = DateTime.Now;
            var cabecalho = StringHelper.FormatarDataParaArquivoDeEmprestimos(dataDeGeracaoDoArquivo);
            var registros = GetAll(dataDeGeracaoDoArquivo);
            var rodape = $"{StringHelper.CompletarCamposComZeros(registros.Count, 10)}{StringHelper.RetornarQuantidadeDeCmaposDecimais(registros.Sum(x => x.ValorDoEmprestimo), 19)}";
            linhas.Add(cabecalho);
            linhas.AddRange(PreencherRegistros(registros));
            linhas.Add(rodape);
            return linhas;
        }

        public List<EmprestimosGridDto> GetMeusEmprestimos(Guid clienteId)
        {
            return _emprestimoRepository.Get(x => x.ClienteId == clienteId)
                .Select(x => new EmprestimosGridDto
                {
                    Valor = $"R$ {Math.Round(x.Valor, 2)}",
                    Data = x.DataDoEmprestimo.ToString("dd/MM/yyyy"),
                    NomeDoCliente = x.Cliente.Nome
                }).ToList();
        }

        public EmprestimoFormDto Save(EmprestimoFormDto formDto)
        {
            ValidarFormDto(formDto);
            if (!formDto.ValidationSucceeded) return formDto;

            var emprestimo = CriarEmprestimo(formDto);
            if (!emprestimo.IsValid)
            {
                formDto.AddErro(string.Join(',', emprestimo.Erros));
                return formDto;
            }

            _clienteServices.AlterarOLimiteDeEmprestimoDoCliente(emprestimo.Cliente, formDto.ValorDoEmprestimo);

            _emprestimoRepository.Add(emprestimo);
            _emprestimoRepository.Commit();
            return formDto;
        }

        private Emprestimo CriarEmprestimo(EmprestimoFormDto formDto)
        {
            var cliente = _clienteServices.GetById(formDto.ClienteId);
            formDto.DataDoEmprestimo = DateTime.Now;

            return _emprestimoBuilder
                .WithCliente(cliente)
                .WithDataDoEmprestimo(formDto.DataDoEmprestimo)
                .WithId(Guid.NewGuid())
                .WithValor(formDto.ValorDoEmprestimo)
                .Build();
        }

        private List<EmprestimoArquivoDto> GetAll(DateTime dataDeGeracaoDoArquivo)
        {
            return _emprestimoRepository.Get(x => x.DataDoEmprestimo.Date == dataDeGeracaoDoArquivo.Date)
                .Select(x => new EmprestimoArquivoDto
                {
                    ValorDoEmprestimo = x.Valor,
                    DataDoEmprestimo = x.DataDoEmprestimo,
                    Cpf = x.Cliente.Cpf
                }).ToList();
        }

        private IEnumerable<string> PreencherRegistros(List<EmprestimoArquivoDto> registros)
        {
            return registros.Select(x => $"{x.Cpf}{StringHelper.RetornarQuantidadeDeCmaposDecimais(x.ValorDoEmprestimo, 10)}{StringHelper.FormatarDataParaArquivoDeEmprestimos(x.DataDoEmprestimo)}");
        }

        private void ValidarFormDto(EmprestimoFormDto formDto)
        {
            var results = _validatorFormDto.Validate(formDto);

            formDto.ValidationSucceeded = results.IsValid;
            formDto.ErrorMessages = results.Errors.Select(o => o.ErrorMessage).ToList();
        }
    }
}