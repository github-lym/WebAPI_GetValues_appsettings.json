using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
//using Option1.Models;

namespace Option1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppSettings appSettings;
        private readonly MyAppSettings myAppSettings;
        private readonly InfoSettings infoSettings;

        public ValuesController(IOptions<AppSettings> appSettings, IOptions<MyAppSettings> myAppSettings, IOptions<InfoSettings> infoSettings)
        {
            this.appSettings = appSettings.Value;
            this.myAppSettings = myAppSettings.Value;
            this.infoSettings = infoSettings.Value;
        }

        // GET api/values
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> GetAppSettings()
        {
            return new List<string> { this.appSettings.Key1, this.appSettings.Key2, this.appSettings.Key3, this.appSettings.Key4, this.appSettings.Key5 };
        }

        // GET api/values/myapp
        [HttpGet("MyApp")]
        public ActionResult<IEnumerable<string>> GetMyAppSettings()
        {
            return new List<string> { this.myAppSettings.Key1, this.myAppSettings.Key2 };
        }

        // GET api/values/info
        [HttpGet("Info")]
        public ActionResult<IEnumerable<Dictionary<string, string>>> GetInfos()
        {
            var ss = new List<Dictionary<string, string>> { this.infoSettings.P1, this.infoSettings.P2 };
            return ss;
        }

    }
}