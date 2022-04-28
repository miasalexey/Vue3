using System;
using Data.DBEntities;

namespace Data.DTOs.PersonsInCriminalCasesDTO;

public class PICCForPost
{
    public Guid PersonId { get; set; }
    public Category Category { get; set; }
    public Guid CriminalCaseId { get; set; } 
}
