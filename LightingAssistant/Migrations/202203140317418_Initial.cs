namespace LightingAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Colour = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Colour);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Movement = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Movement);
            
            CreateTable(
                "dbo.Patterns",
                c => new
                    {
                        Pattern = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Pattern);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Position = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Position);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Positions");
            DropTable("dbo.Patterns");
            DropTable("dbo.Movements");
            DropTable("dbo.Colours");
        }
    }
}
