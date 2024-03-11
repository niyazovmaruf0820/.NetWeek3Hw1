namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using global::Dapper;
using Infrastructure.Interface;
public class OrderService : Interface<Orders>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Orders value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Orders(CustomerId,Total)values(@CustomerId,@Total)",value);
        return "done";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Orders where Id = @id",new {Id = id});
        return "done";
    }

    public async Task<List<Orders>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Orders>("select * from Orders");
        return result.ToList();
    }
    public async Task<List<Orders>> GetOrdersByCustomerId(int customerId)
    {
        var result = await dapperContext.Connection().QueryAsync<Orders>("select * from Orders were CustomerId = @customerId", new {CustomerId = customerId});
        return result.ToList();
    }

    public async Task<string> UpdateValues(Orders value)
    {
        await dapperContext.Connection().ExecuteAsync("update Orders set CustomerId = @CustomerId,Total = @Total where Id = @id",value);
        return "done";
    }
}
