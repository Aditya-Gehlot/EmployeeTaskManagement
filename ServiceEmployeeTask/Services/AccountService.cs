using Microsoft.Extensions.Configuration;
using ServiceEmployeeTask.Interfaces;
using System.Security.Claims;
using System.Text;

namespace ServiceEmployeeTask.Services
{
    public class AccountService : IAccountService
    {
    //    private readonly IConfiguration _configuration;

    //    public JwtService(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }

    //    public string GenerateJwtToken(IdentityUser user)
    //    {
    //        var jwtSettings = _configuration.GetSection("Jwt");

    //        var claims = new[]
    //        {
    //            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //            new Claim(ClaimTypes.NameIdentifier, user.Id)
    //        };

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
    //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            issuer: jwtSettings["Issuer"],
    //            audience: jwtSettings["Audience"],
    //            claims: claims,
    //            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"])),
    //            signingCredentials: creds
    //        );

    //        return new JwtSecurityTokenHandler().WriteToken(token);
    //    }
    }
}
