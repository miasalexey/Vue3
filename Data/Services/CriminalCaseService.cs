using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBEntities;
using Data.DTOs;
using Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class CriminalCaseService
{
    private readonly Context _context;

    public CriminalCaseService(Context context)
    {
        _context = context;
    }

    public async Task<Response<IEnumerable<CriminalCasesDTOForGet>>> GetCriminalCases()
    {
        var response = new Response<IEnumerable<CriminalCasesDTOForGet>>();

        if (_context.CriminalCases == null)
        {
            response.IsCompleted = false;
            return response;
        }

        var list = new List<CriminalCasesDTOForGet>(_context.CriminalCases.Count());
        var tempList = await _context.CriminalCases.ToListAsync();
        list.AddRange(tempList.Select(item => new CriminalCasesDTOForGet(item)));
        response.Data = list;
        return response;
    }

    public async Task<Response<CriminalCasesDTOForGet>> CreateCriminalCase(
        CriminalCasesDTOForPost criminalCasesDtoForPost)
    {
        var response = new Response<CriminalCasesDTOForGet>();
        var newCriminalCase = new CriminalCase(criminalCasesDtoForPost);
        if (_context.CriminalCases == null)
        {
            response.IsCompleted = false;
            return response;
        }

        await _context.CriminalCases.AddAsync(newCriminalCase);
        await _context.SaveChangesAsync();

        response.Data = new CriminalCasesDTOForGet(newCriminalCase);
        return response;
    }

    public async Task<bool> DeleteCriminalCase(Guid id)
    {
        if (_context.CriminalCases == null) return false;
        var criminalCase = await _context.CriminalCases.FindAsync(id);
        if (criminalCase == null)
        {
            return false;
        }

        _context.CriminalCases.Remove(criminalCase);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Response<CriminalCasesDTOForGet>> GetCriminalCaseById(Guid guid)
    {
        var response = new Response<CriminalCasesDTOForGet>();
        var findCriminalCase = new CriminalCase();
        if (_context.CriminalCases != null)
        {
            findCriminalCase = await _context.CriminalCases.FindAsync(guid);
        }
        else response.IsCompleted = false;

        if (findCriminalCase != null)
        {
            response.Data = new CriminalCasesDTOForGet(findCriminalCase);
        }
        else response.IsCompleted = false;

        return response;
    }


    public async Task<Response<CriminalCasesDTOForGet>> UpdateCriminalCase(
        CriminalCasesDTOForPut updateCriminalCasesDto)
    {
        var response = new Response<CriminalCasesDTOForGet>();
        var findCriminalCase = new CriminalCase();
        if (_context.CriminalCases != null)
        {
            findCriminalCase = await _context.CriminalCases.FindAsync(updateCriminalCasesDto.CriminalCaseId);
        }
        else response.IsCompleted = false;


        if (findCriminalCase != null)
        {
            findCriminalCase.Region = updateCriminalCasesDto.Region;
            findCriminalCase.Title = updateCriminalCasesDto.Title;
        }
        else response.IsCompleted = false;

        return response;
    }

    public async Task<bool> AddCriminalDecisionToCriminalCase(CriminalCaseWithDecisionDTO criminalDecisionDto)
    {
        var newDecision = new CriminalDecision()
        {
            CriminalDecisionId = Guid.NewGuid(),
            Decision = criminalDecisionDto.Decision
        };
        if (_context.CriminalCases != null)
        {
            var findCase = await _context.CriminalCases.FindAsync(criminalDecisionDto.CriminalCaseGuid);
            if (findCase != null)
            {
                if (_context.CriminalDecisions != null) await _context.CriminalDecisions.AddAsync(newDecision);
                findCase.CriminalDecision = newDecision;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        return false;
    }

    
    
}