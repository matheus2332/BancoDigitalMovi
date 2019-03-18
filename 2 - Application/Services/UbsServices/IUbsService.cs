using Dtos.Dto;

namespace Services.UbsServices
{
    public interface IUbsService
    {
        UbsGridDataDTO GetUbss(UbsFormDTO usbFormDto);
    }
}