using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Whatfits.JsonWebToken.Controller
{
    public class ConvertToJWT
    {
        private string jwt { get; set; }
        private List<string> claims { get; set; }

        public ConvertToJWT(string jwt)
        {
            this.jwt = jwt;
        }

        /// <summary>
        /// get claims from jwt token
        /// specifically the view claims
        /// </summary>
        /// <returns>view claims</returns>
        public List<string> GetClaimsFromToken()
        {
            JwtSecurityToken token = new JwtSecurityToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            token = handler.ReadToken(jwt) as JwtSecurityToken;

            claims = token.Claims.ToList()
                .FindAll(claim => claim.Type == "VIEW_PAGE")
                .Select(c =>c.Value).ToList<string>();

            return claims;
        }
    }
}
