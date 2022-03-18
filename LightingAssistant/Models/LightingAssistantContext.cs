using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LightingAssistant.Models
{
    public class LightingAssistantContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LightingAssistantContext() : base("name=LightingAssistantContext")
        {
        }

        public System.Data.Entity.DbSet<LightingAssistant.Models.Show> Shows { get; set; }

        public System.Data.Entity.DbSet<LightingAssistant.Models.Colours> Colours { get; set; }

        public System.Data.Entity.DbSet<LightingAssistant.Models.Movements> Movements { get; set; }

        public System.Data.Entity.DbSet<LightingAssistant.Models.Patterns> Patterns { get; set; }

        public System.Data.Entity.DbSet<LightingAssistant.Models.Positions> Positions { get; set; }
    }
}
