using Application.DTO;
using Application.UseCases;
using Data.Repositories;
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

    [HttpPost]
    public IActionResult Post([FromBody] ClassDto request)
    {
        ClassUseCase.AddClass(request, _repository);

        return Created();
    }

    // GET: api/<ClassController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ClassController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // PUT api/<ClassController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ClassController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}