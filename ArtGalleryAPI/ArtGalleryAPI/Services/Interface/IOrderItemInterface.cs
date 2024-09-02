﻿using ArtGalleryAPI.Models.Domain;
using ArtGalleryAPI.Models.Dto;

namespace ArtGalleryAPI.Services.Interface
{
    public interface IOrderItemInterface
    {
        Task<IEnumerable<OrderItem>> GetAllOrdersItemsAsync();
        Task<OrderItem>? GetOrderItemByIdAsync(Guid orderItemId);
        Task<OrderItemsFullDto>? GetOrderItemFullByIdAsync(Guid orderItemId);
        Task<OrderItem> CreateOrderItemAsync(OrderItem newOrderItem);
        Task<IEnumerable<OrderItem>> CreateOrderItemsAsync(IEnumerable<OrderItem> newOrderItems);
        Task<OrderItem>? UpdateOrderItemAsync(Guid orderItemId, UpdateOrderItemDto updatedOrderItem);
        Task<bool> DeleteOrderItemAsync(Guid orderItemId);
    }
}
