using System;
using System.ComponentModel.DataAnnotations;
using Data.DTOs;

namespace Data.DBEntities;

public class CriminalDecision
{
    public Guid CriminalDecisionId { get; set; }

    [StringLength(300, MinimumLength = 5)]
    public string Decision { get; set; } = "";
    public CriminalCase? CriminalCase { get; set; }

    public CriminalDecision()
    {
        
    }
    
}