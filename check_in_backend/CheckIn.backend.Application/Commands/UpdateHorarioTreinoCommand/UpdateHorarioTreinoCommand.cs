namespace CheckIn.backend.Application.Commands.UpdateHorarioTreinoCommand;

using MediatR;

public class UpdateHorarioTreinoCommand : IRequest<bool>
{
    public long Id { get; set; }
    public string NomeTreino { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan HoraInicial { get; set; }
    public TimeSpan HoraFinal { get; set; }
    public int? QuantidadePessoas { get; set; }
}
