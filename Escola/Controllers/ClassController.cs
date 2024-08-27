using Application.DTO;
using Application.UseCases;
using Data.Repositories;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    public IClassRepository _repository;

    public ClassController(IClassRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        var response = ClassUseCase.GetClasses(_repository);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var response = ClassUseCase.GetClassById(_repository, id);
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ClassDto request)
    {
        ClassUseCase.AddClass(_repository, request);

        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClassDto request)
    {
        try
        {
            ClassUseCase.UpdateClass(_repository, request, id);
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
            ClassUseCase.RemoveClass(_repository, id);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("change-status/{id}")]
    public IActionResult UpdateStatus(int id, [FromBody] UpdateStatusRequest request)
    {
        try
        {
            ClassUseCase.UpdateClassStatus(_repository, id, request);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}