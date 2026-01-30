using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GameshopWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IConfiguration configuration;
		public OrderController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpPost("")]
		public IActionResult CreateOrder(Order order)
		{ 
			//validacija - primjer
			if(order.IdUser <= 0)
			{
				return BadRequest("Kupac mora biti zadan");
			}
			if(order.Details.Count == 0)
			{
				return BadRequest("Morate imati bar jednu igru na narudžbi");
			}
			string sqlOrder = @"INSERT INTO [Order](
				idUser,idEmployee,dateOrdered,dateSent
				) OUTPUT inserted.id VALUES(
				@idUser,@idEmployee,@dateOrdered,@dateSent
				)";
			using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("connString")))
			{
				order.DateOrdered = DateTime.Now;
				int orderId = connection.ExecuteScalar<int>(sqlOrder,order);
				order.Id = orderId;
				foreach (var detail in order.Details)
				{
					detail.IdOrder = orderId;
					string sqlOrderDetail = @"INSERT INTO OrderDetail(
					idOrder,idGame,quantity,unitprice
					) OUTPUT inserted.id VALUES(
					@idOrder,@idGame,@quantity,@unitprice
					)";
					connection.Execute(sqlOrderDetail, detail);
				}
				return Ok(order);
			}
		}
	}
}
