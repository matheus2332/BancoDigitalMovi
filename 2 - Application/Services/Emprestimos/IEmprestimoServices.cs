using System;
using System.Collections.Generic;
using Domain.Emprestimos;
using Dtos.Dto;

namespace Services.Emprestimos
{
    public interface IEmprestimoServices
    {
        List<string> GerarAquivo();

        List<EmprestimosGridDto> GetMeusEmprestimos(Guid clienteId);

        EmprestimoFormDto Save(EmprestimoFormDto formDto);
    }
}