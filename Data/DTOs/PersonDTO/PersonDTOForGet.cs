using System;

namespace Data.DTOs.Person;

public class PersonDTOForGet
{
    public Guid PersonId { get; set; }
    public string Name { get; set; } = "";
    public string SurName { get; set; } = "";
    public string Address { get; set; } = "";
    public int CountCriminalRecord { get; set; }

    public PersonDTOForGet(DBEntities.Person person)
    {
        PersonId = person.PersonId;
        Name = person.Name;
        SurName = person.SurName;
        Address = person.Address;
        CountCriminalRecord = person.CountCriminalRecord;
    }
    
    
}