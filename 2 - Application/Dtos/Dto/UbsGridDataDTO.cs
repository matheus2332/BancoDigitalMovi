using System.Collections.Generic;
using Dtos.Dto.Base;
using Dtos.Dto.Interface;

namespace Dtos.Dto
{
    public class UbsGridDataDTO : BaseDTO, IUbsGridDataDTO
    {
        public IEnumerable<UbsDTO> ListaUbsDTO { get; set; }
    }
}