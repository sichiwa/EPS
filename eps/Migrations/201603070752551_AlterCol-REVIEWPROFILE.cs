namespace EPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterColREVIEWPROFILE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "EPSMGR.CHECKCLASS",
                c => new
                    {
                        ClassID = c.String(nullable: false, maxLength: 10, unicode: false),
                        ClassValue = c.String(nullable: false, maxLength: 50),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "EPSMGR.CHECKLIST",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        CheckID = c.Int(nullable: false),
                        ListName = c.String(nullable: false, maxLength: 200),
                        Definition = c.String(maxLength: 1000),
                        StartTime = c.String(nullable: false, maxLength: 20, unicode: false),
                        EndTime = c.String(nullable: false, maxLength: 20, unicode: false),
                        ShiftID = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        ClassID = c.String(maxLength: 20),
                        CheckType = c.String(nullable: false, maxLength: 10),
                        AlwaysShow = c.Boolean(nullable: false),
                        ChargerID = c.String(maxLength: 6, unicode: false),
                        ShowOrder = c.Int(nullable: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "EPSMGR.CHECKPROCESSDETAIL",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CheckSN = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        CheckID = c.Int(nullable: false),
                        ListID = c.Int(nullable: false),
                        ShiftID = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        CheckResult = c.String(nullable: false, maxLength: 500),
                        CheckDate = c.String(nullable: false, maxLength: 8),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "EPSMGR.CHECKPROCESS",
                c => new
                    {
                        CheckSN = c.String(nullable: false, maxLength: 10),
                        CheckDate = c.String(nullable: false, maxLength: 8),
                        CheckID = c.Int(nullable: false),
                        Notes = c.String(maxLength: 1000),
                        Attachment = c.String(),
                        CloseStutus = c.String(nullable: false, maxLength: 10),
                        CrrentStatus = c.String(maxLength: 6, unicode: false),
                        NextReview = c.String(maxLength: 6, unicode: false),
                        FinalReview = c.String(maxLength: 6, unicode: false),
                        ShiftOne = c.String(maxLength: 6),
                        ShiftOneSign = c.String(maxLength: 4000),
                        ShiftThree = c.String(maxLength: 6),
                        ShiftThreeSign = c.String(maxLength: 4000),
                        ShiftFour = c.String(maxLength: 6),
                        ShiftFourSign = c.String(maxLength: 4000),
                        ShiftTop = c.String(),
                        ShiftTopSign = c.String(maxLength: 4000),
                        ManageOne = c.String(),
                        ManageOneSign = c.String(maxLength: 4000),
                        ManageTop = c.String(),
                        ManageTopSign = c.String(maxLength: 4000),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckSN);
            
            CreateTable(
                "EPSMGR.CHECKSHIFT",
                c => new
                    {
                        ShiftID = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false),
                        ShiftValue = c.String(nullable: false, maxLength: 50),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftID);
            
            CreateTable(
                "EPSMGR.CHECKTITLE",
                c => new
                    {
                        CheckID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Definition = c.String(maxLength: 500),
                        Attachment = c.String(),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CheckID);
            
            CreateTable(
                "EPSMGR.EPSROLE",
                c => new
                    {
                        RId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                        ReviewAccount = c.String(maxLength: 6, unicode: false),
                        ReviewTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.RId);
            
            CreateTable(
                "EPSMGR.EPSUSER",
                c => new
                    {
                        UId = c.String(nullable: false, maxLength: 6, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 5),
                        UserPwd = c.String(maxLength: 200),
                        UserEmail = c.String(maxLength: 100, unicode: false),
                        RId = c.Int(nullable: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                        ReviewAccount = c.String(maxLength: 6, unicode: false),
                        ReviewTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UId);
            
            CreateTable(
                "EPSMGR.FUNC",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        FId = c.Int(nullable: false),
                        FuncName = c.String(nullable: false, maxLength: 20),
                        PId = c.Int(nullable: false),
                        Controller = c.String(maxLength: 50, unicode: false),
                        Action = c.String(maxLength: 50, unicode: false),
                        Url = c.String(maxLength: 200, unicode: false),
                        ShowOrder = c.Int(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                        ReviewAccount = c.String(maxLength: 6, unicode: false),
                        ReviewTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "EPSMGR.MAILSERVER",
                c => new
                    {
                        MailServerID = c.Int(nullable: false, identity: true),
                        ServerIP = c.String(nullable: false, maxLength: 100),
                        ServerPort = c.Int(nullable: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MailServerID);
            
            CreateTable(
                "EPSMGR.MAILTEMPLATE",
                c => new
                    {
                        MailTempID = c.String(nullable: false, maxLength: 3),
                        TemplateName = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Body = c.String(nullable: false),
                        Sender = c.String(nullable: false, maxLength: 50, unicode: false),
                        Receiver = c.String(nullable: false, maxLength: 1000, unicode: false),
                        CC = c.String(nullable: false, maxLength: 1000, unicode: false),
                        IsHTML = c.Boolean(nullable: false),
                        IsSSL = c.Boolean(nullable: false),
                        MailServerID = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MailTempID);
            
            CreateTable(
                "EPSMGR.REJECTPROFILE",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CloseStauts = c.String(nullable: false, maxLength: 10),
                        NextReviews = c.String(nullable: false, maxLength: 50),
                        MailTempID = c.String(nullable: false, maxLength: 3),
                        CreateAccount = c.String(nullable: false, maxLength: 6),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
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
            
            CreateTable(
                "EPSMGR.REVIEWDATA",
                c => new
                    {
                        ReviewSN = c.Int(nullable: false, identity: true),
                        CheckDate = c.String(nullable: false, maxLength: 8),
                        CheckSN = c.String(nullable: false, maxLength: 10),
                        ListName = c.String(nullable: false, maxLength: 200),
                        ShiftOneChecked = c.String(maxLength: 10),
                        ShiftTrheeChecked = c.String(maxLength: 10),
                        ShiftFourChecked = c.String(maxLength: 10),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewSN);
            
            CreateTable(
                "EPSMGR.REVIEWPROFILE",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        CloseStauts = c.String(nullable: false, maxLength: 10),
                        NextReviews = c.String(nullable: false, maxLength: 50),
                        MailTempID = c.String(nullable: false, maxLength: 3),
                        CreateAccount = c.String(nullable: false, maxLength: 6),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "EPSMGR.ROLEAUTHORITYLIST",
                c => new
                    {
                        RoleAuthority = c.String(nullable: false, maxLength: 5, unicode: false),
                        Definition = c.String(maxLength: 50),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                        ReviewAccount = c.String(maxLength: 6, unicode: false),
                        ReviewTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleAuthority);
            
            CreateTable(
                "EPSMGR.ROLEFUNCMAPPING",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        RId = c.Int(nullable: false),
                        FId = c.Int(nullable: false),
                        RoleAuthority = c.String(maxLength: 5, unicode: false),
                        CreateAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpadteAccount = c.String(nullable: false, maxLength: 6, unicode: false),
                        UpdateTime = c.DateTime(nullable: false),
                        ReviewAccount = c.String(maxLength: 6, unicode: false),
                        ReviewTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.SN);
            
            CreateTable(
                "EPSMGR.SYSTEMLOG",
                c => new
                    {
                        SN = c.Int(nullable: false, identity: true),
                        UId = c.String(maxLength: 6, unicode: false),
                        Controller = c.String(maxLength: 20),
                        Action = c.String(maxLength: 100),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        SuccessCount = c.Int(nullable: false),
                        FailCount = c.Int(nullable: false),
                        Result = c.Boolean(nullable: false),
                        Msg = c.String(),
                    })
                .PrimaryKey(t => t.SN);
            
        }
        
        public override void Down()
        {
            DropTable("EPSMGR.SYSTEMLOG");
            DropTable("EPSMGR.ROLEFUNCMAPPING");
            DropTable("EPSMGR.ROLEAUTHORITYLIST");
            DropTable("EPSMGR.REVIEWPROFILE");
            DropTable("EPSMGR.REVIEWDATA");
            DropTable("EPSMGR.REJECTREASON");
            DropTable("EPSMGR.REJECTPROFILE");
            DropTable("EPSMGR.MAILTEMPLATE");
            DropTable("EPSMGR.MAILSERVER");
            DropTable("EPSMGR.FUNC");
            DropTable("EPSMGR.EPSUSER");
            DropTable("EPSMGR.EPSROLE");
            DropTable("EPSMGR.CHECKTITLE");
            DropTable("EPSMGR.CHECKSHIFT");
            DropTable("EPSMGR.CHECKPROCESS");
            DropTable("EPSMGR.CHECKPROCESSDETAIL");
            DropTable("EPSMGR.CHECKLIST");
            DropTable("EPSMGR.CHECKCLASS");
        }
    }
}
