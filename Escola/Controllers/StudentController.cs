using Application.UseCases;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        // POST api/student
        [HttpPost]
        public IActionResult Post([FromBody] Student request)
        {
            var studentUseCase = new StudentUseCase();
            studentUseCase.AddStudent(request);
            return Created();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
