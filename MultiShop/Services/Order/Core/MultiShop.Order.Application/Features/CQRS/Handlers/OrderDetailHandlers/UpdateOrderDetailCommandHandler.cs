﻿using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var values = await _repository.GetByIdAsync(command.OrderDetailID);
        values.ProductID = command.ProductID;
        values.ProductName = command.ProductName;
        values.ProductPrice = command.ProductPrice;
        values.ProductAmount = command.ProductAmount;
        values.ProductTotalPrice = command.ProductTotalPrice;
        values.OrderingID = command.OrderingID;
        await _repository.UpdateAsync(values);
    }
}
