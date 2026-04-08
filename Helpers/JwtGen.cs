using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Subscription.Helpers;

public class JwtGen
{
    private IConfiguration _configuration;
    private string _scheme;

    public JwtGen(IConfiguration config, string scheme = "scheme1")
    {
        _configuration = config;
        _scheme = scheme;
    }

    public string GenerateJwtToken(string email, int userId)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, email),
            new Claim("Email", email),
            new Claim("UserId", userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[$"Jwt:{_scheme}:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration[$"Jwt:{_scheme}:Issuer"],
            audience: _configuration[$"Jwt:{_scheme}:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
