using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class OrderController 
{
    private readonly OrderService orderService;
    public OrderController()
    {
        orderService = new OrderService();
    }
    [HttpGet("get-Orders")]
    public async Task<List<Orders>> GetOrdersAsync()
    {
        return await orderService.GetValues();
    }
    [HttpPost("add-order")]
    public async Task<string> AddorderAsync(Orders order)
    {
        return await orderService.AddValues(order);
    }
    [HttpPut("update-order")]
    public async Task<string> UpdateorderAsync(Orders order)
    {
        return await orderService.UpdateValues(order);
    }
    [HttpDelete("delete-order")]
    public async Task<string> DelateorderAsync(int id)
    {
        return await orderService.DeleteValues(id);
    }
    [HttpGet("GetOrdersByCustomerId")]
    public async Task<List<Orders>> GetOrdersByCustomerId(int id)
    {
        return await orderService.GetOrdersByCustomerId(id);
    }
}
