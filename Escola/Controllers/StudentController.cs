using Application.DTO;
using Application.UseCases;
using Data.Repositories;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var response = StudentUseCase.GetStudents(_repository);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var response = StudentUseCase.GetStudentById(_repository, id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentDto request)
        {
            StudentUseCase.AddStudent(_repository, request);

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDto request)
        {
            try
            {
                StudentUseCase.UpdateStudent(_repository, request, id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                StudentUseCase.RemoveStudent(_repository, id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}