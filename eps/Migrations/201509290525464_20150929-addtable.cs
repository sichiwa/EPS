namespace EPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150929addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "EPSMGR.REJECTREASON",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CheckSN = c.String(maxLength: 10),
                        Reason = c.String(maxLength: 50),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
        }
        
        public override void Down()
        {
            DropTable("EPSMGR.REJECTREASON");
        }
    }
}
