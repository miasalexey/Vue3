using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DBEntities;

public class Person
{
    public Guid PersonId { get; set; }
    
    [StringLength(50, MinimumLength = 5)]
    public string Name { get; set; } = "";
    [StringLength(50, MinimumLength = 5)]
    public string SurName { get; set; } = "";
    [StringLength(50, MinimumLength = 5)]
    public string Address { get; set; } = "";
    
    public int CountCriminalRecord { get; set; }

    
    public ICollection<PersonInCriminalCase> PersonInCriminalCases { get; set; } = new List<PersonInCriminalCase>();
}