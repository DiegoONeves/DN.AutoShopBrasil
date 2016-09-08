using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using DN.AutoShopBrasil.Application.Interfaces;
using System.Security.Principal;
using System.Threading;

namespace DN.AutoShopBrasil.API.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAnuncianteAppService _anuncianteAppService;
        public AuthorizationServerProvider(IAnuncianteAppService anuncianteAppService)
        {
            _anuncianteAppService = anuncianteAppService;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var anunciante = _anuncianteAppService.Autenticar(context.UserName, context.Password);

            if(anunciante == null)
            {
                context.SetError("invalid_grant", "E-mail ou senha incorretos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, anunciante.Email));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, anunciante.Nome));

            GenericPrincipal principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);

        }
    }
}