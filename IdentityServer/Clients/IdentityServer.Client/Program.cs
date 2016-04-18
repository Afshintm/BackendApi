using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Client
{
	class Program
	{
		static void Main(string[] args)
		{
            var newRespobse = NewGetClientToken();
            NewCallApi(newRespobse);
            Console.ReadLine();
            
		}
        private static void NewCallApi(TokenResponse newRespobse)
        {
            //use afshinpc for fiddler to capture the traffic otherwise localhost
            var client = new HttpClient();
            client.SetBearerToken(newRespobse.AccessToken);
            var r = client.GetStringAsync("http://localhost/ProductsApi/test").Result;
            Console.WriteLine(r.ToString());

        }

        private static TokenResponse NewGetClientToken()
        {
            var client = new TokenClient(
               "https://localhost:44302/core/connect/token",
               "client",
               "secret");

            return client.RequestClientCredentialsAsync("read write").Result;
        }


	}
}
