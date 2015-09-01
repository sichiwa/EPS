using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;
using EPS.ViewModels.EPSROLE;
using EPS.DAL;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;

namespace EPS.Controllers
{
    public class RoleController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Role
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
                var query = from r in context.EPSROLES
                            select new vEPSROLE
                            {
                                RId = r.RId,
                                RoleName = r.RoleName,
                                CreateAccount = r.CreateAccount,
                                CreateTime = r.CreateTime,
                                UpadteAccount = r.UpadteAccount,
                                UpdateTime = r.UpdateTime
                            };

                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = query.Count();
                SL.SuccessCount = query.Count();
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得角色清單作業成功";
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
                SL.Msg = "取得角色清單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
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
            SL.Controller = "Role";
            SL.Action = "Create";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vEPSROLE_Manage VRM = new vEPSROLE_Manage();
                var query = from f in context.FUNCS
                            select new
                            {
                                f.FId,
                                f.FuncName
                            };

                VRM.Funcs= new SelectList(query, "FId", "FuncName");
                //預設給予登出功能
                VRM.FuncList = new int[] { 100 };
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立角色表單作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VRM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立角色表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Role");
            }
        }

        //
        // POST: /Role/Create
        [HttpPost]
        public ActionResult Create(vEPSROLE_Manage VRM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Role";
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
                    EPSROLE R = new EPSROLE();
                    R.RoleName = VRM.RoleName;
                    R.CreateAccount = Session["UserID"].ToString().Trim();
                    R.CreateTime = DateTime.Now;
                    R.UpadteAccount = Session["UserID"].ToString().Trim();
                    R.UpdateTime = DateTime.Now;

                    context.EPSROLES.Add(R);
                    context.SaveChanges();

                    foreach (var item in VRM.FuncList)
                    {
                        ROLEFUNCMAPPING RM = new ROLEFUNCMAPPING();
                        RM.RId = R.RId;
                        RM.FId = item;
                        RM.CreateAccount = Session["UserID"].ToString().Trim();
                        RM.CreateTime = DateTime.Now;
                        RM.UpadteAccount = Session["UserID"].ToString().Trim();
                        RM.UpdateTime = DateTime.Now;

                        context.ROLEFUNCMAPPINGS.Add(RM);
                        context.SaveChanges();
                    }
                    SL.EndDateTime = DateTime.Now;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立使用者作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    //TempData["CreateMsg"] = "<script>alert('新增成功');</script>";

                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    TempData["CreateMsg"] = "<script>alert('新增失敗');</script>";

                    return RedirectToAction("Create", "Role");
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "建立角色作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["CreateMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Create", "Role");
            }
        }

        // GET: Role/Edit
        public ActionResult Edit(int RId)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Role";
            SL.Action = "Edit";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vEPSROLE_Manage VRM = new vEPSROLE_Manage();
                EPSROLE R = context.EPSROLES.Find(RId);

                VRM.RId = RId;
                VRM.RoleName = R.RoleName;
                //取得系統提供之所有權限
                var query = from f in context.FUNCS
                            select new
                            {
                                f.FId,
                                f.FuncName
                            };

                VRM.Funcs = new SelectList(query, "FId", "FuncName");
                //取得目前角色擁有的權限
                var query1 = from rm in context.ROLEFUNCMAPPINGS
                             where rm.RId == RId
                             select new
                             {
                                rm.FId
                             };
                List<int> TmpList= new List<int>();
                foreach (var item in query1)
                {
                    TmpList.Add(item.FId);
                }

                VRM.FuncList = TmpList.ToArray();
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "取得角色資料作業成功，RId:[" + RId.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return View(VRM);
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得角色資料作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Role");
            }
        }

        //
        // POST: /Role/Edit
        [HttpPost]
        public ActionResult Edit(vEPSROLE_Manage VRM)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Role";
            SL.Action = "Edit";
            SL.TotalCount = 1;
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                EPSROLE R = context.EPSROLES.Find(VRM.RId);
                R.RoleName = VRM.RoleName;
                R.UpadteAccount= Session["UserID"].ToString().Trim();
                R.UpdateTime = DateTime.Now;
                //取得目前角色擁有的權限
                var query1 = from rm in context.ROLEFUNCMAPPINGS
                             where rm.RId ==VRM.RId
                             select new
                             {
                                 rm.FId
                             };
                List<int> TmpList = new List<int>();
                foreach (var item in query1)
                {
                    TmpList.Add(item.FId);
                }

                //取得新增清單
                var addResultList = VRM.FuncList.Except(TmpList);
                //取得移除清單
                var delResultList = TmpList.Except(VRM.FuncList); 

                //新增權限作業
                if (addResultList !=null)
                {
                    foreach (var item in addResultList)
                    {
                        ROLEFUNCMAPPING RM = new ROLEFUNCMAPPING();
                        RM.RId = VRM.RId;
                        RM.FId = item;
                        RM.CreateAccount = Session["UserID"].ToString().Trim();
                        RM.CreateTime = DateTime.Now;
                        RM.UpadteAccount = Session["UserID"].ToString().Trim();
                        RM.UpdateTime = DateTime.Now;

                        context.ROLEFUNCMAPPINGS.Add(RM);
                        context.SaveChanges();
                    }
                }

                //移除權限作業
                if (delResultList !=null)
                {
                    foreach (var item in delResultList)
                    {
                        ROLEFUNCMAPPING RM = context.ROLEFUNCMAPPINGS.Where(b => b.RId == VRM.RId)
                                                                     .Where(b => b.FId == item)
                                                                     .First();
                        context.Entry(RM).State = EntityState.Deleted;
                        context.SaveChanges();
                    } 
                }

                context.Entry(R).State = EntityState.Modified;
                context.SaveChanges();

                SL.EndDateTime = DateTime.Now;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "編輯角色作業成功，RId:[" + VRM.RId.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return RedirectToAction("Index", "Role");
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 0;
                SL.FailCount = 1;
                SL.Result = false;
                SL.Msg = "編輯角色作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                TempData["EditMsg"] = "<script>alert('發生異常');</script>";

                return RedirectToAction("Edit", "Role",new { RId= VRM.RId });
            }
        }
    }
}