using Microsoft.IdentityModel.Tokens;

namespace Whatfits.JsonWebToken.Constant
{
    public class Verify
    {
        // create valid parameters for jwt
        public static TokenValidationParameters validationParameters =
            new TokenValidationParameters
            {
                ValidIssuers = new[] { "https://www.Whatfits.social/" },
                ValidAudiences = new[] { "Admin", "General" },
                IssuerSigningKey = new SymmetricSecurityKey(Key.ssosecret),
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            };

    }
}
