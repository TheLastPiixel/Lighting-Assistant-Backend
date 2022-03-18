using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace LightingAssistant.Models
{
    public class Patterns
    {
        [Key] public string Pattern { get; set; }
    }
}