using System;
using Dtos.Dto.Base;

namespace Dtos.Dto
{
    public class EmprestimoFormDto : BaseDTO
    {
        public Guid ClienteId { get; set; }
        public DateTime DataDoEmprestimo { get; set; }
        public decimal ValorDoEmprestimo { get; set; }
    }
}