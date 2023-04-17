using Microsoft.AspNetCore.Mvc;
using Web_API.DataModels;
using Web_API.Models;
using Web_API.Repository.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;
        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        // GET: api/<UniversityController>
        [HttpGet]
        public async Task<ActionResult<ResultFormat<University>>> Get()
        {
            var entities = await _universityRepository.GetAllAsync();
            var result = new ResultFormat<University>
            {
                StatusCode = 200,
                Status = "Ok",
                Message = "Success",
                Data = entities.ToList()
            };
            return result;
        }

        // GET api/<UniversityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UniversityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UniversityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UniversityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
