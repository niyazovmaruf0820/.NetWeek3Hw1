namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using global::Dapper;
using Infrastructure.Interface;
public class MenuService : Interface<Menu>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Menu value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Menu(FoodName,Price)values(@foodName,@price)",value);
        return "done";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Menu where Id = @id",new {Id = id});
        return "done";
    }

    public async Task<List<Menu>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Menu>("select * from Menu");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Menu value)
    {
        await dapperContext.Connection().ExecuteAsync("update Menu set FoodName = @foodName,Price = @price where Id = @id",value);
        return "done";
    }
}
