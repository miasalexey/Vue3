using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DBEntities;
using Data.DTOs.Person;
using Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class PersonService
{
    private readonly Context _context;

    public PersonService(Context context)
    {
        _context = context;
    }

    public async Task<Response<IEnumerable<PersonDTOForGet>>> GetPersons()
    {
        var response = new Response<IEnumerable<PersonDTOForGet>>();

        if (_context.Persons == null)
        {
            response.IsCompleted = false;
            return response;
        }

        var list = new List<PersonDTOForGet>(_context.Persons.Count());
        var tempList = await _context.Persons.ToListAsync();
        list.AddRange(tempList.Select(item => new PersonDTOForGet(item)));
        response.Data = list;
        return response;
    }

    public async Task<Response<PersonDTOForGet>> GetPersonById(Guid guid)
    {
        var response = new Response<PersonDTOForGet>();
        

        if (_context.Persons == null)
        {
            response.IsCompleted = false;
            return response;
        }

        var findPerson = await _context.Persons.FindAsync(guid);
        if (findPerson != null)
        {
            response.Data = new PersonDTOForGet(findPerson);
            return response;
        }

        response.IsCompleted = false;
        return response;
    }

    public async Task<Response<PersonDTOForGet>> CreatePerson(PersonDTOForPost personDtoForPost)
    {
        var response = new Response<PersonDTOForGet>();
        var newPerson = new Person()
        {
            Name = personDtoForPost.Name,
            Address = personDtoForPost.Address,
            SurName = personDtoForPost.SurName,
            CountCriminalRecord = personDtoForPost.CountCriminalRecord
        };
        if (_context.Persons != null)
        {
            await _context.Persons.AddAsync(newPerson);
            response.Data = new PersonDTOForGet(newPerson);
            await _context.SaveChangesAsync();
        }
        else response.IsCompleted = false;

        return response;
    }

    public async Task<Response<PersonDTOForGet>> UpdatePerson(PersonDTOForPut personDtoForPut)
    {
        var response = new Response<PersonDTOForGet>();
        var findPerson = new Person();
        if (_context.Persons != null)
        {
            findPerson = await _context.Persons.FindAsync(personDtoForPut.PersonId);
        }
        else response.IsCompleted = false;

        if (findPerson != null)
        {
            findPerson.Address = personDtoForPut.Address;
            findPerson.Name = personDtoForPut.Name;
            findPerson.SurName = personDtoForPut.SurName;
            findPerson.CountCriminalRecord = personDtoForPut.CountCriminalRecord;
        }
        else response.IsCompleted = false;

        return response;
    }

    public async Task<bool> DeletePerson(Guid id)
    {
        if (_context.Persons != null)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    
    
    
}