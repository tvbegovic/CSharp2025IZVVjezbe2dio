using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameshopWeb.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IConfiguration configuration;
		private JWTTokenConfig _jwtTokenConfig;
		public UserController(IConfiguration configuration, 
			JWTTokenConfig jwtTokenConfig)
		{
			this.configuration = configuration;
			_jwtTokenConfig = jwtTokenConfig;
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

		[HttpGet("login")]
		public IActionResult Login(string email, string password)
		{
			using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("connString")))
			{
				string sql = "SELECT * FROM [User] WHERE email = @email AND password = @password";
				User user = connection.QueryFirstOrDefault<User>(sql, new { email, password });
				if (user == null)
				{
					return BadRequest("Ne postoji korisnik s tom email adresom i lozinkom");
				}
				LoginResult loginResult = new LoginResult();
				user.Password = null;
				loginResult.User = user;
				loginResult.AccessToken = GenerateToken(email, "user");
				return Ok(loginResult);
			}
		}

		[HttpPut("")]
		[Authorize]
		public IActionResult UpdateUser(User user)
		{
			if(string.IsNullOrEmpty(user.Firstname) || string.IsNullOrEmpty(user.Lastname))
			{
				return BadRequest("Ime i prezime moraju biti upisani");
			}
			string sql = "UPDATE [User] SET firstname = @firstname, lastname = @lastname, address = @address, city = @city WHERE id = @id";
			using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("connString")))
			{
				connection.Execute(sql, user);
				return Ok();
			}
		}

		private string GenerateToken(string email, string role)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var keyBytes = Encoding.UTF8.GetBytes(_jwtTokenConfig.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
					{
						new Claim(ClaimTypes.Name, email),
						new Claim(ClaimTypes.Role, role)
				}),
				Expires = DateTime.UtcNow.AddMinutes(_jwtTokenConfig.AccessTokenExpiration),
				Issuer = _jwtTokenConfig.Issuer,
				Audience = _jwtTokenConfig.Audience,
				SigningCredentials = new SigningCredentials(
							new SymmetricSecurityKey(keyBytes),
							SecurityAlgorithms.HmacSha256Signature
					)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}

	public class LoginResult
	{
		public User User { get; set; }
		public string AccessToken { get; set; }
	}
}
