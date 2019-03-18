using Dtos.Dto.Interface;

namespace Dtos.Dto
{
    public class UbsDTO : IUbsDTO
    {
        // Esta classe deve conter as seguintes propriedades:
        // Nome, Endereco e Avaliacao
        public string Avaliacao { get; set; }

        public double Distancia { get; set; }

        public string Endereco { get; set; }

        public string Nome { get; set; }

        public int Ordenacao { get; set; }
    }
}