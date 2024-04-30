﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IRepository<Address> _repository;

    public UpdateAddressCommandHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand command)
    {
        var values = await _repository.GetByIdAsync(command.AddressID);
        values.UserID = command.UserID;
        values.District = command.District;
        values.City = command.City;
        values.Detail = command.Detail;
        await _repository.UpdateAsync(values);
    }
}
