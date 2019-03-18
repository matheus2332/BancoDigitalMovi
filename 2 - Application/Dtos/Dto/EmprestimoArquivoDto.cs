using System;

namespace Dtos.Dto
{
    public class EmprestimoArquivoDto
    {
        public string Cpf { get; set; }
        public DateTime DataDoEmprestimo { get; set; }
        public decimal ValorDoEmprestimo { get; set; }
    }
}