namespace CheckIn.backend.Application.Commands.UpdateHorarioTreinoCommand;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;

public class UpdateHorarioTreinoCommandHandler : IRequestHandler<UpdateHorarioTreinoCommand,bool>
{
    private readonly IHorarioTreinoRepository _horarioTreinoRepository;

    public UpdateHorarioTreinoCommandHandler(IHorarioTreinoRepository horarioTreinoRepository)
    {
        _horarioTreinoRepository = horarioTreinoRepository;
    }

    public async Task<bool> Handle(UpdateHorarioTreinoCommand request, CancellationToken cancellationToken)
    {
        var horarioTreino = await _horarioTreinoRepository.GetByIdAsync(request.Id);

        if (horarioTreino == null)
        {
            throw new Exception("Horário de treino não encontrado.");
        }

        horarioTreino.NomeTreino = request.NomeTreino;
        horarioTreino.Data = request.Data;
        horarioTreino.HoraInicial = request.HoraInicial;
        horarioTreino.HoraFinal = request.HoraFinal;
        horarioTreino.QuantidadePessoas = request.QuantidadePessoas;

        await _horarioTreinoRepository.UpdateAsync(horarioTreino);
        return true;
    }
}
