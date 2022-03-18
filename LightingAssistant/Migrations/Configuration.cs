namespace LightingAssistant.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LightingAssistant.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LightingAssistant.Models.LightingAssistantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LightingAssistant.Models.LightingAssistantContext context)
        {
            context.Shows.AddOrUpdate(x => x.ShowID,
                new Show { ShowName = "What a beautiful name", 
                    DLX = new Mover { Colour = "Magenta", Pattern = "Dots", Position = "Stage", Movement = "Pan" }, 
                    Intimidators = new Mover { Colour = "Magenta", Pattern = "Dots", Position = "Roof", Movement = "Circle" }, 
                    Robe = new Mover { Colour = "Magenta", Position = "Out", Movement = "Circle" }, 
                    OneZeroOnes = new Mover { Colour = "Magenta", Position = "Out", Movement = "Tilt" }, 
                    BV = "Lavender", Truss = "Lavender", House = "Lavender", MovementSpeed = 20, Note = "DLX Stage > Roof @ 10%"
                }
            );

            context.Colours.AddOrUpdate(x => x.Colour,
                new Colours() {Colour = "White"},
                new Colours() { Colour = "Red" },
                new Colours() { Colour = "Magenta" },
                new Colours() { Colour = "Lavender" },
                new Colours() { Colour = "Blue" },
                new Colours() { Colour = "Yellow" },
                new Colours() { Colour = "Amber" },
                new Colours() { Colour = "Orange" },
                new Colours() { Colour = "Tungsten" },
                new Colours() { Colour = "Sky Blue" },
                new Colours() { Colour = "Aqua" }
            );

            context.Positions.AddOrUpdate(x => x.Position,
                new Positions() { Position = "Roof" },
                new Positions() { Position = "Out" },
                new Positions() { Position = "Stage" },
                new Positions() { Position = "People" },
                new Positions() { Position = "WL" }
            );

            context.Movements.AddOrUpdate(x => x.Movement,
                new Movements() { Movement = "Tilt" },
                new Movements() { Movement = "Pan" },
                new Movements() { Movement = "Circle" },
                new Movements() { Movement = "STOP" }
            );

            context.Patterns.AddOrUpdate(x => x.Pattern,
                new Patterns() { Pattern = "Open" },
                new Patterns() { Pattern = "Line" },
                new Patterns() { Pattern = "Circle" },
                new Patterns() { Pattern = "Dots" },
                new Patterns() { Pattern = "Flower" },
                new Patterns() { Pattern = "Raindrops" },
                new Patterns() { Pattern = "Blocks" },
                new Patterns() { Pattern = "Circles" },
                new Patterns() { Pattern = "Gatling Dots" },
                new Patterns() { Pattern = "DLX Triple Dot" },
                new Patterns() { Pattern = "Swirl" },
                new Patterns() { Pattern = "Warps" },
                new Patterns() { Pattern = "Pinspot" }
            );
        }
    }
}
