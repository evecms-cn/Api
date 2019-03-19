using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using EVEData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace EVEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EVEItemController : ControllerBase
    {
        private readonly ILogger logger;
        private IEVEDataService dataService;
        public EVEItemController(ILogger<EVEItemController> logger,IEVEDataService dataService)
        {
            this.logger = logger;
            this.dataService = dataService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<dynamic>> GetEVEItem(int id,[FromQuery]string propertyPath)
        {
            EVEItem item = await this.dataService.GetEVEItem(id);
            if(string.IsNullOrWhiteSpace(propertyPath))
            {
                return new JsonResult(item);
            }

            JToken token = JToken.FromObject(item);
            JToken result = token.SelectToken(propertyPath);
            if(result == null)
            {
                return string.Empty;
            }
            if(result.Children().Count()==0)
            {
                return result.Value<string>()??string.Empty;
            }
            return new JsonResult(result);
           
        }
    }
}