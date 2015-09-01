using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;
using EPS.ViewModels.FUNC;
using EPS.DAL;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;

namespace EPS.Controllers
{
    public class FunController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Fun
        public ActionResult Index()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Fun";
            SL.Action = "Index";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                var query = context.FUNCS.ToList();
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = query.Count();
                SL.SuccessCount = query.Count();
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得功能清單作業成功";
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
                SL.Msg = "取得功能清單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Login", "Account");
            }
        }

        //
        // GET: /Fun/Create
        public ActionResult Create()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Fun";
            SL.Action = "Create";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vFUNC_Manage VFM = new vFUNC_Manage();
                VFM.PId = 0;
                VFM.IsEnable = true;

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立角色表單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VFM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立功能表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Fun");
            }
        }

        //
        // POST: /Fun/Create
        [HttpPost]
        public ActionResult Create(vFUNC_Manage VFM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Fun";
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
                    FUNC F = new FUNC();
                    F.FId = VFM.FId;
                    F.FuncName = VFM.FuncName;
                    F.Controller = VFM.Controller;
                    F.Action = VFM.Action;
                    F.Url = VFM.Url;
                    F.PId = VFM.PId;
                    F.ShowOrder = VFM.ShowOrder;
                    F.IsEnable = VFM.IsEnable;
                    F.CreateAccount = Session["UserID"].ToString().Trim();
                    F.CreateTime = DateTime.Now;
                    F.UpadteAccount = Session["UserID"].ToString().Trim();
                    F.UpdateTime = DateTime.Now;

                    context.FUNCS.Add(F);
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立功能作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["CreateMsg"] = "<script>alert('新增成功');</script>";

                    return RedirectToAction("Index", "Fun");
                }
                else
                {
                    TempData["CreateMsg"] = "<script>alert('新增失敗');</script>";

                    return RedirectToAction("Create", "Fun");
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立功能作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Create", "Fun");
            }
        }

        // GET: Fun/Edit
        public ActionResult Edit(int SN)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Fun";
            SL.Action = "Edit";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vFUNC_Manage VFM = new vFUNC_Manage();
                FUNC F = context.FUNCS.Find(SN);

                VFM.SN = F.SN;
                VFM.FId = F.FId;
                VFM.FuncName = F.FuncName;
                VFM.PId = F.PId;
                VFM.Controller = F.Controller;
                VFM.Action = F.Action;
                VFM.Url = F.Url;
                VFM.ShowOrder = F.ShowOrder;
                VFM.IsEnable = F.IsEnable;

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得功能資料作業成功，FId:[" + F.FId.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VFM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得功能資料作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Fun");
            }
        }

        //
        // POST: Fun/Edit
        [HttpPost]
        public ActionResult Edit(vFUNC_Manage VFM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Fun";
            SL.Action = "Edit";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                FUNC F = context.FUNCS.Find(VFM.SN);
                F.FuncName = VFM.FuncName;
                F.Controller = VFM.Controller;
                F.Action = VFM.Action;
                F.Url = VFM.Url;
                F.PId = VFM.PId;
                F.ShowOrder = VFM.ShowOrder;
                F.IsEnable = VFM.IsEnable;
                F.UpadteAccount = Session["UserID"].ToString().Trim();
                F.UpdateTime = DateTime.Now;

                context.Entry(F).State = EntityState.Modified;
                context.SaveChanges();

                SL.EndDateTime = DateTime.Now;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "編輯功能作業成功，FId:[" + VFM.FId.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Fun");
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "編輯功能作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["EditMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Edit", "Fun", new { SN = VFM.SN });
            }
        }
    }
}