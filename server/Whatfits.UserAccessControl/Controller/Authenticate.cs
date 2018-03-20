using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Whatfits.UserAccessControl.Controller
{
    public class Authenticate : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
