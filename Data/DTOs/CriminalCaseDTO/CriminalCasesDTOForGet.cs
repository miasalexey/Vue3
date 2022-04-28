using System;
using Data.DBEntities;

namespace Data.DTOs;

public class CriminalCasesDTOForGet
{
    public Guid CriminalCaseId { get; set; } 
    public DateTime DataRegistration { get; set; } 
    
    public string Title { get; set; } = "";
    public string Region { get; set; } = "";
    
    public Guid CriminalDecisionId { get; set; } 

    public CriminalCasesDTOForGet(CriminalCase criminalCase)
    {
        CriminalCaseId = criminalCase.CriminalCaseId;
        DataRegistration = criminalCase.DataRegistration;
        Title = criminalCase.Title;
        Region = criminalCase.Region;
        if (criminalCase.CriminalDecisionId != null)
        {
            CriminalDecisionId = (Guid)criminalCase.CriminalDecisionId;
        } else  CriminalDecisionId = Guid.Empty;
    }

    public CriminalCasesDTOForGet()
    {
        
    }
}