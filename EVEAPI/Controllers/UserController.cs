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
using Microsoft.Extensions.Logging;


namespace EVEAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger logger;
        public UserController(IHttpContextAccessor httpContextAccessor,IAuthorizationService authorizationService, ILogger<UserController> logger)
        {
            this.authorizationService = authorizationService;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginInfo loginInfo)
        {

            if (string.IsNullOrWhiteSpace(loginInfo?.UserName) || string.IsNullOrWhiteSpace(loginInfo.Password))
            {
                return this.Unauthorized();
            }
            this.logger.LogInformation("User {0} begin to login", loginInfo.UserName);
            string accessToken = string.Empty;
            string clientIp = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                accessToken = await this.authorizationService.GetAcceessToken(loginInfo?.UserName, loginInfo.Password, clientIp);
            }
            catch(Exception e)
            {
                this.logger.LogError("{0}\r\n{1}", e.Message, e.StackTrace);
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
