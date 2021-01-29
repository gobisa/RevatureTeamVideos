using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepoApi.Service.Models;

namespace RepoApi.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private string apiUrl = "http://localhost:5000/User";
        private HttpClient _http = new HttpClient();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _http.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = Json.Convert<UserModel>(await response.Content.ReadAsStringAsync());

                return Ok(content);
            }
            return NotFound();
        }
    }
}
