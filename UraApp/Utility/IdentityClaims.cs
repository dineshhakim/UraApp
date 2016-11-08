using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using UraApp.Models;
using UraApp.Services.Abstract;

namespace UraApp.Utility
{
    public class IdentityClaims
    {
        public readonly IUserService _userService;
        // public readonly ICompanyService CompanyService;


        public IdentityClaims(IUserService objUserService)
        {
            _userService = objUserService;
        }

        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {

            var user = new User { UserName = username, Password = password };
            //if (_userService==null)
            //{
            //    _userService=  GetService<IUserService>();
            //}
            // if (username == "TEST" && password == "TEST123")
            if (_userService.CheckLogin(user))
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
