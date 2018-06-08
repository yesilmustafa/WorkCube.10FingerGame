namespace WorkCube._10FingerGame.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DBV = c.Int(nullable: false),
                        DBK = c.Int(nullable: false),
                        Toplam = c.Int(nullable: false),
                        Dogru = c.Int(nullable: false),
                        Yanlis = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skors", "UserID", "dbo.Users");
            DropIndex("dbo.Skors", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Skors");
        }
    }
}
