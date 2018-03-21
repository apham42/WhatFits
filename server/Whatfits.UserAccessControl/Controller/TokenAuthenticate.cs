using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Whatfits.UserAccessControl.Controller
{
    public class TokenAuthenticate : HttpMessageHandler
    {
        //
        // Summary:
        //     Initializes a new instance of the System.Net.Http.HttpMessageHandler class.
        protected HttpMessageHandler() { };

        //
        // Summary:
        //     Releases the unmanaged resources and disposes of the managed resources used by
        //     the System.Net.Http.HttpMessageHandler.
        public override void Dispose()
        {

        }
        //
        // Summary:
        //     Releases the unmanaged resources used by the System.Net.Http.HttpMessageHandler
        //     and optionally disposes of the managed resources.
        //
        // Parameters:
        //   disposing:
        //     true to release both managed and unmanaged resources; false to releases only
        //     unmanaged resources.
        protected override void Dispose(bool disposing)
        {

        }
        //
        // Summary:
        //     Send an HTTP request as an asynchronous operation.
        //
        // Parameters:
        //   request:
        //     The HTTP request message to send.
        //
        //   cancellationToken:
        //     The cancellation token to cancel operation.
        //
        // Returns:
        //     The task object representing the asynchronous operation.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The request was null.
        protected override internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

        }

    }
}
