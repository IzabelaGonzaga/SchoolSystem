using Application.DTO;
using Application.UseCases;
using Data.Repositories;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetAll()
        {
            var response = TeacherUseCase.GetTeachers(_repository);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> GetById(int id)
        {
            var response = TeacherUseCase.GetTeacherById(_repository, id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeacherDto request)
        {
            TeacherUseCase.AddTeacher(_repository, request);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TeacherDto request)
        {
            try
            {
                TeacherUseCase.UpdateTeacher(_repository, request, id);
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
                TeacherUseCase.RemoveTeacher(_repository, id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
