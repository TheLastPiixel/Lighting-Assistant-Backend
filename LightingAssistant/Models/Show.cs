using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightingAssistant.Models
{
    public class Show
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowID { get; set; }
        public string ShowName { get; set; }
        public Mover DLX { get; set; }
        public Mover Intimidators { get; set; }
        public Mover Robe { get; set; }
        public Mover OneZeroOnes { get; set; }
        public string BV { get; set; }
        public string Truss { get; set; }
        public string House { get; set; }
        public int MovementSpeed { get; set; }
        public string Note { get; set; }
    }
}