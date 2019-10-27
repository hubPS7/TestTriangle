using System;
using System.Linq;
using System.Threading.Tasks;
using TestTriangle.Contracts;
using TestTriangle.Entities.Extensions;
using TestTriangle.Entities.Modesl;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTriangle.API.Controllers
{
    [Route("api")]
    public class CountryController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public CountryController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("getallcountry")]
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                var Employee = await _repository.Country.GetCountries();
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
