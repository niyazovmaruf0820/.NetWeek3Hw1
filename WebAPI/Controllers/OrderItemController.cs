using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderItemController 
{
    private readonly OrderItemService orderItemService;
    public OrderItemController()
    {
        orderItemService = new OrderItemService();
    }
    [HttpGet("get-OrderItems")]
    public async Task<List<OrderItems>> GetOrderItemsAsync()
    {
        return await orderItemService.GetValues();
    }
    [HttpPost("add-orderItem")]
    public async Task<string> AddorderItemAsync(OrderItems orderItem)
    {
        return await orderItemService.AddValues(orderItem);
    }
    [HttpPut("update-orderItem")]
    public async Task<string> UpdateorderItemAsync(OrderItems orderItem)
    {
        return await orderItemService.UpdateValues(orderItem);
    }
    [HttpDelete("delete-orderItem")]
    public async Task<string> DelateorderItemAsync(int id)
    {
        return await orderItemService.DeleteValues(id);
    }
    [HttpGet("GetInformationOfOrders")]
    public async Task<List<OrderItems>> GetInformationOfOrders()
    {
        return await orderItemService.GetInformationOfOrders();
    }
    [HttpGet("GetFoodsByOrderId")]
    public async Task<List<OrderItems>> GetFoodsByOrderId(int id)
    {
        return await orderItemService.GetFoodsByOrderId(id);
    }
}
