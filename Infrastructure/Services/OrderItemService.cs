namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using global::Dapper;
using Infrastructure.Interface;
public class OrderItemService : Interface<OrderItems>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(OrderItems value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into OrderItems(OrderId,MenuId,Quantity,UnitPrice)values(@orderId,@menuId,@quantity,@untiPrice)",value);
        return "done";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from OrderItems where Id = @id",new {Id = id});
        return "done";
    }

    public async Task<List<OrderItems>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<OrderItems>("select * from OrderItems");
        return result.ToList();
    }

    public async Task<string> UpdateValues(OrderItems value)
    {
        await dapperContext.Connection().ExecuteAsync("update OrderItems set OrderId = @orderId,MenuId = @menuId ,Quantity = @quantity, UnitPrice = @unitPrice where Id = @id",value);
        return "done";
    }
    public async Task<List<OrderItems>> GetInformationOfOrders()
    {
        var result = await dapperContext.Connection().QueryAsync<OrderItems>(@"select c.Name,m.FoodName,o.Total from OrderItems as oi
                                                                               join Orders as o on oi.OrderId = o.Id
                                                                               join Menu as m on oi.MenuId = m.Id
                                                                               join Customers as c on o.CustomerId = c.Id");
        return result.ToList();
    }
    public async Task<List<OrderItems>> GetFoodsByOrderId(int orderId)
    {
        var result = await dapperContext.Connection().QueryAsync<OrderItems>(@"select m.Id, m.FoodName, m.Price from OrderItems as oi
                                                                               join Menu as m on oi.MenuId = m.Id
                                                                               join Orders as o on oi.OrderId = o.Id
                                                                               where o.Id = @orderid",new {OrderId = orderId});
        return result.ToList();
    }
}