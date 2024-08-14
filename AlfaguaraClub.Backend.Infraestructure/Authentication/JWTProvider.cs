using AlfaguaraClub.Backend.Application.Contracts.Infraestructure;
using AlfaguaraClub.Backend.Application.Services.UserServices.QueryUserCommands;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlfaguaraClub.Backend.Infraestructure.Authentication
{
    internal sealed class JWTProvider : IJWTProvider
    {
        private readonly JWTOptions _options;
        public JWTProvider(IOptions<JWTOptions> options)
        {
            _options = options.Value;
        }
        public string Generate(UserListVm user)
        {
            var claims = new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.Name + user.LastName)
            };
            var signinCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddHours(1),
                signinCredentials);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
