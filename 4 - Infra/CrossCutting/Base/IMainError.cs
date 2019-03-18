using System.Collections.Generic;

namespace CrossCutting.Base
{
    public interface IMainError
    {
        ICollection<string> Erros { get; }
        bool IsValid { get; }

        void AddErro(string erro);
    }
}