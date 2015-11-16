using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using EPS.Models;
using EPS.ViewModels.EPSUSER;
using EPS.DAL;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;

namespace EPS.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginInfo model)
        {
            //初始化系統參數
            Configer.Init();

            AD AD = new AD();
            VA VA = new VA();
            LoginProcessor LP = new LoginProcessor();
            bool UseCertLogin = false;
            string LDAPName = Configer.LDAPName;
            //string VAVerifyURL = WebConfigurationManager.AppSettings["VAVerifyURL"];
            //string ConnStr = Configer.C_DBConnstring;
            Boolean ContinueLogin = true;

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = model.UserID;
            SL.Controller = "Account";
            SL.Action = "Login";
            SL.StartDateTime = DateTime.Now;
            SL.TotalCount = 1;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;
            //string SendResult = string.Empty;

            if (ModelState.IsValid)
            {
                if (LDAPName == "")
                {
                    //缺少系統參數，需記錄錯誤
                    SL.EndDateTime = DateTime.Now;
                    SL.SuccessCount = 0;
                    SL.FailCount = 1;
                    SL.Msg = "登入作業失敗，錯誤訊息:[缺少系統參數LDAPName]";
                    SL.Result = false;
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    ContinueLogin = false;
                }
                if (ContinueLogin)
                {
                    AD.UserName = model.UserID;
                    AD.Pwd = model.Pwd;
                    AD.validType = AD.ValidType.Domain;
                    AD.LDAPName = LDAPName;

                    //VA.SignData = model.SignData;
                    //VA.Plaintext = model.Plaintext;
                    //VA.txnCode = "TxnCode";
                    //VA.VAVerifyURL = VAVerifyURL;
                    //VA.Tolerate = 120;

                    DateTime LoginStartTime = DateTime.Now;
                    SF.logandshowInfo("登入開始@" + LoginStartTime.ToString(Configer.SystemDateTimeFormat), log_Info);
                    bool LoginResult = LP.DoLogin(UseCertLogin, AD, VA);
                    DateTime LoginEndTime = DateTime.Now;
                    SF.logandshowInfo("登入結束@" + LoginEndTime.ToString(Configer.SystemDateTimeFormat), log_Info);
                    string LoginSpanTime = OtherProcesser.TimeDiff(LoginStartTime, LoginEndTime, "Milliseconds");
                    SF.logandshowInfo("本次登入共花費@" + LoginSpanTime + "毫秒", log_Info);

                    if (LoginResult == true)
                    {
                        //登入成功，需紀錄
                        SL.EndDateTime = DateTime.Now;
                        SL.SuccessCount = 1;
                        SL.FailCount = 0;
                        SL.Msg = "登入成功";
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                        Session["UseCertLogin"] = UseCertLogin;
                        //Session["UseCertLogin"] = true;
                        Session["UserID"] = model.UserID;
                        //Session["UserID"] = "TAS191";
                        int UserRole= SF.getUserRole(model.UserID);
                        Session["UserRole"] = UserRole;

                        //主管導向覆核頁面
                        if (UserRole > 2)
                        {
                            return RedirectToAction("Index", "Review");
                        }
                        else
                        {
                            //導向檢查頁面
                            return RedirectToAction("Index", "Process");
                        }
                    }
                    else
                    {
                        //string a=VA.ResultStr;

                        //登入失敗，需記錄錯誤
                        SL.EndDateTime = DateTime.Now;
                        SL.FailCount = 1;
                        if (UseCertLogin)
                        {
                            SL.Msg = "登入失敗，錯誤訊息:[AD或VA驗證失敗]";
                        }
                        else
                        {
                            SL.Msg = "登入失敗，錯誤訊息:[AD驗證失敗]";
                        }
                        SL.Result = false;
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                        TempData["LoginMsg"] = SL.Msg;

                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    TempData["LoginMsg"] = "登入失敗，錯誤訊息:[系統登入參數遺失]";
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Home()
        {
            int UserRole = Convert.ToInt32(Session["UserRole"].ToString());
            //主管導向覆核頁面
            if (UserRole > 2)
            {
                return RedirectToAction("Index", "Review");
            }
            else
            {
                //導向檢查頁面
                return RedirectToAction("Index", "Process");
            }
        }

        public ActionResult Index()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Account";
            SL.Action = "Index";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                var query = from u in context.EPSUSERS
                            join r in context.EPSROLES on u.RId equals r.RId into USERS
                            from x in USERS.DefaultIfEmpty()
                            select new vEPSUSER
                            {
                                UId=u.UId,
                                UserName = u.UserName,
                                UserEmail = u.UserEmail,
                                RoleName = x.RoleName,
                                CreateAccount = u.CreateAccount,
                                CreateTime = u.CreateTime,
                                UpadteAccount = u.UpadteAccount,
                                UpdateTime = u.UpdateTime
                            };

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = query.Count();
                SL.SuccessCount = query.Count();
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得使用者清單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(query.ToList());
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得使用者清單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
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
            SL.Controller = "Account";
            SL.Action = "Create";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vEPSUSER_Manage VUM = new vEPSUSER_Manage();

                var query = from r in context.EPSROLES
                            select new
                            {
                                r.RId,
                                r.RoleName
                            };
                VUM.RId = 1;
                VUM.Role = new SelectList(query, "RId", "RoleName");
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立使用者表單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VUM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立使用者表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Account");
            }
        }

        //
        // POST: /Account/Create
        [HttpPost]
        public ActionResult Create(vEPSUSER_Manage VUM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Account";
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
                    EPSUSER U = new EPSUSER();
                    U.UId = VUM.UId;
                    U.UserName = VUM.UserName;
                    U.UserPwd = VUM.UserPwd;
                    U.UserEmail = VUM.UserEmail;
                    U.RId = VUM.RId;
                    U.CreateAccount = Session["UserID"].ToString().Trim();
                    U.CreateTime = DateTime.Now;
                    U.UpadteAccount = Session["UserID"].ToString().Trim();
                    U.UpdateTime = DateTime.Now;

                    context.EPSUSERS.Add(U);
                    context.SaveChanges();

                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立使用者作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["CreateMsg"] = "<script>alert('新增成功');</script>";

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    TempData["CreateMsg"] = "<script>alert('新增失敗');</script>";

                    return RedirectToAction("Create", "Account");
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立使用者作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Create", "Account");
            }
        }

        public ActionResult Edit(string UId)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Account";
            SL.Action = "Create";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vEPSUSER_Manage VUM = new vEPSUSER_Manage();
                EPSUSER U = context.EPSUSERS.Find(UId);

                VUM.UId = UId;
                VUM.UserName = U.UserName;
                VUM.UserPwd = U.UserPwd;
                VUM.UserEmail = U.UserEmail;
                VUM.RId = U.RId;

                var query = from r in context.EPSROLES
                            select new
                            {
                                r.RId,
                                r.RoleName
                            };
                VUM.Role = new SelectList(query, "RId", "RoleName");
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得使用者資料作業成功，UId:[" + UId + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VUM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得使用者資料作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Create", "Account");
            }
        }

        //
        // POST: /Account/Edit
        [HttpPost]
        public ActionResult Edit(vEPSUSER_Manage VUM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Account";
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
                    EPSUSER U =context.EPSUSERS.Find(VUM.UId);
                    U.UserPwd = VUM.UserPwd;
                    U.UserEmail = VUM.UserEmail;
                    U.RId = VUM.RId;
                    U.UpadteAccount = Session["UserID"].ToString().Trim();
                    U.UpdateTime = DateTime.Now;
                    context.Entry(U).State= EntityState.Modified;
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "編輯使用者資料作業成功，UId:[" + VUM.UId + "]";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["EditMsg"] = "<script>alert('編輯成功');</script>";

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    TempData["EditMsg"] = "<script>alert('編輯失敗');</script>";

                    return RedirectToAction("Edit", "Account", new { UId  = VUM.UId });
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "編輯使用者作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["EditMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Edit", "Account", new { UId = VUM.UId });
            }
        }
    }
}