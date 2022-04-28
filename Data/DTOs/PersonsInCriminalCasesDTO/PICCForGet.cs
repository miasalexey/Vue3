using System;
using Data.DBEntities;

namespace Data.DTOs.PersonsInCriminalCasesDTO;

public class PICCForGet
{
    public Guid PersonInCriminalCaseId { get; set; }
    public Guid PersonId { get; set; }
    public Category Category { get; set; }
    public Guid CriminalCaseId { get; set; }

    public PICCForGet(PersonInCriminalCase personInCriminalCase)
    {
        PersonInCriminalCaseId = personInCriminalCase.PersonInCriminalCaseId;
        PersonId = personInCriminalCase.PersonId;
        Category = personInCriminalCase.Category;
        CriminalCaseId = personInCriminalCase.CriminalCaseId;
    }
}

