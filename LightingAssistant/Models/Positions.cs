﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LightingAssistant.Models
{
    public class Positions
    {
        [Key] public string Position { get; set; }
    }
}