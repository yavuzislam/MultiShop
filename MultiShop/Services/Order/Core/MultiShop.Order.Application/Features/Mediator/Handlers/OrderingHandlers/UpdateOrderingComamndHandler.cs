using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingComamndHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingComamndHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.OrderingID);
        value.UserID = request.UserID;
        value.TotalPrice = request.TotalPrice;
        value.OrderDate = request.OrderDate;
        await _repository.UpdateAsync(value);
    }
}
