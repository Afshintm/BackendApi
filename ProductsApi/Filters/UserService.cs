using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Filters
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

    }

    public interface IUserServices
    {
        int Authenticate(string username, string password);
    }

    public class UserServices : IUserServices
    {
        private UserProvider _userProvider = new UserProvider();
        public int Authenticate(string username, string password)
        {
            var user = _userProvider.GetUser(username, password);
            if (user != null && user.UserId > 0)
            {
                return user.UserId;
            }
            return 0;
        }
    }

    /// <summary>
    /// read from database
    /// </summary>
    public class UserProvider
    {
        public BasicAuthenticationIdentity GetUser(string username, string password)
        {
            return new BasicAuthenticationIdentity("afshin", "Password!");
        }
    }
}
