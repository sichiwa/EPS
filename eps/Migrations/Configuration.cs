namespace EPS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EPS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EPS.DAL.EPSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EPS.DAL.EPSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.EPSROLES.Add(new EPSROLE()
            //{
            //    RId = 1,
            //    RoleName = "Admin",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSROLES.Add(new EPSROLE()
            //{
            //    RId = 2,
            //    RoleName = "OP",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSROLES.Add(new EPSROLE()
            //{
            //    RId = 3,
            //    RoleName = "OPManager",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSROLES.Add(new EPSROLE()
            //{
            //    RId = 4,
            //    RoleName = "Manager",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSROLES.Add(new EPSROLE()
            //{
            //    RId = 5,
            //    RoleName = "SYSManager",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 1,
            //    FuncName = "系統設定",
            //    Url = "#1",
            //    ShowOrder = 4,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 11,
            //    FuncName = "文件管理",
            //    Controller = "Document",
            //    Action = "Index",
            //    PId = 1,
            //    ShowOrder = 41,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 12,
            //    FuncName = "使用者管理",
            //    Controller = "Account",
            //    Action = "Index",
            //    PId = 1,
            //    ShowOrder = 42,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 13,
            //    FuncName = "權限管理",
            //    Controller = "Role",
            //    Action = "Index",
            //    PId = 1,
            //    ShowOrder = 43,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 14,
            //    FuncName = "功能管理",
            //    Controller = "Fun",
            //    Action = "Index",
            //    PId = 1,
            //    ShowOrder = 44,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 99,
            //    FuncName = "系統紀錄查詢",
            //    Controller = "Log",
            //    Action = "Search",
            //    ShowOrder = 7,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 97,
            //    FuncName = "日常檢核",
            //    Controller = "Process",
            //    Action = "Index",
            //    ShowOrder = 5,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 98,
            //    FuncName = "覆核管理",
            //    Controller = "Process",
            //    Action = "Review",
            //    ShowOrder = 6,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.FUNCS.Add(new FUNC()
            //{
            //    FId = 100,
            //    FuncName = "登出",
            //    Controller = "Account",
            //    Action = "Logout",
            //    ShowOrder = 8,
            //    IsEnable = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 11,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 12,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 13,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 14,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 100,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 1,
            //    FId = 99,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 2,
            //    FId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 2,
            //    FId = 11,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 2,
            //    FId = 97,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 2,
            //    FId = 99,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 2,
            //    FId = 100,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 3,
            //    FId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 3,
            //    FId = 11,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 3,
            //    FId = 98,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 3,
            //    FId = 100,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 4,
            //    FId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 4,
            //    FId = 11,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 4,
            //    FId = 98,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 4,
            //    FId = 100,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 5,
            //    FId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 5,
            //    FId = 11,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 5,
            //    FId = 98,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.ROLEFUNCMAPPINGS.Add(new ROLEFUNCMAPPING()
            //{
            //    RId = 5,
            //    FId = 100,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS015",
            //    UserName = "郭清章",
            //    UserEmail = "terry.kuo@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS170",
            //    UserName = "黃富彥",
            //    UserEmail = "fuyen@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS105",
            //    UserName = "陳漢榮",
            //    UserEmail = "Lex@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS023",
            //    UserName = "吳志明",
            //    UserEmail = "poli@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS046",
            //    UserName = "葉峯谷",
            //    UserEmail = "kenneth@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS070",
            //    UserName = "張立寰",
            //    UserEmail = "lihuan@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS103",
            //    UserName = "林依諴",
            //    UserEmail = "yi_hsien_lin@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS143",
            //    UserName = "詹景安",
            //    UserEmail = "andy.jhan@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS154",
            //    UserName = "蔡辰陽",
            //    UserEmail = "eric@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS158",
            //    UserName = "張國樺",
            //    UserEmail = "gh.jhang@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS182",
            //    UserName = "姚茗翔",
            //    UserEmail = "yaoming@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS191",
            //    UserName = "黃士瑋",
            //    UserEmail = "wythe@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS196",
            //    UserName = "王芊儒",
            //    UserEmail = "chienju@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS197",
            //    UserName = "吳盈杰",
            //    UserEmail = "jeffeywu@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.EPSUSERS.Add(new EPSUSER()
            //{
            //    UId = "TAS199",
            //    UserName = "林永祿",
            //    UserEmail = "vegalin@twca.com.tw",
            //    RId = 1,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "01",
            //    ClassValue = "日誌",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "02",
            //    ClassValue = "機房",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "03",
            //    ClassValue = "環控",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "05",
            //    ClassValue = "備份",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "06",
            //    ClassValue = "資安",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "07",
            //    ClassValue = "Win Server",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "08",
            //    ClassValue = "CA Server",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "09",
            //    ClassValue = "EV SSL",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "10",
            //    ClassValue = "ETMP",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKCLASSES.Add(new CHECKCLASS()
            //{
            //    ClassID = "04",
            //    ClassValue = "Network",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKSHIFTS.Add(new CHECKSHIFT()
            //{
            //    ShiftID = "01",
            //    ShiftValue = "早班",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKSHIFTS.Add(new CHECKSHIFT()
            //{
            //    ShiftID = "02",
            //    ShiftValue = "正常班",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKSHIFTS.Add(new CHECKSHIFT()
            //{
            //    ShiftID = "03",
            //    ShiftValue = "晚班",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKSHIFTS.Add(new CHECKSHIFT()
            //{
            //    ShiftID = "04",
            //    ShiftValue = "假日",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKSHIFTS.Add(new CHECKSHIFT()
            //{
            //    ShiftID = "00",
            //    ShiftValue = "ALL",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKTITLES.Add(new CHECKTITLE()
            //{
            //    CheckID = 1,
            //    Title = "機房工作日誌",
            //    Definition = "記錄每天系統狀況及處置行動及相關人員進出紀錄",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 1,
            //    ListName = "事件描述及行動",
            //    Definition = "簡述事件發生經過",
            //    ClassID = "01",
            //    CheckType = "2",
            //    ShowOrder = 1,
            //    ShiftID = "00",
            //    StartTime = "00:30",
            //    EndTime = "24:30",
            //    AlwaysShow = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 1,
            //    ListName = "交接事項",
            //    Definition = "交接給下位值班人員說明",
            //    ClassID = "01",
            //    CheckType = "2",
            //    ShowOrder = 2,
            //    ShiftID = "00",
            //    StartTime = "00:30",
            //    EndTime = "24:30",
            //    AlwaysShow = true,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKTITLES.Add(new CHECKTITLE()
            //{
            //    CheckID = 2,
            //    Title = "機房作業排程表",
            //    Definition = "每日機房檢查項目彙總",
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "01",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "01",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "04",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "03",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房硬體設備燈號紀錄",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS023",
            //    CheckType = "3",
            //    ShowOrder = 1,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});


            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "環境設施檢查紀錄表",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 2,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "環境設施檢查紀錄表",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 2,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "環境設施檢查紀錄表",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 2,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "環境設施檢查紀錄表",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 2,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "23:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "CA CRL(Mail)檢查",
            //    Definition = "",
            //    ClassID = "08",
            //    ChargerID = "TAS046",
            //    CheckType = "3",
            //    ShowOrder = 3,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "CA CRL(Mail)檢查",
            //    Definition = "",
            //    ClassID = "08",
            //    ChargerID = "TAS046",
            //    CheckType = "3",
            //    ShowOrder = 3,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "CA CRL(Mail)檢查",
            //    Definition = "",
            //    ClassID = "08",
            //    ChargerID = "TAS046",
            //    CheckType = "3",
            //    ShowOrder = 3,
            //    ShiftID = "03",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "CA CRL(Mail)檢查",
            //    Definition = "",
            //    ClassID = "08",
            //    ChargerID = "TAS046",
            //    CheckType = "3",
            //    ShowOrder = 3,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "01",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "04",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});
            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "03",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "消防面板自/手動切換檢查",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 4,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "04",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路名稱解析檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 5,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "23:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "防火牆LOG檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 6,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "防火牆LOG檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 6,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "防火牆LOG檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 6,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "防火牆LOG檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 6,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "23:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "NTP 時間校時檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 7,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "NTP 時間校時檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 7,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "NTP 時間校時檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 7,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "NTP 時間校時檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 7,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "NTP 時間校時檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 7,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "23:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DVR NAS檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 8,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DVR NAS檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 8,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DVR NAS檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 8,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DVR NAS檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 8,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "23:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路流量狀態存檔",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 9,
            //    ShiftID = "03",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路流量狀態存檔",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 9,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "資料備份檢查",
            //    Definition = "",
            //    ClassID = "05",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 10,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "資料備份檢查",
            //    Definition = "",
            //    ClassID = "05",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 10,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DCHP檢查",
            //    Definition = "",
            //    ClassID = "07",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 11,
            //    ShiftID = "01",
            //    StartTime = "07:00",
            //    EndTime = "08:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "DCHP檢查",
            //    Definition = "",
            //    ClassID = "07",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 11,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "EV SSL憑證廢止狀態工具檢查",
            //    Definition = "",
            //    ClassID = "09",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 12,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "EV SSL憑證廢止狀態工具檢查",
            //    Definition = "",
            //    ClassID = "09",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 12,
            //    ShiftID = "04",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "McAfee病毒碼檢查",
            //    Definition = "",
            //    ClassID = "07",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 13,
            //    ShiftID = "01",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "McAfee病毒碼檢查",
            //    Definition = "",
            //    ClassID = "07",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 13,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "01",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "04",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "01",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "04",
            //    StartTime = "13:30",
            //    EndTime = "14:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "03",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "空調主機狀態檢查",
            //    Definition = "",
            //    ClassID = "03",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 14,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "磁帶存放至異地保險櫃作業",
            //    Definition = "",
            //    ClassID = "05",
            //    ChargerID = "TAS158",
            //    CheckType = "3",
            //    ShowOrder = 15,
            //    ShiftID = "03",
            //    StartTime = "15:00",
            //    EndTime = "16:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房環境整理及文件歸檔作業",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 16,
            //    ShiftID = "04",
            //    StartTime = "17:30",
            //    EndTime = "18:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "機房環境整理及文件歸檔作業",
            //    Definition = "",
            //    ClassID = "02",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 16,
            //    ShiftID = "03",
            //    StartTime = "22:00",
            //    EndTime = "22:00",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "分析及評估資安動態檢查",
            //    Definition = "",
            //    ClassID = "06",
            //    ChargerID = "TAS197",
            //    CheckType = "3",
            //    ShowOrder = 17,
            //    ShiftID = "01",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "網路流量狀態監控存檔檢查",
            //    Definition = "",
            //    ClassID = "04",
            //    ChargerID = "TAS154",
            //    CheckType = "3",
            //    ShowOrder = 18,
            //    ShiftID = "01",
            //    StartTime = "09:30",
            //    EndTime = "10:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "ETMP服務啟動檢查",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 19,
            //    ShiftID = "01",
            //    StartTime = "07:05",
            //    EndTime = "07:10",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所公開資料已下載(PF001、3、4、6、8、9、10、11、12、13、14、3、15、16、RF001、2、3)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 20,
            //    ShiftID = "01",
            //    StartTime = "08:05",
            //    EndTime = "08:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所央資撥款資料已下載(CF021)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 21,
            //    ShiftID = "01",
            //    StartTime = "11:00",
            //    EndTime = "11:30",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所公開款資料已下載(PF002、5)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 22,
            //    ShiftID = "01",
            //    StartTime = "13:45",
            //    EndTime = "14:05",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所央資撥款資料已下載(CF020)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 23,
            //    ShiftID = "03",
            //    StartTime = "15:35",
            //    EndTime = "16:05",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所公開款資料已下載(PF007)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 24,
            //    ShiftID = "03",
            //    StartTime = "17:50",
            //    EndTime = "18:20",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "證交所公開款資料已下載(RF004)",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 25,
            //    ShiftID = "03",
            //    StartTime = "20:20",
            //    EndTime = "20:50",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.CHECKLISTS.Add(new CHECKLIST()
            //{
            //    CheckID = 2,
            //    ListName = "ETMP服務關閉檢查",
            //    Definition = "",
            //    ClassID = "10",
            //    ChargerID = "TAS103",
            //    CheckType = "3",
            //    ShowOrder = 26,
            //    ShiftID = "03",
            //    StartTime = "23:00",
            //    EndTime = "23:10",
            //    AlwaysShow = false,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.REVIEWPROFILES.Add(new REVIEWPROFILE()
            //{
            //    CloseStauts = "晚班檢核完畢",
            //    NextReview = 3,
            //    MailTempID = "001",
            //    CreateAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpadteAccount = "TAS170",
            //    UpdateTime = DateTime.Now
            //});

            //context.REVIEWPROFILES.Add(new REVIEWPROFILE()
            //{
            //    CloseStauts = "領班覆核完畢",
            //    NextReview = 4,
            //    MailTempID = "001",
            //     CreateAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpadteAccount = "TAS170",
            //    UpdateTime = DateTime.Now
            //});

            //context.REVIEWPROFILES.Add(new REVIEWPROFILE()
            //{
            //    CloseStauts = "主管覆核完畢",
            //    NextReview = 5,
            //    MailTempID = "001",
            //    CreateAccount="TAS170",
            //    CreateTime=DateTime.Now,
            //    UpadteAccount="TAS170",
            //    UpdateTime=DateTime.Now
            //});

            //context.SaveChanges();
        }
    }
}
