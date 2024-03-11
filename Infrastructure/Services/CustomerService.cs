namespace Infrastructure.Services;

using Dapper;
using Domain.Models;
using global::Dapper;
using Infrastructure.Interface;
public class CustomerService : Interface<Customers>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Customers value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Customers(Name)values(@name)",value);
        return "done";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Customers where Id = @id",new {Id = id});
        return "done";
    }

    public async Task<List<Customers>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Customers>("select * from Customers");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Customers value)
    {
        await dapperContext.Connection().ExecuteAsync("update Customers set Name = @name where Id = @id",value);
        return "done";
    }
}
