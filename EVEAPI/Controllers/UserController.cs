using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User;
using Utility;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EVEAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public UserController(IHttpContextAccessor httpContextAccessor,IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginInfo loginInfo)
        {
            if (string.IsNullOrWhiteSpace(loginInfo?.UserName) || string.IsNullOrWhiteSpace(loginInfo.Password))
            {
                return this.Unauthorized();
            }
            string accessToken = string.Empty;
            string clientIp = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                accessToken = await this.authorizationService.GetAcceessToken(loginInfo?.UserName, loginInfo.Password, clientIp);
            }
            catch
            {
                return this.Unauthorized();
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return this.Unauthorized();
            }

            this.Response.Headers.Add("AccessToken", accessToken);
            LoginUser user = await this.authorizationService.GetLoginUser(accessToken);
            return new JsonResult(user);
   
        }
    }
}
