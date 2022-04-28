using System;

namespace Data.DTOs;

public class CriminalCaseWithDecisionDTO
{
    public Guid CriminalCaseGuid { get; set; } 
    public string Decision { get; set; } = "";
}