using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace OnlineShopWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IConfiguration configuration;
		public ProductController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpGet("")]
		public List<Product> GetProducts() 
		{
			string sql = "SELECT * FROM Product";
			using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("connString")))
			{
				return connection.Query<Product>(sql).ToList();
			}
		}
	}
}
