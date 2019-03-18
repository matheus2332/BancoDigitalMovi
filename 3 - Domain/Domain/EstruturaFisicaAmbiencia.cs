using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class EstruturaFisicaAmbiencia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Ordenacao { get; set; }

        [ForeignKey("EstruturaFisicaAmbienciaFK")]
        public virtual ICollection<Ubs> Ubs { get; set; }
    }
}