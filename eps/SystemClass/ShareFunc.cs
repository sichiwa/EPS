using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TWCAlib;
using NLog;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Net;
using EPS.DAL;
using EPS.Models;
using System.Globalization;

namespace EPS.SystemClass
{
    public class ShareFunc
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        public static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string _ConnStr;

        private string _op_name;
        private string log_Info = "Info";
        private string log_Err = "Err";
        public enum MailPriority : int
        {
            Low = 0,
            Middle = 1,
            High = 2
        }

        ///// <summary>
        ///// 資料庫連線字串
        ///// </summary>
        ///// <value></value>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public string ConnStr
        //{
        //    get { return _ConnStr; }
        //    set { _ConnStr = value; }
        //}

        ///// <summary>
        ///// 處理模組名稱
        ///// </summary>
        ///// <value></value>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public string op_name
        //{
        //    get { return _op_name; }
        //    set { _op_name = value; }
        //}

        /// <summary>
        /// 將資訊記錄至Log檔中
        /// </summary>
        /// <param name="_Str">顯示資訊</param>
        /// <param name="_Mode">Err:記錄至Debug log;Info記錄至Info log:</param>
        /// <remarks>2014/03/04 黃富彥</remarks>
        public void logandshowInfo(string _Str, string _Mode)
        {
            if ((_Mode == "Err"))
            {
                logger.Error(_Str);
            }
            else
            {
                logger.Info(_Str);
            }
        }

        /// <summary>
        /// 將執行結果寫入資料庫
        /// </summary>
        /// <param name="_OPLogger">OPLoger類別</param>
        /// <remarks>2014/03/04 黃富彥</remarks>
        public void log2DB(SYSTEMLOG _SL, 
                           string _MailServer, 
                           int _MailServerPort, 
                           string _MailSender, 
                           List<string> _MailReceiver)
        {
            SYSTEMLOG SL = _SL;
            string MailServer = _MailServer;
            int MailServerPort = _MailServerPort;
            string MailSender = _MailSender;
            List<string> MailReceiver = _MailReceiver;
            string MailSubject = string.Empty;
            StringBuilder MailBody = new StringBuilder();
            string SendResult = string.Empty;

            try
            {
                using (EPSContext context =new EPSContext())
                {
                    context.SYSTEMLOG.Add(SL);
                    context.SaveChanges();

                    //寫入文字檔Log
                    logandshowInfo("[" + SL.UId + "]執行[寫入資料庫紀錄作業]成功", log_Info);
                }
            }
            catch (Exception ex)
            {
                //異常
                //寫入文字檔Log
                logandshowInfo("[" + SL.UId + "]執行[寫入資料庫紀錄作業]發生未預期的異常,請查詢Debug Log得到詳細資訊", log_Info);
                logandshowInfo("[" + SL.UId + "]執行[寫入資料庫紀錄作業]發生未預期的異常,詳細資訊如下", log_Err);
                logandshowInfo("執行人:[" + SL.UId + "]", log_Err);
                logandshowInfo("執行模組名稱:[" + SL.Controller + "]", log_Err);
                logandshowInfo("執行作業名稱:[" + SL.Action + "]", log_Err);
                logandshowInfo("處理結果:[" + SL.Result.ToString() + "]", log_Err);
                logandshowInfo("起始時間:[" + SL.StartDateTime.ToString() + "]", log_Err);
                logandshowInfo("結束時間:[" + SL.EndDateTime.ToString() + "]", log_Err);
                logandshowInfo("處理總筆數:[" + SL.TotalCount.ToString() + "]", log_Err);
                logandshowInfo("處理成功筆數:[" + SL.SuccessCount.ToString() + "]", log_Err);
                logandshowInfo("處理失敗筆數:[" + SL.FailCount.ToString() + "]", log_Err);
                logandshowInfo("作業訊息:[" + SL.Msg + "]", log_Err);
                logandshowInfo("錯誤訊息:[" + ex.ToString() + "]", log_Err);

                //通知系統管理人員
                MailSubject = "[異常]機房電子表單系統-執行[寫入資料庫紀錄作業]失敗";
                MailBody.Append("<table>");
                MailBody.Append("<tr><td>");
                MailBody.Append("執行人:[" + SL.UId + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("執行模組名稱:[" + SL.Controller + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("執行作業名稱:[" + SL.Action + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("處理結果:[" + SL.Result.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("起始時間:[" + SL.StartDateTime.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("結束時間:[" + SL.EndDateTime.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("處理總筆數:[" + SL.TotalCount.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("處理成功筆數:[" + SL.SuccessCount.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("處理失敗筆數:[" + SL.FailCount.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("作業訊息:[" + SL.Msg + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("<tr><td>");
                MailBody.Append("錯誤訊息:[" + ex.ToString() + "]");
                MailBody.Append("</td></tr>");
                MailBody.Append("</table>");

                EmailNotify2Sys(MailServer, MailServerPort, MailSender, MailReceiver, false, MailSubject, MailBody.ToString());
            }

        }

        /// <summary>
        /// 寄送郵件
        /// </summary>
        /// <param name="_MailServer">郵件主機位置</param>
        /// <param name="_MailServerPort">郵件主機服務Port</param>
        /// <param name="_MailSender">寄件者</param>
        /// <param name="_MailReceivers">收件者清單</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SendEmail(string _MailServer, int _MailServerPort, string _MailSender, List<string> _MailReceivers, string _Subject, string _Body)
        {
            string SendResult = null;
            MailProcessor MailP = new MailProcessor();
            string MailServer = _MailServer;
            int MailServerPort = _MailServerPort;
            string MailSender = _MailSender;
            List<string> MailReceivers = _MailReceivers;
            string MailSubject = _Subject;
            string SendBody = _Body;
            List<System.Net.Mail.Attachment> MailA = new List<System.Net.Mail.Attachment>();
            List<string> MailCC = new List<string>();

            MailP.setMailProcossor(MailSender, MailReceivers, MailCC, MailSubject, SendBody, MailA, MailServer, MailServerPort, false, true,
            MailPriority.High.ToString(), 65001);

            SendResult = MailP.Send();

            return SendResult;
        }

        /// <summary>
        /// Email通知系統管理人員
        /// </summary>
        /// <param name="_WitreDB">是否要將通知結果寫入資料庫</param>
        /// <param name="_MailSubject">郵件主旨</param>
        /// <param name="_MailBody">郵件內容</param>
        /// <remarks></remarks>
        public void EmailNotify2Sys(string _MailServer, int _MailServerPort, string _MailSender, List<string> _MailReceiver, bool _WitreDB, string _MailSubject, string _MailBody)
        {
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = "System";
            SL.Action = "通知系統管理人員作業";
            SL.StartDateTime = DateTime.Now;
            SL.TotalCount = 1;

            bool WitreDB = _WitreDB;

            string MailServer = _MailServer;
            int MailServerPort = _MailServerPort;
            string MailSender = _MailSender;
            List<string> MailReceiver = _MailReceiver;
            string MailSubject = _MailSubject;
            string MailBody = _MailBody;
            string SendResult = string.Empty;

            //寄送通知信給系統管理人員
            SendResult = SendEmail(MailServer, MailServerPort, MailSender, MailReceiver, MailSubject, MailBody.ToString());
            SL.EndDateTime = DateTime.Now;

            if (SendResult == "success")
            {
                //寫入文字檔Log
                logandshowInfo("[" + SL.UId + "]執行[" + SL.Action + "]成功", log_Info);

                SL.SuccessCount = 1;
                SL.Result = true;
            }
            else
            {
                //寫入文字檔Log
                logandshowInfo("[" + SL.UId + "]執行[通知系統管理人員作業]失敗,請查詢Debug Log得到詳細資訊", log_Info);
                logandshowInfo("[" + SL.UId + "]執行[通知系統管理人員作業]失敗,詳細資訊如下", log_Err);
                logandshowInfo("錯誤訊息:[" + SendResult + "]", log_Err);

                SL.FailCount = 1;
                SL.Msg = SendResult;
            }

            if (WitreDB == true)
            {
                //寫入DB Log
                //OPLoger.SetOPLog(this.op_name, op_action, op_stime, op_etime, op_a_count, op_s_count, op_f_count, op_msg, op_result);
                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

        /// <summary>
        /// 取得使用者角色ID
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int getUserRole(string UserID)
        {
            //初始化系統參數
            Configer.Init();

            int Role = -1;
            using (EPSContext context = new EPSContext())
            {
                Role = context.EPSUSERS.Find(UserID).RId;
                if (Role <= 0)
                {
                    Role = Configer.PublicRoleID;
                }
            }
            return Role;
        }

        public SelectList getUserList(string nowUser)
        {
            var query = context.EPSUSERS.ToList();

            //List<SelectListItem> items = query.Select(b => new SelectListItem() {
            //    Text=b.UserName,
            //    Value=b.UId,
            //}).ToList();

            SelectList UserList = new SelectList(query, "UId", "UserName", nowUser);

            return UserList;
        }

        /// <summary>
        /// 通知覆核人
        /// </summary>
        /// <param name="CloseStatus">結案狀態</param>
        /// <param name="UId">執行人</param>
        /// <param name="CheckSN">日常檢核件編號</param>
        /// <param name="CheckTitle">機房檢核主題名稱</param>
        /// <param name="CheckDate">檢核日期</param>
        public void emailNotify2Review(string CloseStatus,string UId,
                                         string CheckSN,string CheckTitle,
                                         string CheckDate,string Action)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = UId;
            SL.Controller = "Process";
            SL.Action = "emailNotify2Reviewer";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                var query = context.REVIEWPROFILES.Where(b => b.CloseStauts == CloseStatus).ToList();
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        MAILTEMPLATE MT = context.MAILTEMPLATES.Find(item.MailTempID);

                        if (MT != null)
                        {
                            MAILSERVER MS = context.MAILSERVERS.Find(MT.MailServerID);
                            if (MS != null)
                            {
                                string TmpRole = item.NextReviews;
                                string[] TmpRoles = TmpRole.Split(',');
                                int[] Roles = new int[TmpRoles.Count()];
                                if (TmpRoles.Count() > 0)
                                {
                                    int i = 0;
                                    foreach (var R in TmpRoles)
                                    {
                                        Roles[i] = int.Parse(R);
                                        i++;
                                    }
                                }
                                    var queryUsers = context.EPSUSERS.Where(b => Roles.Contains(b.RId)).ToList();
                                    if (queryUsers.Count() > 0)
                                    {
                                        StringBuilder UserNameb = new StringBuilder();
                                        string UserName = "";
                                        foreach (var U in queryUsers)
                                        {
                                            UserNameb.Append(U.UserName + Configer.SplitSymbol);
                                        }
                                        UserName = StringProcessor.CutlastChar(UserName.ToString());
                                        //組合通知信標頭
                                        DateTime parsed;
                                        string parsedTime = "取得檢核件時間錯誤";
                                        if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                                        {
                                            parsedTime = parsed.ToString("yyyy-MM-dd");
                                        }

                                        MT.Subject.Replace("#Time", parsedTime)
                                                  .Replace("#Action", Action);

                                        MT.Body.Replace("#UserName", UserName);

                                        char[] s = { ',' };
                                        List<string> Receivers = StringProcessor.SplitString2Array(UserName, s);

                                        //寄信
                                        string SendResult = SendEmail(MS.ServerIP, MS.ServerPort, MT.Sender, Receivers, MT.Subject, MT.Body);
                                        if (SendResult == "success")
                                        {
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = query.Count();
                                            SL.SuccessCount = query.Count();
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + CheckSN + "]覆核人流程作業成功";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                        else
                                        {
                                            //寄信失敗
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = 0;
                                            SL.SuccessCount = 0;
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，" + "錯誤訊息[" + SendResult + "]";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                    }
                                    else
                                    {
                                        //沒有角色
                                        SL.EndDateTime = DateTime.Now;
                                        SL.TotalCount = 0;
                                        SL.SuccessCount = 0;
                                        SL.FailCount = 0;
                                        SL.Result = true;
                                        SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，沒有設定角色";
                                        log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                    }
                                }
                                else
                                {
                                    //沒有設定MAILSERVER
                                    SL.EndDateTime = DateTime.Now;
                                    SL.TotalCount = 0;
                                    SL.SuccessCount = 0;
                                    SL.FailCount = 0;
                                    SL.Result = true;
                                    SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，沒有設定MAILSERVER";
                                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                }
                            }
                            else
                            {
                                //沒有設定MAILTEMPLATE
                                SL.EndDateTime = DateTime.Now;
                                SL.TotalCount = 0;
                                SL.SuccessCount = 0;
                                SL.FailCount = 0;
                                SL.Result = true;
                                SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，沒有設定MAILTEMPLATE";
                                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                            }
                        }
                    }
                else
                {
                    //沒有設定REVIEWPROFILE
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，沒有設定REVIEWPROFILE";
                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "通知[" + CheckSN + "]覆核人流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

        public void emailNotify2ReviewbyDate(string CloseStatus, string UId,
                                             string CheckDate,string Action)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = UId;
            SL.Controller = "Process";
            SL.Action = "emailNotify2ReviewerbyDate";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            DateTime parsed;
            string parsedTime = "取得檢核件時間錯誤";
            if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
            {
                parsedTime = parsed.ToString("yyyy-MM-dd");
            }

            try
            {
               
                var query = context.REVIEWPROFILES.Where(b => b.CloseStauts == CloseStatus).ToList();
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        MAILTEMPLATE MT = context.MAILTEMPLATES.Find(item.MailTempID);

                        if (MT != null)
                        {
                            MAILSERVER MS = context.MAILSERVERS.Find(MT.MailServerID);
                            if (MS != null)
                            {
                                string TmpRole = item.NextReviews;
                                string[] TmpRoles = TmpRole.Split(',');
                                int[] Roles = new int[TmpRoles.Count()];
                                if (TmpRoles.Count() > 0)
                                {
                                    int i = 0;
                                    foreach (var R in TmpRoles)
                                    {
                                        Roles[i] = int.Parse(R);
                                        i++;
                                    }

                                    var queryUsers = context.EPSUSERS.Where(b => Roles.Contains(b.RId)).ToList();
                                    if (queryUsers.Count() > 0)
                                    {
                                        StringBuilder UserNameb = new StringBuilder();
                                        StringBuilder UserEmailb = new StringBuilder();
                                        string UserName = "";
                                        string UserEmail = "";
                                        foreach (var U in queryUsers)
                                        {
                                            UserNameb.Append(U.UserName + Configer.SplitSymbol);
                                            UserEmailb.Append(U.UserEmail + Configer.SplitSymbol);
                                        }
                                        UserName = StringProcessor.CutlastChar(UserNameb.ToString());
                                        UserEmail = StringProcessor.CutlastChar(UserEmailb.ToString());
                                        //組合通知信標頭
                                        string MailSubject = MT.Subject.Replace("#Time", parsedTime)
                                                  .Replace("#Action", Action);
                                        //組合通知信內容
                                        string MailBody = "";
                                        string HtmlBody = "";
                                        HtmlBody = "<table border=1 with='80%'>";
                                        HtmlBody += "<tr><td>檢核編號</td>";
                                        HtmlBody += "<td>表單名稱</td>";
                                        HtmlBody += "<td>早班</td>";
                                        HtmlBody += "<td>晚班</td>";
                                        HtmlBody += "<td>假日班</td></tr>";

                                        var cps = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

                                        foreach (var cp in cps)
                                        {
                                            HtmlBody += "<tr>";
                                            HtmlBody += "<td>" + cp.CheckSN + "</td>";
                                            CHECKTITLE ct = context.CHECKTITLES.Find(cp.CheckID);
                                            HtmlBody += "<td>" + ct.Definition + "</td>";
                                            if (cp.ShiftOne == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftOne + "</td>";
                                            }
                                            if (cp.ShiftThree == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftThree + "</td>";
                                            }
                                            if (cp.ShiftFour == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftFour + "</td>";
                                            }

                                            MailBody += "</tr>";
                                        }
                                        HtmlBody += "</table>";
                                        MailBody = MT.Body.Replace("#UserName", UserName)
                                                          .Replace("#Body", HtmlBody)
                                                          .Replace("#Link", "<a href='" + Configer.SystemURL + "'>機房表單系統連結</a>");

                                        char[] s = { ',' };
                                        List<string> Receivers = StringProcessor.SplitString2Array(UserEmail, s);

                                        //寄信
                                        string SendResult = SendEmail(MS.ServerIP, MS.ServerPort, MT.Sender, Receivers, MailSubject, MailBody);
                                        if (SendResult == "success")
                                        {
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = query.Count();
                                            SL.SuccessCount = query.Count();
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人流程作業成功";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                        else
                                        {
                                            //寄信失敗
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = 0;
                                            SL.SuccessCount = 0;
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，" + "錯誤訊息[" + SendResult + "]";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                    }
                                    else
                                    {
                                        //沒有角色
                                        SL.EndDateTime = DateTime.Now;
                                        SL.TotalCount = 0;
                                        SL.SuccessCount = 0;
                                        SL.FailCount = 0;
                                        SL.Result = true;
                                        SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定角色";
                                        log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                    }
                                }
                                else
                                {
                                    //沒有設定MAILSERVER
                                    SL.EndDateTime = DateTime.Now;
                                    SL.TotalCount = 0;
                                    SL.SuccessCount = 0;
                                    SL.FailCount = 0;
                                    SL.Result = true;
                                    SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定MAILSERVER";
                                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                }
                            }
                            else
                            {
                                //沒有設定MAILTEMPLATE
                                SL.EndDateTime = DateTime.Now;
                                SL.TotalCount = 0;
                                SL.SuccessCount = 0;
                                SL.FailCount = 0;
                                SL.Result = true;
                                SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定MAILTEMPLATE";
                                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                            }
                        }
                    }
                }
                else
                {
                    //沒有設定REVIEWPROFILE
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定REVIEWPROFILE";
                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }

            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

        public void emailNotify2RejectbyDate(string CloseStatus, string UId,
                                            string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = UId;
            SL.Controller = "Review";
            SL.Action = "emailNotify2ReviewerbyDate";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            DateTime parsed;
            string parsedTime = "取得檢核件時間錯誤";
            if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
            {
                parsedTime = parsed.ToString("yyyy-MM-dd");
            }

            try
            {
                var query = context.REJECTPROFILES.Where(b => b.CloseStauts == CloseStatus).ToList();
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        MAILTEMPLATE MT = context.MAILTEMPLATES.Find(item.MailTempID);

                        if (MT != null)
                        {
                            MAILSERVER MS = context.MAILSERVERS.Find(MT.MailServerID);
                            if (MS != null)
                            {
                                string TmpRole = item.NextReviews;
                                string[] TmpRoles = TmpRole.Split(',');
                                int[] Roles=new int[TmpRoles.Count()];
                                if (TmpRoles.Count()>0)
                                {
                                    int i = 0;
                                    foreach (var R in TmpRoles)
                                    {
                                        Roles[i]= int.Parse(R);
                                        i++;
                                    }

                                    var queryUsers = context.EPSUSERS.Where(b => Roles.Contains(b.RId)).ToList();
                                    if (queryUsers.Count() > 0)
                                    {
                                        StringBuilder UserNameb = new StringBuilder();
                                        StringBuilder UserEmailb = new StringBuilder();
                                        string UserName = "";
                                        string UserEmail = "";
                                        foreach (var U in queryUsers)
                                        {
                                            UserNameb.Append(U.UserName + Configer.SplitSymbol);
                                            UserEmailb.Append(U.UserEmail + Configer.SplitSymbol);
                                        }
                                        UserName = StringProcessor.CutlastChar(UserNameb.ToString());
                                        UserEmail = StringProcessor.CutlastChar(UserEmailb.ToString());
                                        //組合通知信標頭
                                        string MailSubject = MT.Subject.Replace("#Time", parsedTime)
                                                  .Replace("#Action", CloseStatus);

                                        //組合通知信內容
                                        string MailBody = "";
                                        string HtmlBody = "";
                                        HtmlBody = "<table border=1 with='80%'>";
                                        HtmlBody += "<tr><td>檢核編號</td>";
                                        HtmlBody += "<td>表單名稱</td>";
                                        HtmlBody += "<td>駁回原因</td></tr>";

                                        var cps = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

                                        foreach (var cp in cps)
                                        {
                                            HtmlBody += "<tr>";
                                            HtmlBody += "<td>" + cp.CheckSN + "</td>";
                                            CHECKTITLE ct = context.CHECKTITLES.Find(cp.CheckID);
                                            HtmlBody += "<td>" + ct.Definition + "</td>";
                                            REJECTREASON rr = context.REJECTREASONS.Where(b => b.CheckSN == cp.CheckSN).OrderByDescending(b=>b.CreateTime).First();
                                            HtmlBody += "<td>" + rr.Reason + "</td>";
                                            MailBody += "</tr>";
                                        }
                                        HtmlBody += "</table>";
                                        MailBody = MT.Body.Replace("#UserName", UserName)
                                                    .Replace("#Body", HtmlBody)
                                                    .Replace("#Link", "<a href='" + Configer.SystemURL + "'>機房表單系統連結</a>");

                                        char[] s = { ',' };
                                        List<string> Receivers = StringProcessor.SplitString2Array(UserEmail, s);

                                        //寄信
                                        string SendResult = SendEmail(MS.ServerIP, MS.ServerPort, MT.Sender, Receivers, MailSubject, MailBody);
                                        if (SendResult == "success")
                                        {
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = query.Count();
                                            SL.SuccessCount = query.Count();
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人駁回流程作業成功";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                        else
                                        {
                                            //寄信失敗
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = 0;
                                            SL.SuccessCount = 0;
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人駁回流程作業失敗，" + "錯誤訊息[" + SendResult + "]";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                    }
                                    else
                                    {
                                        //沒有角色
                                        SL.EndDateTime = DateTime.Now;
                                        SL.TotalCount = 0;
                                        SL.SuccessCount = 0;
                                        SL.FailCount = 0;
                                        SL.Result = true;
                                        SL.Msg = "通知[" + parsedTime + "]覆核人駁回流程作業失敗，沒有設定角色";
                                        log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                    }
                                }
                                else
                                {
                                    //沒有角色
                                    SL.EndDateTime = DateTime.Now;
                                    SL.TotalCount = 0;
                                    SL.SuccessCount = 0;
                                    SL.FailCount = 0;
                                    SL.Result = true;
                                    SL.Msg = "通知[" + parsedTime + "]覆核人駁回流程作業失敗，沒有設定角色";
                                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                }
                            }
                            else
                            {
                                //沒有設定MAILSERVER
                                SL.EndDateTime = DateTime.Now;
                                SL.TotalCount = 0;
                                SL.SuccessCount = 0;
                                SL.FailCount = 0;
                                SL.Result = true;
                                SL.Msg = "通知[" + parsedTime + "]覆核人駁回流程作業失敗，沒有設定MAILSERVER";
                                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                            }
                        }
                        else
                        {
                            //沒有設定MAILTEMPLATE
                            SL.EndDateTime = DateTime.Now;
                            SL.TotalCount = 0;
                            SL.SuccessCount = 0;
                            SL.FailCount = 0;
                            SL.Result = true;
                            SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定MAILTEMPLATE";
                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                        }
                    }
                }
                else
                {
                    //沒有設定REVIEWPROFILE
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定REVIEWPROFILE";
                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }

            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

        public void emailNotify2ClosebyDate(string CloseStatus, string UId,
                                            string CheckDate, string Action)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = UId;
            SL.Controller = "Process";
            SL.Action = "emailNotify2ClosebyDate";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            DateTime parsed;
            string parsedTime = "取得檢核件時間錯誤";
            if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
            {
                parsedTime = parsed.ToString("yyyy-MM-dd");
            }

            try
            {

                var query = context.REVIEWPROFILES.Where(b => b.CloseStauts == CloseStatus).ToList();
                if (query.Count() > 0)
                {
                    foreach (var item in query)
                    {
                        MAILTEMPLATE MT = context.MAILTEMPLATES.Find(item.MailTempID);

                        if (MT != null)
                        {
                            MAILSERVER MS = context.MAILSERVERS.Find(MT.MailServerID);
                            if (MS != null)
                            {
                                string TmpRole = item.NextReviews;
                                string[] TmpRoles = TmpRole.Split(',');
                                int[] Roles = new int[TmpRoles.Count()];
                                if (TmpRoles.Count() > 0)
                                {
                                    int i = 0;
                                    foreach (var R in TmpRoles)
                                    {
                                        Roles[i] = int.Parse(R);
                                        i++;
                                    }

                                    var queryUsers = context.EPSUSERS.Where(b => Roles.Contains(b.RId)).ToList();
                                    if (queryUsers.Count() > 0)
                                    {
                                        StringBuilder UserNameb = new StringBuilder();
                                        StringBuilder UserEmailb = new StringBuilder();
                                        string UserName = "";
                                        string UserEmail = "";
                                        foreach (var U in queryUsers)
                                        {
                                            UserNameb.Append(U.UserName + Configer.SplitSymbol);
                                            UserEmailb.Append(U.UserEmail + Configer.SplitSymbol);
                                        }
                                        UserName = StringProcessor.CutlastChar(UserNameb.ToString());
                                        UserEmail = StringProcessor.CutlastChar(UserEmailb.ToString());
                                        //組合通知信標頭
                                        string MailSubject = MT.Subject.Replace("#Time", parsedTime)
                                                  .Replace("#Action", Action);
                                        //組合通知信內容
                                        string MailBody = "";
                                        string HtmlBody = "";
                                        HtmlBody = "<table border=1 with='80%'>";
                                        HtmlBody += "<tr><td>檢核編號</td>";
                                        HtmlBody += "<td>表單名稱</td>";
                                        HtmlBody += "<td>早班</td>";
                                        HtmlBody += "<td>晚班</td>";
                                        HtmlBody += "<td>假日班</td>";
                                        HtmlBody += "<td>機房領班</td>";
                                        HtmlBody += "<td>機房主管</td>";
                                        HtmlBody += "<td>系統部主管</td></tr>";

                                        var cps = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

                                        foreach (var cp in cps)
                                        {
                                            HtmlBody += "<tr>";
                                            HtmlBody += "<td>" + cp.CheckSN + "</td>";
                                            CHECKTITLE ct = context.CHECKTITLES.Find(cp.CheckID);
                                            HtmlBody += "<td>" + ct.Definition + "</td>";
                                            if (cp.ShiftOne == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftOne + "</td>";
                                            }
                                            if (cp.ShiftThree == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftThree + "</td>";
                                            }
                                            if (cp.ShiftFour == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftFour + "</td>";
                                            }
                                            if (cp.ShiftTop == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ShiftTop + "</td>";
                                            }
                                            if (cp.ManageOne == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ManageOne + "</td>";
                                            }
                                            if (cp.ManageTop == "")
                                            {
                                                HtmlBody += "<td>N/A</td>";
                                            }
                                            else {
                                                HtmlBody += "<td>" + cp.ManageTop + "</td>";
                                            }

                                            MailBody += "</tr>";
                                        }
                                        HtmlBody += "</table>";
                                        MailBody = MT.Body.Replace("#Body", HtmlBody)
                                                          .Replace("#Link", "<a href='" + Configer.SystemURL + "'>機房表單系統連結</a>");

                                        char[] s = { ',' };
                                        List<string> Receivers = StringProcessor.SplitString2Array(UserEmail, s);

                                        //寄信
                                        string SendResult = SendEmail(MS.ServerIP, MS.ServerPort, MT.Sender, Receivers, MailSubject, MailBody);
                                        if (SendResult == "success")
                                        {
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = query.Count();
                                            SL.SuccessCount = query.Count();
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人流程作業成功";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                        else
                                        {
                                            //寄信失敗
                                            SL.EndDateTime = DateTime.Now;
                                            SL.TotalCount = 0;
                                            SL.SuccessCount = 0;
                                            SL.FailCount = 0;
                                            SL.Result = true;
                                            SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，" + "錯誤訊息[" + SendResult + "]";
                                            log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                        }
                                    }
                                    else
                                    {
                                        //沒有角色
                                        SL.EndDateTime = DateTime.Now;
                                        SL.TotalCount = 0;
                                        SL.SuccessCount = 0;
                                        SL.FailCount = 0;
                                        SL.Result = true;
                                        SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定角色";
                                        log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                    }
                                }
                                else
                                {
                                    //沒有設定MAILSERVER
                                    SL.EndDateTime = DateTime.Now;
                                    SL.TotalCount = 0;
                                    SL.SuccessCount = 0;
                                    SL.FailCount = 0;
                                    SL.Result = true;
                                    SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定MAILSERVER";
                                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                                }
                            }
                            else
                            {
                                //沒有設定MAILTEMPLATE
                                SL.EndDateTime = DateTime.Now;
                                SL.TotalCount = 0;
                                SL.SuccessCount = 0;
                                SL.FailCount = 0;
                                SL.Result = true;
                                SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定MAILTEMPLATE";
                                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                            }
                        }
                    }
                }
                else
                {
                    //沒有設定REVIEWPROFILE
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，沒有設定REVIEWPROFILE";
                    log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }

            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "通知[" + parsedTime + "]覆核人流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

    }
}