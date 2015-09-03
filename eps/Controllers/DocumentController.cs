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

            return View();
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

                    return RedirectToAction("AddItem", "Document",new {CheckID= CT.CheckID, CheckTitle= CT.Title });
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

        public ActionResult AddItem(int CheckID,string Title)
        {
            TempData["CheckID"] = CheckID;
            TempData["Title"] = Title;
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(vCHECKLIST_Manage VCTM)
        {
            if (ModelState.IsValid)
            {


            }

            return RedirectToAction("Index", "Document");
        }

        [HttpGet]
        public int getShowOrder(int CheckID)
        {
            int ShowOrder = 1;

            var query=context.CHECKLISTS.Where(b => b.CheckID == CheckID).OrderByDescending(b => b.ShowOrder).First();
            ShowOrder = query.ShowOrder;

            return ShowOrder+1;
        }
    }
}