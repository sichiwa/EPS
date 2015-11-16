using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;
using EPS.ViewModels.REVIEW;
using EPS.DAL;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;
using System.Globalization;
using EPS.ViewModels.PROCESS;

namespace EPS.Controllers
{
    public class ReviewController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Review
        public ActionResult Index()
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "Index";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            int RoleID = Int32.Parse(Session["UserRole"].ToString());

            try
            {
                var query = from rp in context.REVIEWPROFILES.Where(b => b.NextReview == RoleID)
                            join cp in context.CHECKPROCESSES.Where(b => b.CloseStutus != "檢查中")
                                                             .Where(b=>b.CloseStutus != "早班檢核完畢")
                            on rp.CloseStauts equals cp.CloseStutus
                            join ct in context.CHECKTITLES on cp.CheckID equals ct.CheckID into x
                            from y in x.DefaultIfEmpty()
                            select new vReview
                            {
                                CheckSN = cp.CheckSN,
                                CheckDate=cp.CheckDate,
                                Title = y.Title,
                                CloseStutus = cp.CloseStutus,
                                ShiftOne = cp.ShiftOne,
                                ShiftThree = cp.ShiftThree,
                                ShiftFour = cp.ShiftFour,
                                ShiftTop = cp.ShiftTop,
                                ManageOne = cp.ManageOne,
                                ManageTop = cp.ManageTop
                            };

                if (query.Count() > 0)
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[待覆核資料]流程作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return View(query.OrderBy(b => b.CheckSN).ToList());
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[待覆核資料]流程作業成功，目前無待覆核資料";
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
                SL.Msg = "取得[待覆核資料]流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return null;
            }
        }

        public ActionResult Summary(string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "Summary";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vReviewSummary vRS = new vReviewSummary();
                vRS.CheckDate = CheckDate;
                string CheckSN = CheckDate + "01";
                vRS.EventItem = context.CHECKPROCESSDETAILS.Where(b => b.CheckSN == CheckSN).Where(b => b.ListID == 1).First().CheckResult;
                vRS.HandoverItem = context.CHECKPROCESSDETAILS.Where(b => b.CheckSN == CheckSN).Where(b => b.ListID == 2).First().CheckResult;
                var query01 = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).Where(b => b.CheckID == 1);
                if (query01.Count()>0)
                {
                    vRS.ShiftOne = query01.First().ShiftOne;
                    vRS.ShiftThree = query01.First().ShiftThree;
                    vRS.ShiftFour = query01.First().ShiftFour;
                    vRS.ShiftTop = query01.First().ShiftTop;
                    vRS.ManageOne = query01.First().ManageOne;
                    vRS.ManageTop = query01.First().ManageTop;
                }


                var query = context.REVIEWDATAS.Where(b => b.CheckDate == CheckDate);
                    //.Where(b=>b.ListName!= "事件描述及行動").Where(b=>b.ListName != "交接事項");
                if (query.Count() > 0)
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckDate + "]覆核資料作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    DateTime parsed;
                    string parsedTime = "取得檢核件時間錯誤";
                    if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                    {
                        parsedTime = parsed.ToString("yyyy-MM-dd");
                    }

                    TempData["TitleText"] = parsedTime + " 檢核資料";
                    vRS.RD = query.ToList();
                    return View(vRS);
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckDate + "]覆核資料作業失敗，" + "錯誤訊息[找不到待覆核資料]";
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
                SL.Msg = "取得[" + CheckDate + "]覆核資料作業成功，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return null;
            }
        }

        public ActionResult Detail(string CheckSN,string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "Detail";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vCHECKPROCESS vCP = GetProcess(CheckSN, CheckDate);
                if (vCP != null)
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckSN + "]明細作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return View(vCP);
                }
                else
                {
                    //沒有檢核項目錯誤
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckSN + "]明細作業失敗，查無明細資料";
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
                SL.Msg = "取得[" + CheckSN + "]明細作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                return null;
            }
        }

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="CheckSNs"></param>
        /// <param name="CheckDates"></param>
        /// <param name="SignedData"></param>
        /// <returns></returns>
        public string Confirm(List<string> CheckSNs, List<string> CheckDates, string SignedData)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "Confirm";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            int TotalCount = 0;
            int SuccessCount = 0;
            int FailCount = 0;
            bool ReviewOK = true;

            try
            {
                string CloseStutus = "";
                TotalCount = CheckSNs.Count();
                foreach (var item in CheckSNs)
                {
                    CHECKPROCESS CP = context.CHECKPROCESSES.Find(item);

                    if (CP != null)
                    {
                        //update CHECKPROCESSES
                        EPSUSER U = context.EPSUSERS.Find(Session["UserID"].ToString().Trim());
                        int Role = int.Parse(Session["UserRole"].ToString());

                        switch (Role)
                        {
                            //機房領班
                            case 3:
                                CP.ShiftTop = U.UserName;
                                CP.ShiftTopSign = SignedData;
                                CP.CloseStutus = "領班覆核完畢";
                                CloseStutus = "領班覆核完畢";
                                break;
                            //主管
                            case 4:
                                CP.ManageOne = U.UserName;
                                CP.ManageOneSign = SignedData;
                                CP.CloseStutus = "主管覆核完畢";
                                CloseStutus = "主管覆核完畢";
                                break;
                            //系統部主管
                            case 5:
                                CP.ManageTop = U.UserName;
                                CP.ManageTopSign = SignedData;
                                CP.CloseStutus = "已結案";
                                CloseStutus = "已結案";
                                break;
                        }

                        CP.UpadteAccount = Session["UserID"].ToString().Trim();
                        CP.UpdateTime = DateTime.Now;
                        context.Entry(CP).State = EntityState.Modified;
                        context.SaveChanges();
                        SuccessCount += 1;

                        SL.EndDateTime = DateTime.Now;
                        SL.TotalCount = 1;
                        SL.SuccessCount =1;
                        SL.FailCount = 0;
                        SL.Result = false;
                        SL.Msg = "覆核[" + item + "]作業成功";
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    }
                    else
                    {
                        FailCount += 1;
                        ReviewOK = false;
                        SL.EndDateTime = DateTime.Now;
                        SL.TotalCount = 1;
                        SL.SuccessCount = 0;
                        SL.FailCount = 1;
                        SL.Result = false;
                        SL.Msg = "覆核[" + item + "]作業失敗，查無檢核流程資料";
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    }
                }

                if (ReviewOK)
                {
                    //通知下一位負責人
                    SF.emailNotify2ReviewbyDate(CloseStutus, Session["UserID"].ToString(),
                                                CheckDates[0].ToString(), "覆核");
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = TotalCount;
                    SL.SuccessCount = SuccessCount;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckDates[0].ToString() + "]覆核作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "全部覆核成功";
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = TotalCount;
                    SL.SuccessCount = SuccessCount;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckDates[0].ToString() + "]覆核作業失敗";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "有"+ FailCount.ToString() +"筆資料覆核失敗";
                }
                
            }
            catch (Exception ex)
            {
                ReviewOK = false;
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = CheckSNs.Count();
                SL.SuccessCount = 0;
                SL.FailCount = CheckSNs.Count();
                SL.Result = false;
                SL.Msg = "覆核作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return "覆核發生異常";
            }
        }

        /// <summary>
        /// 駁回
        /// </summary>
        /// <param name="CheckSNs"></param>
        /// <param name="CheckDates"></param>
        /// <param name="Reason"></param>
        /// <returns></returns>
        public string Reject(List<string> CheckSNs, List<string> CheckDates,string Reason)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "Reject";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            int TotalCount = 0;
            int SuccessCount = 0;
            int FailCount = 0;
            bool RejectOK = true;

            try
            {

                TotalCount = CheckSNs.Distinct().Count();
                foreach (var item in CheckSNs.Distinct())
                {
                    CHECKPROCESS CP = context.CHECKPROCESSES.Find(item);
                    REJECTREASON RR = new REJECTREASON();

                    if (CP != null)
                    {
                        CP.CloseStutus = "檢查中";
                        CP.UpadteAccount = Session["UserID"].ToString().Trim();
                        CP.UpdateTime = DateTime.Now;
                        context.Entry(CP).State = EntityState.Modified;
  
                        RR.CheckSN = item;
                        RR.Reason = Reason;
                        RR.CreateAccount= Session["UserID"].ToString().Trim();
                        RR.CreateTime= DateTime.Now;
                        context.REJECTREASONS.Add(RR);
                        context.SaveChanges();

                        SuccessCount += 1;
                        SL.EndDateTime = DateTime.Now;
                        SL.TotalCount = 1;
                        SL.SuccessCount = 1;
                        SL.FailCount = 0;
                        SL.Result = false;
                        SL.Msg = "駁回[" + item + "]作業成功";
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    }
                    else {
                        FailCount += 1;
                        RejectOK = false;
                        SL.EndDateTime = DateTime.Now;
                        SL.TotalCount = 1;
                        SL.SuccessCount = 0;
                        SL.FailCount = 1;
                        SL.Result = false;
                        SL.Msg = "駁回[" + item + "]作業失敗，查無檢核流程資料";
                        SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    }
                }

                if (RejectOK)
                {
                    int Role = int.Parse(Session["UserRole"].ToString());
                    string CloseStutus = "";
                    ////通知下一位負責人
                    switch (Role)
                    {
                        //機房領班
                        case 3:
                            CloseStutus = "領班駁回";
                            break;
                        //主管
                        case 4:
                            CloseStutus = "主管駁回";
                            break;
                        //系統部主管
                        case 5:
                            CloseStutus = "系統部主管駁回";
                            break;
                    }

                    SF.emailNotify2RejectbyDate(CloseStutus, Session["UserID"].ToString(),
                                                CheckDates[0].ToString());
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = TotalCount;
                    SL.SuccessCount = SuccessCount;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckDates[0].ToString() + "]駁回作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "全部駁回成功";
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = TotalCount;
                    SL.SuccessCount = SuccessCount;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckDates[0].ToString() + "]駁回作業失敗";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "有" + FailCount.ToString() + "筆資料駁回失敗";
                }
            }
            catch (Exception ex)
            {
                RejectOK = false;
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = CheckSNs.Count();
                SL.SuccessCount = 0;
                SL.FailCount = CheckSNs.Count();
                SL.Result = false;
                SL.Msg = "駁回作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return "駁回發生異常";
            }
        }

        /// <summary>
        /// 取得vCHECKPROCESS模型
        /// </summary>
        /// <param name="CheckSN">檢核編號</param>
        /// <param name="CheckDate">檢核日期</param>
        /// <returns></returns>
        private vCHECKPROCESS GetProcess(string CheckSN, string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Review";
            SL.Action = "GetProcess";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                vCHECKPROCESS vCP = new vCHECKPROCESS();
                vCP.CheckSN = CheckSN;
                vCP.CheckDate = CheckDate;
                int CheckID = context.CHECKPROCESSES.Find(CheckSN).CheckID;
                CHECKTITLE CT = context.CHECKTITLES.Find(CheckID);
                vCP.Title = CT.Title;

                var query = from cp in context.CHECKPROCESSES
                            where cp.CheckSN == CheckSN
                            where cp.CheckDate == CheckDate
                            join cd in context.CHECKPROCESSDETAILS.Where(b => b.CheckDate == CheckDate) on cp.CheckID equals cd.CheckID
                            join cl in context.CHECKLISTS on cd.ListID equals cl.ListID into x
                            from y in x.DefaultIfEmpty()
                            select new vCHECKDETAIL
                            {
                                ListID = y.ListID,
                                CheckID = y.CheckID,
                                ListName = y.ListName,
                                CheckType = y.CheckType,
                                Shift = y.ShiftID,
                                StartTime = y.StartTime,
                                EndTime = y.EndTime,
                                CheckResult = cd.CheckResult,
                                CloseStatus = cp.CloseStutus
                            };

                if (query.Count() > 0)
                {
                    //根據班別挑出檢核項目
                    //var Shifts = new string[] { "00", Shift };
                    //query = query.Where(b => Shifts.Contains(b.Shift));

                    vCP.vCHECKDETAILs = query.OrderBy(b => b.StartTime).ToList();
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = query.Count();
                    SL.SuccessCount = query.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckSN + "]檢核流程作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    return vCP;
                }
                else
                {
                    //沒有檢核項目錯誤
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "取得[" + CheckSN + "]檢核流程作業失敗，沒有對應檢核項目";
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
                SL.Msg = "取得[" + CheckSN + "]檢核流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                return null;
            }
        }

        //private bool CanReview(string CheckSN, string UserID)
        //{
        //    bool Result = true;
        //    var query = context.CHECKPROCESSES.Where(b => b.CheckSN == CheckSN)
        //                                      .Where(b => b.UpadteAccount == UserID);

        //    if (query.Count()>0)
        //    {
        //        Result = false;
        //    }

        //    return Result;
        //}

    }
}