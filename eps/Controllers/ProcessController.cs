using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;
using EPS.ViewModels.PROCESS;
using EPS.DAL;
using TWCAlib;
using EPS.SystemClass;
using System.Data.Entity;
using System.Globalization;

namespace EPS.Controllers
{
    public class ProcessController : Controller
    {
        EPSContext context = new EPSContext();
        SystemConfig Configer = new SystemConfig();
        ShareFunc SF = new ShareFunc();
        String log_Info = "Info";
        String log_Err = "Err";

        // GET: Process
        public ActionResult Index(string CheckDate, string Shift)
        {
            if (string.IsNullOrEmpty(Shift))
            {
                DateTime nowDate = DateTime.Now;
                string DayOfWeek = nowDate.DayOfWeek.ToString();
                Shift = "01";

                if (DayOfWeek == "Saturday" || DayOfWeek == "Sunday")
                {
                    Shift = "04";
                }
                else
                {
                    if (nowDate.Hour == 14 && nowDate.Minute >= 30)
                    {
                        Shift = "03";
                    }
                    else
                    {
                        if (nowDate.Hour > 14)
                        {
                            Shift = "03";
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(CheckDate))
            {
                CheckDate = "";
            }

            vCHECKs vCs = GetCheckProcess(CheckDate, Shift);

            if (vCs != null)
            {
                return View(vCs);
            }
            else
            {
                return null;
            }
        }

        // POST: Process
        [HttpPost]
        public ActionResult Index(string CheckDate, string ShiftID, string aa)
        {

            if (string.IsNullOrEmpty(ShiftID))
            {
                DateTime nowDate = DateTime.Now;
                string DayOfWeek = nowDate.DayOfWeek.ToString();
                ShiftID = "01";

                if (DayOfWeek == "Saturday" || DayOfWeek == "Sunday")
                {
                    ShiftID = "04";
                }
                else
                {
                    if (nowDate.Hour == 14 && nowDate.Minute >= 30)
                    {
                        ShiftID = "03";
                    }
                    else
                    {
                        if (nowDate.Hour>14)
                        {
                            ShiftID = "03";
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(CheckDate))
            {
                CheckDate = "";
            }
            else
            { CheckDate = CheckDate.Replace("-", ""); }

            vCHECKs vCs = GetCheckProcess(CheckDate, ShiftID);

            if (vCs != null)
            {
                DateTime parsed;
                string parsedTime = "取得檢核件時間錯誤";
                if (DateTime.TryParseExact(CheckDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsed))
                {
                    parsedTime = parsed.ToString("yyyy-MM-dd");
                }
                TempData["CheckDateNow"] = parsedTime;
                return View(vCs);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得檢核項目畫面資料
        /// </summary>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="Shift">班別</param>
        /// <returns></returns>
        public vCHECKs GetCheckProcess(string CheckDate, string Shift)
        {
            if (CheckDate == "")
            {
                CheckDate = DateTime.Now.ToString("yyyyMMdd");
            }
            var CT = context.CHECKTITLES.ToList();
            var CP = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

            int CTCount = CT.Count();
            int CPCount = CP.Count();

            if (CPCount == 0)
            {
                //從1號開始產生檢核編號
                List<string> CheckSNList = GenCheckSN(CheckDate, CTCount, 1);

                if (GenCheckProcess(CheckSNList, CheckDate))
                {
                    GenReviewData(CheckDate);

                    vCHECKs vCs = GenChecks(CheckDate, Shift);
                    if (vCs != null)
                    {
                        vCs.ShiftID = Shift;
                        //取得班別清單
                        var Shifts = new string[] { "01", "03","04" };
                        var query1 = from s in context.CHECKSHIFTS.Where(b => Shifts.Contains(b.ShiftID))
                                     select new
                                     {
                                         s.ShiftID,
                                         s.ShiftValue
                                     };

                        vCs.ShiftIDList = new SelectList(query1, "ShiftID", "ShiftValue");
                        //取得昨日交接事項
                        vCs.HandoverItem = GetHandOverItem(CheckDate, -1);
                        return vCs;
                    }
                    else
                    {
                        //建立Checks失敗
                        return null;
                    }
                }
                else
                {
                    //建立CheckProcess失敗
                    return null;
                }
            }
            else
            {
                //代表有產生過檢核編號
                if (CTCount == CPCount)
                {
                    vCHECKs vCs = GenChecks(CheckDate, Shift);
                    if (vCs != null)
                    {
                        vCs.ShiftID = Shift;
                        //取得班別清單
                        var Shifts = new string[] { "01", "03", "04" };
                        var query1 = from s in context.CHECKSHIFTS.Where(b => Shifts.Contains(b.ShiftID))
                                     select new
                                     {
                                         s.ShiftID,
                                         s.ShiftValue
                                     };

                        vCs.ShiftIDList = new SelectList(query1, "ShiftID", "ShiftValue");
                        //取得昨日交接事項
                        vCs.HandoverItem = GetHandOverItem(CheckDate, -1);
                        return vCs;
                    }
                    else
                    {
                        //建立Checks失敗
                        return null;
                    }
                }
                else
                {
                    //產生檢核編號(應該不會走到這邊)
                    return null;
                }
            }
        }

        /// <summary>
        /// 產生檢核編號
        /// </summary>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="Count">要產生幾個編號</param>
        /// <param name="initCount">從幾號開始產生</param>
        /// <returns></returns>
        private List<string> GenCheckSN(string CheckDate, int Count, int initCount)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
            SL.Action = "GenCheckSN";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                List<string> ResutlList = new List<string>();
                for (int i = initCount; i <= Count; i++)
                {
                    char c = '0';
                    ResutlList.Add(CheckDate + i.ToString().PadLeft(2, c));
                }
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = ResutlList.Count();
                SL.SuccessCount = ResutlList.Count();
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立[" + CheckDate + "]檢核編號作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return ResutlList;
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立[" + CheckDate + "]檢核編號作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                return null;
            }
        }

        /// <summary>
        /// 產生CHECKPROCESS資料
        /// </summary>
        /// <param name="CheckSNList">檢核編號清單</param>
        /// <param name="CheckDate">檢核日期</param>
        /// <returns></returns>
        private bool GenCheckProcess(List<string> CheckSNList, string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = "System";
            SL.Controller = "Process";
            SL.Action = "GenCheckProcess";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            bool Result = true;

            try
            {
                var CT = context.CHECKTITLES.ToList();

                if (CheckSNList != null)
                {
                    //產生CHECKPROCESS
                    int i = 0;
                    foreach (var item in CT)
                    {
                        CHECKPROCESS newCP = new CHECKPROCESS();
                        newCP.CheckSN = CheckSNList[i];
                        newCP.CheckID = item.CheckID;
                        newCP.CheckDate = CheckDate;
                        newCP.CloseStutus = "檢查中";
                        newCP.CreateAccount = "System";
                        newCP.CreateTime = DateTime.Now;
                        newCP.UpadteAccount = "System";
                        newCP.UpdateTime = DateTime.Now;
                        newCP.CheckDate = CheckDate;
                        context.CHECKPROCESSES.Add(newCP);
                        context.SaveChanges();

                        i++;
                    }
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = CheckSNList.Count();
                    SL.SuccessCount = CheckSNList.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立[" + CheckDate + "]檢核流程作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return Result;
                }
                else
                {
                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 0;
                    SL.SuccessCount = 0;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "建立[" + CheckDate + "]檢核流程作業失敗，" + "錯誤訊息[無檢核編號]";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                    Result = false;

                    return Result;
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立[" + CheckDate + "]檢核流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                Result = false;

                return Result;
            }
        }

        /// <summary>
        /// 取得vCHECKPROCESS模型
        /// </summary>
        /// <param name="CheckSN">檢核編號</param>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="CheckID">檢核項目代號</param>
        /// <param name="Shift">班別代號</param>
        /// <returns></returns>
        private vCHECKPROCESS GetProcess(string CheckSN, string CheckDate, int CheckID, string Shift)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
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
                CHECKTITLE CT = context.CHECKTITLES.Find(CheckID);
                vCP.Title = CT.Title;
                vCP.CheckID = CT.CheckID;

                var query = from cp in context.CHECKPROCESSES
                            where cp.CheckSN == CheckSN
                            where cp.CheckDate == CheckDate
                            join cl in context.CHECKLISTS on cp.CheckID equals cl.CheckID
                            join cd in context.CHECKPROCESSDETAILS.Where(b => b.CheckDate == CheckDate)
                            on cl.ListID equals cd.ListID into x
                            from y in x.DefaultIfEmpty()
                            select new vCHECKDETAIL
                            {
                                ListID = cl.ListID,
                                CheckID = cl.CheckID,
                                ListName = cl.ListName,
                                CheckType = cl.CheckType,
                                Shift = cl.ShiftID,
                                StartTime = cl.StartTime,
                                EndTime = cl.EndTime,
                                CheckResult = y.CheckResult,
                                CloseStatus = cp.CloseStutus
                            };

                if (query.Count() > 0)
                {
                    //根據班別挑出檢核項目
                    var Shifts = new string[] { "00", Shift };
                    query = query.Where(b => Shifts.Contains(b.Shift));

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

        /// <summary>
        /// 建立vCHECKs模型
        /// </summary>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="Shift">班別代號</param>
        /// <returns></returns>
        private vCHECKs GenChecks(string CheckDate, string Shift)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
            SL.Action = "GenChecks";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                //組合vCHECKs
                var CP = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

                vCHECKs vCs = new vCHECKs();
                vCHECKPROCESS[] vCPList = new vCHECKPROCESS[CP.Count()];
                int i = 0;
                foreach (var item in CP)
                {
                    vCHECKPROCESS vCP = new vCHECKPROCESS();
                    vCP = GetProcess(item.CheckSN, item.CheckDate, item.CheckID, Shift);
                    vCPList[i] = vCP;
                    i++;
                }

                vCs.vCHECKPROCESS = vCPList.ToList();
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 1;
                SL.SuccessCount = 1;
                SL.FailCount = 0;
                SL.Result = true;
                SL.Msg = "建立[" + CheckDate + "]值班人員主畫面資料作業成功";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return vCs;
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立[" + CheckDate + "]值班人員主畫面資料作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return null;
            }
        }

        /// <summary>
        /// 建立覆核表單
        /// </summary>
        /// <param name="CheckDate">檢核日期</param>
        private void GenReviewData(string CheckDate)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
            SL.Action = "GenReviewData";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                var query = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate).ToList();

                foreach (var q in query)
                {
                    var ListNames = context.CHECKLISTS.Where(b => b.CheckID == q.CheckID).Select(m => new { m.ListName, m.ShowOrder }).Distinct().OrderBy(c => c.ShowOrder);
                    foreach (var item in ListNames.ToList())
                    {
                        REVIEWDATA RD = new REVIEWDATA();
                        RD.CheckDate = CheckDate;
                        RD.CheckSN = q.CheckSN;
                        RD.ListName = item.ListName;
                        RD.ShiftOneChecked = "N/A";
                        RD.ShiftTrheeChecked = "N/A";
                        RD.ShiftFourChecked = "N/A";
                        RD.CreateAccount = "System";
                        RD.CreateTime = DateTime.Now;
                        RD.UpadteAccount = "System";
                        RD.UpdateTime = DateTime.Now;

                        context.REVIEWDATAS.Add(RD);
                        context.SaveChanges();
                    }

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = ListNames.Count();
                    SL.SuccessCount = ListNames.Count();
                    SL.FailCount = 0;
                    SL.Result = true;
                    SL.Msg = "建立[" + CheckDate + "]覆核表單作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "建立[" + CheckDate + "]覆核表單作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
            }
        }

        /// <summary>
        /// 取得交接事項
        /// </summary>
        /// <param name="d">要取得幾天前的</param>
        /// <returns></returns>
        private string GetHandOverItem(string CheckDate, double d)
        {
            string Result = string.Empty;

            DateTime aa = DateTime.ParseExact(CheckDate,
                                        "yyyyMMdd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None);

            //取得昨日交接事項
            string LastCheckSN = aa.AddDays(d).ToString("yyyyMMdd") + "01";
            var query = context.CHECKPROCESSDETAILS
                                                                                    .Where(b => b.CheckID == 1)
                                                                                    .Where(b => b.ListID == 2)
                                                                                    .Where(b => b.CheckSN == LastCheckSN);

            if (query != null)
            {
                if (query.Count() > 0)
                {
                    Result = query.First().CheckResult;
                }
            }

            return Result;
        }

        /// <summary>
        /// 項目檢核
        /// </summary>
        /// <param name="CheckSN">日常檢核件編號</param>
        /// <param name="CheckID">機房檢核項目ID</param>
        /// <param name="ListID">檢核項目ID</param>
        /// <param name="CheckResult">檢核結果</param>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="ShiftID">班別</param>
        /// <returns></returns>
        public string Check(string CheckSN, int CheckID,
                                  int ListID, string CheckResult,
                                  string CheckDate, string Shift)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
            SL.Action = "GetProcess";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                string Title = context.CHECKTITLES.Find(CheckID).Title;
                string CheckName = context.CHECKLISTS.Find(ListID).Definition;

                CHECKLIST CL = context.CHECKLISTS.Find(ListID);

                if (CL.ShiftID == "00")
                {
                    Shift = "00";
                }

                //檢查CHECKPROCESS有沒有資料
                var query = context.CHECKPROCESSDETAILS.Where(b => b.ListID == ListID)
                                                     .Where(b => b.CheckSN == CheckSN)
                                                     .Where(b => b.CheckID == CheckID)
                                                     .Where(b => b.CheckDate == CheckDate)
                                                     .Where(b => b.ShiftID == Shift);

                if (query.Count() > 0)
                {
                    //update CHECKPROCESSDETAILS
                    CHECKPROCESSDETAIL CPD = context.CHECKPROCESSDETAILS.Where(b => b.ListID == ListID)
                                                    .Where(b => b.CheckSN == CheckSN)
                                                    .Where(b => b.CheckID == CheckID)
                                                    .Where(b => b.CheckDate == CheckDate)
                                                    .Where(b => b.ShiftID == Shift).First();

                    CPD.CheckResult = CheckResult;
                    CPD.UpadteAccount = Session["UserID"].ToString().Trim();
                    CPD.UpdateTime = DateTime.Now;
                    context.Entry(CPD).State = EntityState.Modified;
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckSN + "]檢核[" + Title + "][" + CheckName + "]作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "檢核成功";
                }
                else
                {
                    //insert CHECKPROCESSDETAILS
                    CHECKPROCESSDETAIL newCPD = new CHECKPROCESSDETAIL();
                    newCPD.CheckSN = CheckSN;
                    newCPD.CheckID = CheckID;
                    newCPD.ListID = ListID;
                    newCPD.ShiftID = Shift;
                    newCPD.CheckDate = CheckDate;
                    newCPD.CheckResult = CheckResult;
                    newCPD.CreateAccount = Session["UserID"].ToString().Trim();
                    newCPD.CreateTime = DateTime.Now;
                    newCPD.UpadteAccount = Session["UserID"].ToString().Trim();
                    newCPD.UpdateTime = DateTime.Now;

                    context.CHECKPROCESSDETAILS.Add(newCPD);
                    context.SaveChanges();

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "[" + CheckSN + "]檢核[" + Title + "][" + CheckName + "]作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                    return "檢核成功";

                }
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "[" + CheckSN + "]檢核流程作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return "檢核失敗";
            }
        }

        /// <summary>
        /// 值班人員簽核
        /// </summary>
        /// <param name="CheckSNs">日常檢核件編號集合</param>
        /// <param name="CheckIDs">機房檢核項目ID集合</param>
        /// <param name="CheckDate">檢核日期</param>
        /// <param name="Shift">班別</param>
        /// <param name="SignedDatas">簽章值集合</param>
        /// <returns></returns>
        public string Confirm(string[] CheckSNs, int[] CheckIDs,
                              string CheckDate, string Shift,
                              string[] SignedDatas)
        {
            //初始化系統參數
            Configer.Init();

            //Log記錄用
            SYSTEMLOG SL = new SYSTEMLOG();
            SL.UId = Session["UserID"].ToString();
            SL.Controller = "Process";
            SL.Action = "Confirm";
            SL.StartDateTime = DateTime.Now;

            string MailServer = Configer.MailServer;
            int MailServerPort = Configer.MailServerPort;
            string MailSender = Configer.MailSender;
            List<string> MailReceiver = Configer.MailReceiver;

            try
            {
                int i = 0;
                foreach (var item in CheckSNs)
                {
                    //取得CHECKPROCESS物件
                    CHECKPROCESS CP = context.CHECKPROCESSES.Find(item);

                    if (CP != null)
                    {
                        //update CHECKPROCESSES
                        EPSUSER U = context.EPSUSERS.Find(Session["UserID"].ToString().Trim());

                        switch (Shift)
                        {
                            //早班
                            case "01":
                                CP.ShiftOne = U.UserName;
                                CP.ShiftOneSign = SignedDatas[i];
                                CP.CloseStutus = "早班檢核完畢";
                                break;
                            //晚班
                            case "03":
                                CP.ShiftThree = U.UserName;
                                CP.ShiftThreeSign = SignedDatas[i];
                                CP.CloseStutus = "晚班檢核完畢";
                                break;
                            //假日班
                            case "04":
                                CP.ShiftFour = U.UserName;
                                CP.ShiftFourSign = SignedDatas[i];
                                CP.CloseStutus = "假日班檢核完畢";
                                break;
                        }

                        CP.UpadteAccount = Session["UserID"].ToString().Trim();
                        CP.UpdateTime = DateTime.Now;
                        context.Entry(CP).State = EntityState.Modified;
                        context.SaveChanges();

                        string CheckTitle = "";
                        CHECKTITLE CT = context.CHECKTITLES.Find(CheckIDs[i]);
                        if (CT != null)
                        {
                            CheckTitle = CT.Title;
                        }

                        //更新覆核表單
                        var query = context.REVIEWDATAS.Where(b => b.CheckDate == CheckDate);
                        if (query.Count() > 0)
                        {
                            foreach (var q in query.ToList())
                            {
                                if (q.ListName == "事件描述及行動" || q.ListName == "交接事項")
                                {
                                    if (Shift == "01")
                                    {
                                        q.ShiftOneChecked = "";
                                    }
                                    else if (Shift == "03")
                                    {
                                        q.ShiftTrheeChecked = "";
                                    }
                                    else if (Shift == "04")
                                    {
                                        q.ShiftFourChecked = "";
                                    }
                                }
                                else
                                {
                                    var query01 = context.CHECKLISTS.Where(b => b.ShiftID == Shift)
                                                                .Where(b => b.ListName == q.ListName);

                                    if (query01.Count() > 0)
                                    {
                                        if (Shift == "01")
                                        {
                                            if (getCheckReuslt(CheckDate, Shift, q.ListName))
                                            {
                                                q.ShiftOneChecked = "正常";
                                            }
                                            else
                                            {
                                                q.ShiftOneChecked = "異常";
                                            }

                                        }
                                        else if (Shift == "03")
                                        {
                                            if (getCheckReuslt(CheckDate, Shift, q.ListName))
                                            {
                                                q.ShiftTrheeChecked = "正常";
                                            }
                                            else
                                            {
                                                q.ShiftTrheeChecked = "異常";
                                            }
                                        }
                                        else if (Shift == "04")
                                        {
                                            if (getCheckReuslt(CheckDate, Shift, q.ListName))
                                            {
                                                q.ShiftFourChecked = "正常";
                                            }
                                            else
                                            {
                                                q.ShiftFourChecked = "異常";
                                            }
                                        }
                                    }
                                }

                                q.UpadteAccount = Session["UserID"].ToString().Trim();
                                q.UpdateTime = DateTime.Now;
                                context.Entry(q).State = EntityState.Modified;
                                context.SaveChanges();
                            }
                        }
                        else
                        {
                            //沒有覆核表單
                        }
                    }

                    SL.EndDateTime = DateTime.Now;
                    SL.TotalCount = 1;
                    SL.SuccessCount = 1;
                    SL.FailCount = 0;
                    SL.Result = false;
                    SL.Msg = "確認[" + item + "]作業成功";
                    SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);
                }
                i++;

                if (Shift == "03" || Shift == "04")
                {
                    bool CanNotify = true;
                    string CloseStutus = "";
                    var queryCP = context.CHECKPROCESSES.Where(b => b.CheckDate == CheckDate);
                    foreach (var item1 in queryCP.ToList())
                    {
                        if (Shift == "03")
                        {
                            CloseStutus = "晚班檢核完畢";
                            if (item1.ShiftOne == "" || item1.ShiftThree == "")
                            {
                                CanNotify = false;
                                break;
                            }
                        }
                        else if (Shift == "04")
                        {
                            CloseStutus = "假日班檢核完畢";
                            if (item1.ShiftFour == "")
                            {
                                CanNotify = false;
                                break;
                            }
                        }
                    }

                    if (CanNotify)
                    {
                        //通知下一位負責人
                        SF.emailNotify2ReviewbyDate(CloseStutus, Session["UserID"].ToString(),
                                                    CheckDate, "覆核");
                    }
                }
                return "確認成功";
            }
            catch (Exception ex)
            {
                SL.EndDateTime = DateTime.Now;
                SL.TotalCount = 0;
                SL.SuccessCount = 0;
                SL.FailCount = 0;
                SL.Result = false;
                SL.Msg = "確認作業失敗，" + "錯誤訊息[" + ex.ToString() + "]";
                SF.log2DB(SL, MailServer, MailServerPort, MailSender, MailReceiver);

                return "確認失敗";
            }
        }

        private Boolean getCheckReuslt(string CheckDate, string ShitfID, string ListName)
        {
            Boolean Reuslt = true;

            var query = context.CHECKLISTS.Where(b => b.ListName == ListName);
            foreach (var item in query.ToList())
            {
                var aa = context.CHECKPROCESSDETAILS.Where(b => b.ShiftID == ShitfID).Where(b => b.CheckDate == CheckDate).Where(b => b.ListID == item.ListID).Where(b => b.CheckResult == "false");

                if (aa.Count() > 0)
                {
                    Reuslt = false;
                    break;
                }
            }

            return Reuslt;
        }

        //private string getCheckResult(int CheckID,string NowCheckResult ,string OldCheckResult,string UserName)
        //{
        //    string NewCheckResult = "";

        //    if (CheckID==1)
        //    {
        //        //第一次新增
        //        if (OldCheckResult == "")
        //        {
        //            NewCheckResult = NowCheckResult + "(" + UserName + ")";
        //        }
        //        else
        //        {
        //            if (NewCheckResult.Contains(OldCheckResult))
        //            {

        //            }
        //        }
        //    }
        //}
    }
}