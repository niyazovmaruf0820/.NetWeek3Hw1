using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController
{
    private readonly CustomerService customerService;
    public CustomerController()
    {
        customerService = new CustomerService();
    }
    [HttpGet("get-customers")]
    public async Task<List<Customers>> GetCustomersAsync()
    {
        return await customerService.GetValues();
    }
    [HttpPost("add-customer")]
    public async Task<string> AddCustomerAsync(Customers customer)
    {
        return await customerService.AddValues(customer);
    }
    [HttpPut("update-customer")]
    public async Task<string> UpdateCustomerAsync(Customers customer)
    {
        return await customerService.UpdateValues(customer);
    }
    [HttpDelete("delete-customer")]
    public async Task<string> DelateCustomerAsync(int id)
    {
        return await customerService.DeleteValues(id);
    }
}
