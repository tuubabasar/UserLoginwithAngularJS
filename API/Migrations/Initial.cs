namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //Databasede tabloyu oluþturur.
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                        RecordState = c.Int(nullable: false),
                        HType = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
