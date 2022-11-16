using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serve.API.Data;
using Serve.API.Helpers;
using Serve.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Serve.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ServeDbContext _context;

        public AuthenticateController(
             UserManager<IdentityUser> userManager,
             RoleManager<IdentityRole> roleManager,
             IConfiguration configuration,
             ServeDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo

                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            //collect email and store it in username in the form
            //N.B Username and Email are the same
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                //Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            //insert into my Users table
            //var myUsers = new User() { Phone = model.Phone, Email = model.Email, Username = model.Email, Password = model.Password };
            //_context.Users.Add(myUsers);
            //_context.SaveChanges();
            //get userid

            //use this to debug model insertions
            //return Ok(result);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //insert into organzation , if User is an organization , AuthenticationType = 'Normal'
            var org = new Organization() { BusinessName = model.BusinessName, BusinessEmail = model.Username };
            //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Organization ON;");
            _context.Organizations.Add(org);
            _context.SaveChanges();
            //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Organization OFF;");



            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            //var subject = "Confirm Account Registration";

            //var Url = Domain.GenericModels.ApplicationUrl.LoginUrl;
            //connection issues Auth mail sender
            //await _emailSender.SendEmailAsync(model.Email, subject, EmailFormatter.CompleteUserRegistration(model.Email, Url));
            //hasnt permitted Emanager 
            //await EmailManager.SendEmailAsync(model.Email, null, EmailFormatter.CompleteUserRegistration(model.Email, Url));
            //await _mailService.SendEmailAsync(model.Email, "Tech-haven (Complete Registration)", EmailFormatter.CompleteUserRegistration(model.Email, Url));
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
            //above sendgrid message
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        //public async Task GoogleLogin()
        //{
        //    await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
        //    {
        //        RedirectUri = Url.Action("GoogleResponse", "Account")
        //    });
        //}

        //public async Task<IActionResult> GoogleResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = result.Principal.Identities
        //        .FirstOrDefault().Claims.Select(claim => new
        //        {
        //            claim.Issuer,
        //            claim.OriginalIssuer,
        //            claim.Type,
        //            claim.Value
        //        });
        //    //return Json(claims);
        //    return Ok();
        //}

        //[Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
