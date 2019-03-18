using System.Collections.Generic;

namespace Dtos.Dto.Interface
{
    public interface IUbsGridDataDTO
    {
        IEnumerable<UbsDTO> ListaUbsDTO { get; set; }
    }
}