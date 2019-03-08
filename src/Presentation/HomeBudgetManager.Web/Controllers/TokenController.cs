using HomeBudgetManager.Application.Interfaces.Services;
using HomeBudgetManager.Domain.Entities;
using HomeBudgetManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ILogger<TokenController> _logger;
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public TokenController(IUserService userService, ILogger<TokenController> logger, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<TokenResponse>> GetToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }                

            try
            {
                var authResult = await _userService.AuthenticateAsync(request.User);
                if (!authResult.Success)
                {
                    return Unauthorized();
                }

                return Json(BuildToken(authResult.User));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private TokenResponse BuildToken(User user)
        {
            var now = DateTime.UtcNow;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenExpirationMinutes = _config.GetValue<int>("Jwt:TokenExpirationInMinutes");

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims: claims,
              notBefore: now,
              expires: now.Add(TimeSpan.FromMinutes(tokenExpirationMinutes)),
              signingCredentials: credentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponse()
            {
                Expiration = tokenExpirationMinutes,
                Token = encodedToken
            };
        }
    }
}
