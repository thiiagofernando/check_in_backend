using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.backend.Application.Dto
{
    public class HorarioTreinoDto
    {
        public string NomeTreino { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public int? QuantidadePessoas { get; set; }
    }
}
