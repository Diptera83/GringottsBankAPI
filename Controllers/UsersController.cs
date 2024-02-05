using GringottsBankAPI2.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GringottsBankAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                DateAdded = DateTime.Now

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            Log.Information("Create User => {result}",result);

            if (result.Succeeded)
            {
                return StatusCode(201); // Başarılı
            }

            return BadRequest(result.Errors);


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {


            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest(new { message = "E-Mail Hatalı" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            Log.Information("Login User => {result}", result);

            if (result.Succeeded)
            {
                return Ok(new { token = GenerateJWT(user) });
            }

            return Unauthorized();
        }

        private object GenerateJWT(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

            new Claim[]{
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName ?? "" ),
            }
            ),

                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer="bilgekagan.com"
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
