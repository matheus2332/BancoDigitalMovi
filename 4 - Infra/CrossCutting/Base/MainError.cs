using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CrossCutting.Base
{
    public class MainError : IMainError
    {
        public MainError()
        {
            Erros = new List<string>();
        }

        [NotMapped]
        public ICollection<string> Erros { get; private set; }

        public bool IsValid => !Erros.Any();

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        }
    }
}