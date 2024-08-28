using Application.DTO;
using Application.UseCases;
using Data.Repositories;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

//TODO: deveria ter um uso de caso só para desativar o aluno, sem precisar colocar todos os dados
[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    public IRegisterRepository _repository;
    public IStudentRepository _repository2;
    public IClassRepository _repository3;

    public RegisterController(IRegisterRepository repository, IStudentRepository repository2, IClassRepository repository3)
    {
        _repository = repository;
        _repository2 = repository2;
        _repository3 = repository3;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Register>> GetAll()
    {
        var response = RegisterUseCase.GetRegisters(_repository);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Register> GetById(int id)
    {
        var response = RegisterUseCase.GetRegisterById(_repository, id);
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody] RegisterDto request)
    {
        RegisterUseCase.AddRegister(_repository, _repository2, _repository3, request);

        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RegisterDto request)
    {
        try
        {
            RegisterUseCase.UpdateRegister(_repository, request, id);
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
            RegisterUseCase.RemoveRegister(_repository, id);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}