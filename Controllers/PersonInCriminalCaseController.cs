using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTOs;
using Data.DTOs.PersonsInCriminalCasesDTO;
using Data.Services;
using Data.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CCIS_v1_server.Controllers;


[Route("api/personInCriminalCaseController")]
[ApiController]
public class PersonInCriminalCaseController : ControllerBase
{
    
    private readonly PersonsInCriminalCasesService _service;

    public PersonInCriminalCaseController(PersonsInCriminalCasesService service)
    {
        _service = service;
    }


    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<PICCForGet>>> GetPICCs()
    {
        var response = await _service.GetPICCs();
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NoContent();
    }


    [HttpPost]
    public async Task<ActionResult<Response<CriminalCasesDTOForGet>>> CreatePICC(PICCForPost piccForPost)
    {
        var response = await _service.CreatePICC(piccForPost);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return BadRequest();
    }
    

}