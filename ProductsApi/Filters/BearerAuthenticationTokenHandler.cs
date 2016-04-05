﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProductsApi.Filters
{
	public class BearerAuthenticationTokenHandler : DelegatingHandler
	{
		private const string WWWAuthenticateHeader = "WWW-Authenticate";

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
															   CancellationToken cancellationToken)
		{
			var credentials = ParseAuthorizationHeader(request);

			// Pretend this claim comes from a token minted by an STS
			var claims = new List<Claim>() { new Claim(ClaimTypes.Name,"jqhuman") }; // User Id of John Q Human

			var id = new ClaimsIdentity(claims, "dummy");
			var claimsPrincipal = new ClaimsPrincipal(new[] { id });
			//var config = new IdentityConfiguration();
			//var newPrincipal = config.ClaimsAuthenticationManager.Authenticate(request.RequestUri.ToString(),principal);
			Thread.CurrentPrincipal = claimsPrincipal;
			if (HttpContext.Current != null)
			HttpContext.Current.User = claimsPrincipal;
			return await base.SendAsync(request, cancellationToken);



			//var credentials = ParseAuthorizationHeader(request);

			//if (credentials != null)
			//{
			//	var identity = new BasicAuthenticationIdentity(credentials.Name, credentials.Password);
			//	var principal = new GenericPrincipal(identity, null);

			//	Thread.CurrentPrincipal = principal;
			//	if (HttpContext.Current != null)
			//		HttpContext.Current.User = principal;
			//}
			//else
			//{
			//	return Task.Run(() => { return request.CreateResponse(HttpStatusCode.BadRequest); });
			//}
			//return base.SendAsync(request, cancellationToken)
			//	.ContinueWith(task =>
			//	{
			//		var response = task.Result;
			//		if (credentials == null && response.StatusCode == HttpStatusCode.Unauthorized)
			//			Challenge(request, response);


			//		return response;
			//	});
		}

		/// <summary>
		/// Parses the Authorization header and creates user credentials
		/// </summary>
		/// <param name="actionContext"></param>
		protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpRequestMessage request)
		{
			string authHeader = null;
			var auth = request.Headers.Authorization;
			if (auth != null && auth.Scheme == "Bearer")
				authHeader = auth.Parameter;

			if (string.IsNullOrEmpty(authHeader))
				return null;

			authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

			var tokens = authHeader.Split(':');
			if (tokens.Length < 2)
				return null;

			return new BasicAuthenticationIdentity(tokens[0], tokens[1]);
		}


		/// <summary>
		/// Send the Authentication Challenge request
		/// </summary>
		/// <param name="message"></param>
		/// <param name="actionContext"></param>
		void Challenge(HttpRequestMessage request, HttpResponseMessage response)
		{
			var host = request.RequestUri.DnsSafeHost;
			response.Headers.Add(WWWAuthenticateHeader, string.Format("Basic realm=\"{0}\"", host));
		}

	}
}