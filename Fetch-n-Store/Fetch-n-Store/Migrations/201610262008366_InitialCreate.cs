namespace Fetch_n_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseID = c.Int(nullable: false, identity: true),
                        StatusCode = c.Int(nullable: false),
                        URL = c.String(nullable: false),
                        HTTP_Method = c.String(nullable: false),
                        ResponseTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
