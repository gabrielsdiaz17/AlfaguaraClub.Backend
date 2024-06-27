using AlfaguaraClub.Backend.Infraestructure.Authentication;
using Microsoft.Extensions.Options;

namespace AlfaguaraClub.Backend.Api.OptionsSetup
{
    public class JwtOptionsSetup:IConfigureOptions<JWTOptions>
    {
        private const string sectionBame = "Jwt";
        private readonly IConfiguration _configuration;
        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JWTOptions options)
        {
            _configuration.GetSection("Jwt").Bind(options);
        }
    }
}
