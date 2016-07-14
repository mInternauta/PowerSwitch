using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerSwitch.ServiceCore
{
    public class SecurityHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            Authenticate(request);
            response = await base.SendAsync(request, cancellationToken);

            return response;
        }

        private void Authenticate(HttpRequestMessage request)
        {
            if(request.Headers.Contains("Account"))
            {
                string username, password, domain;
                ExtractAccount(request, out username, out password, out domain);

                if (Windows.WindowsLogin.IsValidateCredentials(username, password, domain))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("psadmin"),
                        new string[] { "PowerSwitch" });
                }
            }
        }

        private void ExtractAccount(HttpRequestMessage request, out string username, out string password, out string domain)
        {
            string accountDetails = request.Headers.GetValues("Account").FirstOrDefault( );
            accountDetails = Encoding.Default.GetString(Convert.FromBase64String(accountDetails));

            username = accountDetails.Split('|').FirstOrDefault( );
            password = accountDetails.Split('|').LastOrDefault( );
            domain = "";
            if (username.Contains("\\"))
            {
                domain = username.Split('\\').First( );
                username = username.Split('\\').Last( );
            }
        }
    }
}
