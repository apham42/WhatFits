using Microsoft.IdentityModel.Tokens;

namespace Whatfits.JsonWebToken.Constant
{
    public static class Verify
    {
        // create valid parameters for jwt
        public static TokenValidationParameters validationParameters =
            new TokenValidationParameters
            {
                ValidIssuers = new[] { "https://www.Whatfits.social/" },
                ValidAudiences = new[] { "Admin", "General" },
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Key.secret),
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            };


    }
}
