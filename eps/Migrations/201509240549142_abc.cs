namespace EPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("EPSMGR.REVIEWDATA");
            AlterColumn("EPSMGR.REVIEWDATA", "ReviewSN", c => c.Int(nullable: false, identity: true));
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftOneChecked", c => c.Boolean(nullable: false));
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftTrheeChecked", c => c.Boolean(nullable: false));
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftFourChecked", c => c.Boolean(nullable: false));
            AddPrimaryKey("EPSMGR.REVIEWDATA", "ReviewSN");
        }
        
        public override void Down()
        {
            DropPrimaryKey("EPSMGR.REVIEWDATA");
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftFourChecked", c => c.String());
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftTrheeChecked", c => c.String());
            AlterColumn("EPSMGR.REVIEWDATA", "ShiftOneChecked", c => c.String());
            AlterColumn("EPSMGR.REVIEWDATA", "ReviewSN", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("EPSMGR.REVIEWDATA", "ReviewSN");
        }
    }
}
