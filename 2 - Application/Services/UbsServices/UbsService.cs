using System.Collections.Generic;
using System.Linq;
using Dtos.Dto;
using FluentValidation;
using GeoCoordinatePortable;

namespace Services.UbsServices
{
    public class UbsService
    {
        // Implemente um método que retorne as 5 UBSs mais próximas de um ponto (latitude e longitude) que devem
        // ser passados como parâmetro para o método e retorne uma lista/coleção de objetos do tipo UbsDTO.
        // Esta lista deve estar ordenada pela avaliação (da melhor para a pior) de acordo com os dados que constam
        // no objeto retornado pela camada de acesso a dados (DAL).

        //private readonly IUbsRepository _ubsRepository;
        //private readonly IValidator<Dtos.Dto.UbsFormDTO> _validatorFormDto;

        //public UbsService(IUbsRepository ubsRepository, IValidator<Dtos.Dto.UbsFormDTO> validatorFormDto)
        //{
        //    _ubsRepository = ubsRepository;
        //    _validatorFormDto = validatorFormDto;
        //}

        //public UbsGridDataDTO GetUbss(UbsFormDTO usbFormDto)
        //{
        //    var ubsGridDataDto = new UbsGridDataDTO();

        //    ValidarFormDto(usbFormDto, ubsGridDataDto);

        //    if (!ubsGridDataDto.ValidationSucceeded)
        //        return ubsGridDataDto;

        //    var listaUbs = _ubsRepository.GetAll(p => true).Select(s => new
        //    {
        //        DescricaoEstruturaFisicaAmbiencia = s.EstruturaFisicaAmbiencia.Nome,
        //        OrdenacaoEstruturaFisicaAmbiencia = s.EstruturaFisicaAmbiencia.Ordenacao,
        //        s.DescricaoEndereco,
        //        s.NomeEstabelecimento,
        //        s.DescricaoBairro,
        //        s.DescricaoCidade,
        //        s.ValorLatitude,
        //        s.ValorLongitude
        //    }).ToList();

        //    var listaretornoUbs = new List<UbsDTO>();
        //    var pontoPrincipal = new GeoCoordinate(usbFormDto.ValorLatitude, usbFormDto.ValorLongitude);

        //    foreach (var ubs in listaUbs)
        //    {
        //        var pontoUbs = new GeoCoordinate(ubs.ValorLatitude, ubs.ValorLongitude);

        //        var distancia = pontoPrincipal.GetDistanceTo(pontoUbs);

        //        listaretornoUbs.Add(new UbsDTO
        //        {
        //            Nome = ubs.NomeEstabelecimento,
        //            Endereco = $"{ubs.DescricaoEndereco} - {ubs.DescricaoBairro} - {ubs.DescricaoCidade}",
        //            Avaliacao = ubs.DescricaoEstruturaFisicaAmbiencia,
        //            Distancia = distancia,
        //            Ordenacao = ubs.OrdenacaoEstruturaFisicaAmbiencia
        //        });
        //    }

        //    var ubsMaisProximas = listaretornoUbs.OrderBy(o => o.Distancia).Take(5).ToList();
        //    ubsGridDataDto.ListaUbsDTO = ubsMaisProximas.OrderBy(o => o.Ordenacao);
        //    ubsGridDataDto.Message = ubsMaisProximas.Count() == 0 ? "A pesquisa não retornou nenhum registro!" : "A pesquisa retornou registros";

        //    return ubsGridDataDto;
        //}

        //public void ValidarFormDto(UbsFormDTO ubsFormDTO, UbsGridDataDTO ubsGridDataDTO)
        //{
        //    var results = _validatorFormDto.Validate(ubsFormDTO);

        //    ubsGridDataDTO.ValidationSucceeded = results.IsValid;
        //    ubsGridDataDTO.ErrorMessages = results.Errors.Select(o => o.ErrorMessage).ToList();
        //}
    }
}