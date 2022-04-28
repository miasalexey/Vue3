using System;

namespace Data.DTOs;

public class CriminalCasesDTOForPost
{
    public DateTime DataRegistration { get; set; }
    public string Title { get; set; } = "";
    public string Region { get; set; } = "";
}