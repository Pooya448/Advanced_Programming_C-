namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Text = c.String(),
                        NoteColor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
