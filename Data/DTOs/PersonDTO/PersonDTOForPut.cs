using System;

namespace Data.DTOs.Person;

public class PersonDTOForPut
{
    public Guid PersonId { get; set; }
    public string Name { get; set; } = "";
    public string SurName { get; set; } = "";
    public string Address { get; set; } = "";
    public int CountCriminalRecord { get; set; }
}