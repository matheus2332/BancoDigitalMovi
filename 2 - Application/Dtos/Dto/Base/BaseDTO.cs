using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Dtos.Dto.Base
{
    public abstract class BaseDTO : IBaseDTO
    {
        private bool _domainError;
        private bool _validationSucceeded;

        protected BaseDTO()
        {
            Failures = new List<ValidationFailure>();
            ErrorMessages = new List<string>();
        }

        public bool DomainError
        {
            get => ErrorMessages.Count > 0 || Failures.Count > 0;
            set => _domainError = value;
        }

        public ICollection<string> ErrorMessages { get; set; }

        public ICollection<string> ErrosConsolidados => ErrorMessages.Concat(Failures.Select(x => x.ErrorMessage)).ToList();

        public IList<ValidationFailure> Failures { get; set; }

        public string Message { get; set; }

        public bool ValidationSucceeded
        {
            get => (ErrorMessages.Count == 0 && Failures.Count == 0);
            set => _validationSucceeded = value;
        }

        public void AddErro(string erro)
        {
            if (!string.IsNullOrEmpty(erro)) ErrorMessages.Add(erro);
        }

        public void AddFailure(string nomeDaPropriedade, string erro)
        {
            if (string.IsNullOrEmpty(nomeDaPropriedade) || string.IsNullOrEmpty(erro)) return;

            var falha = new ValidationFailure(nomeDaPropriedade, erro);
            Failures.Add(falha);
        }
    }
}