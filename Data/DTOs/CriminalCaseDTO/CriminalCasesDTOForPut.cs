using System;
using Data.DBEntities;

namespace Data.DTOs;

public class CriminalCasesDTOForPut
{
    
    public Guid CriminalCaseId { get; set; } 
    public string Title { get; set; } = "";
    public string Region { get; set; } = "";
    
    

    
}