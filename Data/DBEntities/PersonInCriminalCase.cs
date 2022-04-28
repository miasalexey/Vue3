using System;
using Data.DTOs.PersonsInCriminalCasesDTO;

namespace Data.DBEntities;


public class PersonInCriminalCase
{
    public Guid PersonInCriminalCaseId { get; set; }
    public Guid PersonId { get; set; }
    public Person? Person { get; set; }
    
    public Category Category { get; set; }
    
    public Guid CriminalCaseId { get; set; }
    public CriminalCase? CriminalCase { get; set; }

    public PersonInCriminalCase()
    {
        
    }

    public PersonInCriminalCase(PICCForPost piccForPost)
    {
        PersonInCriminalCaseId = new Guid();
        PersonId = piccForPost.PersonId;
        Category = piccForPost.Category;
        CriminalCaseId = piccForPost.CriminalCaseId;
    }
}

public enum Category
{
    Accused,
    Victim,
    Suspect,
    Witness
}