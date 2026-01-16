using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GameshopWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IConfiguration configuration;
		public UserController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpPost("register")]
		public IActionResult Register(User user)
		{
			if(user.Firstname.Length == 0 || user.Lastname.Length == 0 || user.Email.Length == 0)
			{
				return BadRequest("Ime, prezime i email moraju biti zadani");
			}
			if (user.Password.Length < 8) 
			{ 
				return BadRequest("Lozinka mora imati minimalno 8 znakova");
			}
			using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("connString")))
			{
				string sql = "SELECT COUNT(*) FROM [User] WHERE email = @email";
				int brojKorisnika = connection.ExecuteScalar<int>(sql, new { email = user.Email });
				if(brojKorisnika > 0)
				{
					return BadRequest("Već postoji korisnik sa tom email adresom");
				}
				sql = @"INSERT INTO [User](firstname, lastname,email, address, City,password)
VALUES(@firstname, @lastname,@email, @address, @City,@password)";
				connection.Execute(sql,user);
				return Ok();
			}

		}
	}
}
