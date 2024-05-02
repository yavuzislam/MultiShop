using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingComamndHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public CreateOrderingComamndHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            UserID = request.UserID,
            TotalPrice = request.TotalPrice,
            OrderDate = request.OrderDate
        });
    }
}
