using Dtos.Dto.Interface;

namespace Dtos.Dto
{
    public class UbsFormDTO : IUbsFormDTO
    {
        public double ValorLatitude { get; set; }

        public double ValorLongitude { get; set; }
    }
}