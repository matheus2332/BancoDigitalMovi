using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Ubs
    {
        // Esta classe deve conter as seguintes propriedades:
        // vlr_latitude, vlr_longitude, nom_estab, dsc_endereco, dsc_bairro, dsc_cidade, dsc_estrut_fisic_ambiencia

        public string DescricaoBairro { get; set; }

        public string DescricaoCidade { get; set; }

        public string DescricaoEndereco { get; set; }

        [ForeignKey("EstruturaFisicaAmbienciaFK")]
        public virtual EstruturaFisicaAmbiencia EstruturaFisicaAmbiencia { get; set; }

        public int EstruturaFisicaAmbienciaId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NomeEstabelecimento { get; set; }

        public double ValorLatitude { get; set; }

        public double ValorLongitude { get; set; }
    }
}