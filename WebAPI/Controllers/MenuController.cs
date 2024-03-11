using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;


namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class MenuController
{
    private readonly MenuService menuService;
    public MenuController()
    {
        menuService = new MenuService();
    }
    [HttpGet("get-Menu")]
    public async Task<List<Menu>> GetMenuAsync()
    {
        return await menuService.GetValues();
    }
    [HttpPost("add-menu")]
    public async Task<string> AddmenuAsync(Menu menu)
    {
        return await menuService.AddValues(menu);
    }
    [HttpPut("update-menu")]
    public async Task<string> UpdatemenuAsync(Menu menu)
    {
        return await menuService.UpdateValues(menu);
    }
    [HttpDelete("delete-menu")]
    public async Task<string> DelatemenuAsync(int id)
    {
        return await menuService.DeleteValues(id);
    }
}
