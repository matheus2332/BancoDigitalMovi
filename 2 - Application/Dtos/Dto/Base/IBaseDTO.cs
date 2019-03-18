using System.Collections.Generic;
using FluentValidation.Results;

namespace Dtos.Dto.Base
{
    public interface IBaseDTO
    {
        ICollection<string> ErrorMessages { get; set; }
        IList<ValidationFailure> Failures { get; set; }
        string Message { get; set; }
        bool ValidationSucceeded { get; set; }

        void AddErro(string erro);
    }
}