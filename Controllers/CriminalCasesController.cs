using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DTOs;
using Data.Services;
using Data.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CCIS_v1_server.Controllers;

[Route("api/criminalCases")]
[ApiController]
public class CriminalCaseController : ControllerBase
{
    private readonly CriminalCaseService _service;

    public CriminalCaseController(CriminalCaseService service)
    {
        _service = service;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<CriminalCasesDTOForGet>>> GetCriminalCases()
    {
        var response = await _service.GetCriminalCases();
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<CriminalCasesDTOForGet>> GetCriminalCaseById(Guid guid)
    {
        var response = await _service.GetCriminalCaseById(guid);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Response<CriminalCasesDTOForGet>>> CreateCriminalCase(
        CriminalCasesDTOForPost criminalCasesDtoForPost)
    {
        var response = await _service.CreateCriminalCase(criminalCasesDtoForPost);
        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return BadRequest();
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteCriminalCases(Guid id)
    {
        var res = await _service.DeleteCriminalCase(id);
        if (res)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpPut]
    public async Task<ActionResult<CriminalCasesDTOForGet>> UpdateCriminalCase(CriminalCasesDTOForPut criminalCasesDto)
    {
        var response = await _service.UpdateCriminalCase(criminalCasesDto);

        if (response.IsCompleted)
        {
            return Ok(response.Data);
        }

        return NotFound();
    }

    [HttpPost("addDecision")]
    public async Task<ActionResult<bool>> CreateCriminalDecision(CriminalCaseWithDecisionDTO criminalDecisionDto)
    {
        var res = await _service.AddCriminalDecisionToCriminalCase(criminalDecisionDto);
        if (res)
        {
            return Ok(res);
        }

        return BadRequest();
    }
}