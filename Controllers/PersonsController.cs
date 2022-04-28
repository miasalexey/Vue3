using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTOs.Person;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCIS_v1_server.Controllers;

[Route("api/personsController")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly PersonService _service;

    public PersonsController(PersonService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PersonDTOForGet>>> GetPersons()
    {
        var response = await _service.GetPersons();
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<PersonDTOForGet>> GetPersonById(Guid guid)
    {
        var response = await _service.GetPersonById(guid);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<PersonDTOForGet>> CreatePerson(PersonDTOForPost personDtoForPost)
    {
        var response = await _service.CreatePerson(personDtoForPost);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<ActionResult<PersonDTOForGet>> UpdatePerson(PersonDTOForPut personDtoForPut)
    {
        var response = await _service.UpdatePerson(personDtoForPut);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NotFound();
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeletePerson(Guid guid)
    {
        var response = await _service.DeletePerson(guid);
        if (response)
        {
            return Ok(response);
        }

        return NotFound();
    }
}