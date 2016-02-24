using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;
using EPS.DAL;
using EPS.ViewModels.Document;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;

namespace EPS.Controllers
{
    [CheckSessionFilterAttribute]
    public class DocumentController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Document
        public ActionResult Index()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "Index";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                var query = context.CHECKTITLES.ToList();
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = query.Count();
                SL.SuccessCount = query.Count();
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得文件清單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(query);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得文件清單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult Create()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "Create";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vDOCUMENT_Manage VDM = new vDOCUMENT_Manage();

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立文件表單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VDM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立文件表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Dcoument");
            }
        }

        [HttpPost]
        public ActionResult Create(vDOCUMENT_Manage VDM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "Create";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                if (ModelState.IsValid)
                {
                    CHECKTITLE CT = new CHECKTITLE();
                    CT.Title = VDM.Title;
                    CT.Definition = VDM.Definition;
                    CT.Attachment = VDM.Attachment;
                    CT.CreateAccount = Session["UserID"].ToString().Trim();
                    CT.CreateTime = DateTime.Now;
                    CT.UpadteAccount = Session["UserID"].ToString().Trim();
                    CT.UpdateTime = DateTime.Now;

                    context.CHECKTITLES.Add(CT);
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立文件作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["CreateMsg"] = "<script>alert('新增成功');</script>";

                    return RedirectToAction("AddItem", "Document", new { CheckID = CT.CheckID, CheckTitle = CT.Title });
                }
                else
                {
                    TempData["CreateMsg"] = "<script>alert('新增失敗');</script>";

                    return RedirectToAction("Create", "Document");
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立文件作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Create", "Document");
            }
        }

        public ActionResult ListItem(int CheckID, string Title)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "ListItem";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                TempData["CheckID"] = CheckID;
                TempData["Title"] = Title;
                var query = from cl in context.CHECKLISTS
                            where cl.CheckID == CheckID
                            orderby cl.ShowOrder descending
                            join cs in context.CHECKSHIFTS on cl.ShiftID equals cs.ShiftID
                            join c in context.CHECKCLASSES on cl.ClassID equals c.ClassID
                            join u in context.EPSUSERS on cl.ChargerID equals u.UId into x
                            from y in x.DefaultIfEmpty()
                            select new vCHECKLIST
                            {
                                ListID = cl.ListID,
                                CheckID=cl.CheckID,
                                ListName=cl.ListName,
                                Definition=cl.Definition,
                                StartTime=cl.StartTime,
                                EndTime=cl.EndTime,
                                ShiftName=cs.ShiftValue,
                                ClassName=c.ClassValue,
                                Charger=y.UserName,
                                AlwaysShow=cl.AlwaysShow,
                                ShowOrder=cl.ShowOrder,
                                CreateAccount = cl.CreateAccount,
                                CreateTime = cl.CreateTime,
                                UpadteAccount = cl.UpadteAccount,
                                UpdateTime = cl.UpdateTime
                            };

                if (query.Count() > 0)
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得檢核項目清單作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return View(query.ToList());
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得檢核項目清單作成功" + "訊息["+ Title + "文件內尚未有檢核項目]";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return RedirectToAction("Index", "Dcoument");
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得檢核項目清單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Dcoument");
            }
        }

        public ActionResult AddItem(int CheckID, string Title)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "AddItem";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vCHECKLIST_Manage VCTM = new vCHECKLIST_Manage();
                VCTM.CheckID = CheckID;
                VCTM.CheckTitle = Title;
                TempData["Title"] = Title;

                //取得班別清單
                var query1 = from s in context.CHECKSHIFTS
                             select new
                             {
                                 s.ShiftID,
                                 s.ShiftValue
                             };

                VCTM.ShiftIDList = new SelectList(query1, "ShiftID", "ShiftValue");

                //取得分類清單
                var query2 = from c in context.CHECKCLASSES
                             select new
                             {
                                 c.ClassID,
                                 c.ClassValue
                             };

                VCTM.ClassIDList = new SelectList(query2, "ClassID", "ClassValue");

                //取得負責人清單
                var query = from u in context.EPSUSERS
                            select new
                            {
                                u.UId,
                                u.UserName
                            };

                VCTM.ChargerList = new SelectList(query, "UId", "UserName");
                VCTM.AlwaysShow = true;
                VCTM.StartTime = "00:00";
                VCTM.EndTime = "24:00";
                VCTM.ShowOrder = getShowOrder(CheckID);

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立檢核項目表單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VCTM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立檢核項目表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Create", "Document");
            }
        }

        [HttpPost]
        public ActionResult AddItem(vCHECKLIST_Manage VCLM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "AddItem";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                if (ModelState.IsValid)
                {
                    CHECKLIST CL = new CHECKLIST();
                    CL.CheckID = VCLM.CheckID;
                    CL.ListName = VCLM.ListName;
                    CL.Definition = VCLM.Definition;
                    CL.CheckType = VCLM.CheckType;
                    CL.ClassID = VCLM.ClassID;
                    CL.ChargerID = VCLM.ChargerID;
                    CL.ShiftID = VCLM.ShiftID;
                    CL.StartTime = VCLM.StartTime;
                    CL.EndTime = VCLM.EndTime;
                    CL.AlwaysShow = VCLM.AlwaysShow;
                    CL.ShowOrder = VCLM.ShowOrder;
                    CL.CreateAccount = Session["UserID"].ToString().Trim();
                    CL.CreateTime = DateTime.Now;
                    CL.UpadteAccount = Session["UserID"].ToString().Trim();
                    CL.UpdateTime = DateTime.Now;

                    context.CHECKLISTS.Add(CL);
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立檢核項目作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["CreateMsg"] = "<script>alert('新增成功');</script>";

                    return RedirectToAction("AddItem", "Document", new { CheckID = VCLM.CheckID, Title = VCLM.CheckTitle });

                }
                else
                {
                    TempData["CreateMsg"] = "<script>alert('新增失敗');</script>";

                    return RedirectToAction("AddItem", "Document", new { CheckID = VCLM.CheckID, Title = VCLM.CheckTitle });
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立檢核項目作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("AddItem", "Document", new { CheckID = VCLM.CheckID, Title = VCLM.CheckTitle });
            }
        }

        public ActionResult EditItem(int ListID)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "EditItem";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                CHECKLIST CL = context.CHECKLISTS.Find(ListID);
                CHECKTITLE CT = context.CHECKTITLES.Find(CL.CheckID);
                vCHECKLIST_Manage VCTM = new vCHECKLIST_Manage();

                VCTM.CheckTitle = CT.Title;
                VCTM.CheckID = CL.CheckID;
                VCTM.ListName = CL.ListName;
                VCTM.Definition = CL.Definition;
                VCTM.CheckTitle = CT.Title;
                TempData["CheckID"] = CL.CheckID;
                TempData["Title"] = CT.Title;

                //取得班別清單
                var query1 = from s in context.CHECKSHIFTS
                             select new
                             {
                                 s.ShiftID,
                                 s.ShiftValue
                             };
                VCTM.ShiftID = CL.ShiftID;
                VCTM.ShiftIDList = new SelectList(query1, "ShiftID", "ShiftValue");

                //取得分類清單
                var query2 = from c in context.CHECKCLASSES
                             select new
                             {
                                 c.ClassID,
                                 c.ClassValue
                             };
                VCTM.ClassID = CL.ClassID;
                VCTM.ClassIDList = new SelectList(query2, "ClassID", "ClassValue");

                //取得負責人清單
                var query = from u in context.EPSUSERS
                            select new
                            {
                                u.UId,
                                u.UserName
                            };
                VCTM.ChargerID = CL.ChargerID;
                VCTM.ChargerList = new SelectList(query, "UId", "UserName");
                VCTM.CheckType = CL.CheckType;
                VCTM.AlwaysShow = CL.AlwaysShow;
                VCTM.StartTime = CL.StartTime;
                VCTM.EndTime = CL.EndTime;
                VCTM.ShowOrder = CL.ShowOrder;

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得檢核項目資料作業成功，ListID:[" + ListID.ToString() + "]"; 
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VCTM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "取得檢核項目資料作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("ListItem", "Document");
            }
        }

        [HttpPost]
        public ActionResult EditItem(vCHECKLIST_Manage VCLM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Document";
            SL.Action = "EditItem";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                if (ModelState.IsValid)
                {
                    CHECKLIST nowCL = context.CHECKLISTS.Find(VCLM.ListID);
                    //nowCL.ListID = CL.ListID;
                    nowCL.CheckID = VCLM.CheckID;
                    nowCL.ListName = VCLM.ListName;
                    nowCL.Definition = VCLM.Definition;
                    nowCL.StartTime = VCLM.StartTime;
                    nowCL.EndTime = VCLM.EndTime;
                    nowCL.ShiftID = VCLM.ShiftID;
                    nowCL.ClassID = VCLM.ClassID;
                    nowCL.CheckType = VCLM.CheckType;
                    nowCL.AlwaysShow = VCLM.AlwaysShow;
                    nowCL.ChargerID = VCLM.ChargerID;
                    nowCL.ShowOrder = VCLM.ShowOrder;
                    nowCL.UpadteAccount= Session["UserID"].ToString().Trim(); ;
                    nowCL.UpdateTime = DateTime.Now;

                    context.Entry(nowCL).State = EntityState.Modified;
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "編輯檢核項目作業成功，ListID:[" + VCLM.ListID + "]";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //string Title = context.CHECKTITLES.Find(VCLM.CheckID).Title;

                    return RedirectToAction("ListItem", "Document",new { CheckID = VCLM.CheckID, Title = VCLM.CheckTitle });

                }
                else
                {
                    TempData["EditMsg"] = "<script>alert('編輯失敗');</script>";

                    return RedirectToAction("EditItem", "Document", new { ListID = VCLM.ListID });
                }
            }
            catch (Exception ex)
            {

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "編輯檢核項目作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["EditMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("EditItem", "Document", new { ListID = VCLM.ListID });
            }
        }

        private int getShowOrder(int CheckID)
        {
            int ShowOrder = 0;

            var query = context.CHECKLISTS.Where(b => b.CheckID == CheckID).OrderByDescending(b => b.ShowOrder);
            if (query.Count() > 0)
            {
                ShowOrder = query.First().ShowOrder;
            }
            return ShowOrder + 1;
        }
    }
}