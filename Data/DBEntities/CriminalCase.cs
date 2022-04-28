using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.DTOs;

namespace Data.DBEntities;

public class CriminalCase
{
    public CriminalCase()
    {
        
    }

    public CriminalCase(CriminalCasesDTOForPost criminalCasesDtoForPost)
    {
        DataRegistration = criminalCasesDtoForPost.DataRegistration;
        Title = criminalCasesDtoForPost.Title;
        Region = criminalCasesDtoForPost.Region;
    }
    public Guid CriminalCaseId { get; set; } 
    public DateTime DataRegistration { get; set; } 
    
    [StringLength(300, MinimumLength = 5)]
    public string Title { get; set; } = "";
    [StringLength(50, MinimumLength = 5)]
    public string Region { get; set; } = "";
    
    public CriminalDecision? CriminalDecision { get; set; }
    public Guid? CriminalDecisionId { get; set; }
    
    public ICollection<PersonInCriminalCase> PersonInCriminalCases { get; set; } = new List<PersonInCriminalCase>();
}