namespace EPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201509291addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "EPSMGR.REJECTPROFILE",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CloseStauts = c.String(nullable: false, maxLength: 10),
                        NextReviews = c.String(nullable: false),
                        MailTempID = c.String(nullable: false, maxLength: 3),
                        CreateAccount = c.String(nullable: false, maxLength: 6),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
        }
        
        public override void Down()
        {
            DropTable("EPSMGR.REJECTPROFILE");
        }
    }
}
