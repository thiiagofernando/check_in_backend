using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.backend.Domain.Entities
{
    public class HorarioTreino : BaseEntity
    {
        public string NomeTreino { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public int? QuantidadePessoas { get; set; }
    }

}
