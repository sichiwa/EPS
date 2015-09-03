using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPS.Models;

namespace EPS.DAL
{
    public class EPSInitializer: DropCreateDatabaseIfModelChanges<EPSContext>
    {
        protected override void Seed(EPSContext context)
        {
            base.Seed(context);
            //context.ROLES.Add(new EPSROLE()
            //{
            //    RId = 1,
            //    RoleName = "Admin",
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
            //    PId=1,
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
            //    PId=1,
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
            //    PId=1,
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
            //    PId=1,
            //    ShowOrder = 44,
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
            //    ShowOrder = 5,
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.USERS.Add(new EPSUSER()
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

            //context.CHECKTITLES.Add(new CHECKTITLE()
            //{
            //    CheckID = 1,
            //    Title = "機房工作日誌",
            //    Definition = "記錄每天系統狀況及處置行動及相關人員進出紀錄",
            //    AlwaysShow = true,
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
            //    CheckType = "字串",
            //    ShowOrder = 1,
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
            //    CheckType = "字串",
            //    ShowOrder = 2,
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
            //    CheckType = "字串",
            //    ShowOrder = 1,
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
            //    CheckType = "字串",
            //    ShowOrder = 2,
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
            //    CheckType = "字串",
            //    ShowOrder = 3,
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
            //    CheckType = "字串",
            //    ShowOrder = 4,
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
            //    CheckType = "字串",
            //    ShowOrder = 5,
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
            //    CheckType = "字串",
            //    ShowOrder = 6,
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
            //    CheckType = "字串",
            //    ShowOrder = 7,
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
            //    CheckType = "字串",
            //    ShowOrder = 8,
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
            //    CheckType = "字串",
            //    ShowOrder = 9,
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
            //    CheckType = "字串",
            //    ShowOrder = 10,
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
            //    CheckType = "字串",
            //    ShowOrder = 11,
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
            //    CheckType = "字串",
            //    ShowOrder = 12,
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
            //    CheckType = "字串",
            //    ShowOrder = 13,
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
            //    CheckType = "字串",
            //    ShowOrder = 14,
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
            //    CheckType = "字串",
            //    ShowOrder = 15,
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
            //    CheckType = "字串",
            //    ShowOrder = 16,
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
            //    CheckType = "字串",
            //    ShowOrder = 17,
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
            //    CheckType = "字串",
            //    ShowOrder = 18,
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
            //    CheckType = "字串",
            //    ShowOrder = 19,
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
            //    CheckType = "字串",
            //    ShowOrder = 20,
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
            //    CheckType = "字串",
            //    ShowOrder = 21,
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
            //    CheckType = "字串",
            //    ShowOrder = 22,
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
            //    CheckType = "字串",
            //    ShowOrder = 23,
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
            //    CheckType = "字串",
            //    ShowOrder = 24,
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
            //    CheckType = "字串",
            //    ShowOrder = 25,
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
            //    CheckType = "字串",
            //    ShowOrder = 26,
            //    CreateAccount = "TAS170",
            //    UpadteAccount = "TAS170",
            //    CreateTime = DateTime.Now,
            //    UpdateTime = DateTime.Now
            //});

            //context.SaveChanges();
        }
    }
}