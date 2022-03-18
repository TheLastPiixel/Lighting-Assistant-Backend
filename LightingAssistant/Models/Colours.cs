using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LightingAssistant.Models
{
    public class Colours
    {
        [Key] public string Colour { get; set; }
    }
}