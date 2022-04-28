using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBEntities;
using Data.DTOs.PersonsInCriminalCasesDTO;
using Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PersonsInCriminalCasesService
{
    private readonly Context _context;

    public PersonsInCriminalCasesService(Context context)
    {
        _context = context;
    }

    public async Task<Response<IEnumerable<PICCForGet>>> GetPICCs()
    {
        var response = new Response<IEnumerable<PICCForGet>>();
        if (_context.PersonInCriminalCases == null)
        {
            response.IsCompleted = false;
            return response;
        }

        var list = new List<PICCForGet>(_context.PersonInCriminalCases.Count());
        var tempList = await _context.PersonInCriminalCases.ToListAsync();
        list.AddRange(tempList.Select(item => new PICCForGet(item)));
        response.Data = list;
        return response;

    }

    public async Task<Response<PICCForGet>> CreatePICC(PICCForPost piccForPost)
    {
        var response = new Response<PICCForGet>();
        var checkCC = CheckCriminalCaseInBase(piccForPost.CriminalCaseId);
        var checkPerson = CheckPersonInBase(piccForPost.PersonId);

        if (checkCC.Result && checkPerson.Result)
        {
            var newPICC = new PersonInCriminalCase(piccForPost);
            if (_context.PersonInCriminalCases != null)
            {
                await _context.PersonInCriminalCases.AddAsync(newPICC);
                response.Data = new PICCForGet(newPICC);
                response.IsCompleted = true;
                return response;
            }

            response.IsCompleted = false;
        }
        else response.IsCompleted = false;

        return response;
    }

    private async Task<bool> CheckCriminalCaseInBase(Guid id)
    {
        if (_context.CriminalCases == null) return false;
        var findCase = await _context.CriminalCases.FindAsync(id);
        return findCase != null;
    }

    private async Task<bool> CheckPersonInBase(Guid id)
    {
        if (_context.Persons == null) return false;
        var findCase = await _context.Persons.FindAsync(id);
        return findCase != null;
    }
}