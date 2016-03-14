using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.ViewModels.LOG;
using EPS.Models;
using System.Linq.Expressions;
using EPS.DAL;
using PagedList;
using EPS.SystemClass;

namespace EPS.Controllers
{
    public class LogController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Log
        public ActionResult Search(int page=1 )
        {
            int currentPage = page < 1 ? 1 : page;
            DateTime STime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00");
            DateTime ETime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd") + " 23:59:00");

            vSystemLog vSL = getSystemLog("-1", STime, ETime, "-1", currentPage);
            vSL.qSL = new QuerySystmeLog();
            vSL.qSL.STime = DateTime.Now.AddMonths(-1);
            vSL.qSL.ETime = DateTime.Now;

            if (vSL != null)
            {
                return View(vSL);
            }
            else
            {
                //RedirectToAction("Index","Home");
                return null;
            }
        }

        [HttpPost]
        public ActionResult Search(vSystemLog _vSL)
        {
            int currentPage = _vSL. qSL.PageIndex < 1 ? 1 : _vSL. qSL.PageIndex;
            SF.logandshowInfo("currentPage" + currentPage.ToString(),log_Info);
            string nowUser = _vSL. qSL.nowUser;
            if ( string.IsNullOrEmpty(nowUser))
            {
                nowUser = "-1";
            }
            SF.logandshowInfo("nowUser" + nowUser, log_Info);
            string nowResult = _vSL. qSL.nowResult;
            SF.logandshowInfo("nowResult" + nowResult, log_Info);
            DateTime STime = _vSL.qSL.STime;
            SF.logandshowInfo("STime" + STime.ToString(), log_Info);
            DateTime ETime = _vSL.qSL.ETime;
            SF.logandshowInfo("ETime" + ETime.ToString(), log_Info);
            string TmpETime = ETime.ToString("yyyy/MM/dd") + " 23:59:59";
            ETime = Convert.ToDateTime(TmpETime);

            vSystemLog vSL = getSystemLog(nowUser, STime, ETime, nowResult, currentPage);

            if (vSL != null)
            {
                return View(vSL);
            }
            else
            {
                //RedirectToAction("Index", "Home");
                return null;
            }
        }

        private vSystemLog getSystemLog(string nowUser, DateTime STime, DateTime ETime, string nowResult,int CurrentPage)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Log";
            SL.Action = "getSystemLog";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            vSystemLog vSL = new vSystemLog();
            try
            {
                Expression<Func<SYSTEMLOG, bool>> SystemLogUserWhereCondition;
                if (nowUser != "-1")
                {
                    SystemLogUserWhereCondition = b => b.UId == nowUser;
                }
                else
                {
                    SystemLogUserWhereCondition = b => 1 == 1;
                }

                Expression<Func<SYSTEMLOG, bool>> SystemLogResultWhereCondition;
                if (nowResult != "-1")
                {
                    bool x = bool.Parse(nowResult);
                    SystemLogResultWhereCondition = b => b.Result == x;
                }
                else
                {
                    SystemLogResultWhereCondition = b => 1 == 1;
                }

                var query = context.SYSTEMLOG.Where(SystemLogUserWhereCondition)
                                           .Where(SystemLogResultWhereCondition)
                                           .Where(b => b.StartDateTime >= STime)
                                           .Where(b => b.EndDateTime <= ETime)
                                           .OrderBy(b=>b.StartDateTime);

                if (query.Count() > 0)
                {

                    var SystemLogList = query.ToPagedList(CurrentPage, Configer.NumofgridviewPage_perrows);

                    vSL.SYSTEMLOGList = SystemLogList;
                    vSL.nowUser = nowUser;
                    vSL.PageIndex = CurrentPage;
                    vSL.nowResult = nowResult;
                    vSL.UserList = SF.getUserList(nowUser);
                
                    // Adds the empty item at the top of the list
                    List<SelectListItem> ResultListItmes = new List<SelectListItem>();
                    ResultListItmes.Add(new SelectListItem
                    {
                        Text = "全部",
                        Value = "-1"
                    });
                    ResultListItmes.Add(new SelectListItem
                    {
                        Text = "成功",
                        Value = "true"
                    });
                    ResultListItmes.Add(new SelectListItem
                    {
                        Text = "失敗",
                        Value = "false"
                    });
                    vSL.ResultList = ResultListItmes;

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得系統紀錄作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return vSL;
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount =0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得系統紀錄作業成功，本次查詢無資料";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return null;
                }

            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "取得系統紀錄作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return null;
            }
        }
    }
}