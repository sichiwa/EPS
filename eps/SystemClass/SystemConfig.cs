using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using TWCAlib;

namespace EPS.SystemClass
{
    public class SystemConfig
    {
        private string _Version;
        private int _Schedule;
        private string _LDAPName;
        private string _VAVerifyURL;
        private int _NumofgridviewPage_perrows;
        private int _SelectTopN;

        private string _C_DBConnstring;
        private string _SystemHashAlg;
        private string _SystemDateTimeFormat;
        private string _SplitSymbol;
        private string _SplitSymbol2;
        private string _SplitSymbol3;

        private int _PublicRoleID;

        private string _MailServer;
        private int _MailServerPort;
        private string _MailSender;
        private List<string> _MailReceiver;
        private List<string> _MailCC;
        private bool _MailUseSSL;
        private bool _MailBodyUseHTML;
        private string _MailPriority;
        private int _MailCodePage;
        private string _MailSubject;

        private string _MailBody;
        private List<string> _TextReceivers;
        private string _TextSubject;
        private string _TextBody;

        /// <summary>
        /// 程式版次
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// 中央監控系統資料庫連線字串
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string C_DBConnstring
        {
            get { return _C_DBConnstring; }
            set { _C_DBConnstring = value; }
        }

        /// <summary>
        /// 系統使用之雜湊演算法
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SystemHashAlg
        {
            get { return _SystemHashAlg; }
            set { _SystemHashAlg = value; }
        }

        /// <summary>
        /// 系統使用時間格式
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SystemDateTimeFormat
        {
            get { return _SystemDateTimeFormat; }
            set { _SystemDateTimeFormat = value; }
        }

        /// <summary>
        /// 系統使用分隔符號
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol
        {
            get { return _SplitSymbol; }
            set { _SplitSymbol = value; }
        }

        /// <summary>
        /// 系統使用分隔符號(2)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol2
        {
            get { return _SplitSymbol2; }
            set { _SplitSymbol2 = value; }
        }

        /// <summary>
        /// 系統使用分隔符號(3)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string SplitSymbol3
        {
            get { return _SplitSymbol3; }
            set { _SplitSymbol3 = value; }
        }

        /// <summary>
        ///掃描頻率(單位秒)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }

        /// <summary>
        /// 網域登入網址
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LDAPName
        {
            get { return _LDAPName; }
            set { _LDAPName = value; }
        }

        /// <summary>
        /// VA驗章網址
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string VAVerifyURL
        {
            get { return _VAVerifyURL; }
            set { _VAVerifyURL = value; }
        }

        /// <summary>
        ///GridView分頁，每頁資料筆數
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int NumofgridviewPage_perrows
        {
            get { return _NumofgridviewPage_perrows; }
            set { _NumofgridviewPage_perrows = value; }
        }

        /// <summary>
        ///顯示最近N筆監控紀錄
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int SelectTopN
        {
            get { return _SelectTopN; }
            set { _SelectTopN = value; }
        }

        /// <summary>
        /// Public角色ID
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int PublicRoleID
        {
            get { return _PublicRoleID; }
            set { _PublicRoleID = value; }
        }

        /// <summary>
        /// 郵件伺服器IP
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailServer
        {
            get { return _MailServer; }
            set { _MailServer = value; }
        }

        /// <summary>
        /// 郵件伺服器Port
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int MailServerPort
        {
            get { return _MailServerPort; }
            set { _MailServerPort = value; }
        }

        /// <summary>
        /// 寄件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailSender
        {
            get { return _MailSender; }
            set { _MailSender = value; }
        }

        /// <summary>
        /// 收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> MailReceiver
        {
            get { return _MailReceiver; }
            set { _MailReceiver = value; }
        }

        /// <summary>
        /// 副本收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> MailCC
        {
            get { return _MailCC; }
            set { _MailCC = value; }
        }

        /// <summary>
        /// 郵件是否使用SSL
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MailUseSSL
        {
            get { return _MailUseSSL; }
            set { _MailUseSSL = value; }
        }

        /// <summary>
        /// 郵件內容是否使用HTML
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool MailBodyUseHTML
        {
            get { return _MailBodyUseHTML; }
            set { _MailBodyUseHTML = value; }
        }

        /// <summary>
        /// 郵件重要性
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailPriority
        {
            get { return _MailPriority; }
            set { _MailPriority = value; }
        }

        /// <summary>
        /// 郵件內容編碼
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int MailCodePage
        {
            get { return _MailCodePage; }
            set { _MailCodePage = value; }
        }

        /// <summary>
        /// 郵件主旨
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailSubject
        {
            get { return _MailSubject; }
            set { _MailSubject = value; }
        }

        /// <summary>
        /// 郵件內容
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string MailBody
        {
            get { return _MailBody; }
            set { _MailBody = value; }
        }

        /// <summary>
        /// 簡訊收件人
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<string> TextReceivers
        {
            get { return _TextReceivers; }
            set { _TextReceivers = value; }
        }

        /// <summary>
        /// 簡訊主旨
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TextSubject
        {
            get { return _TextSubject; }
            set { _TextSubject = value; }
        }

        /// <summary>
        /// 簡訊內容
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string TextBody
        {
            get { return _TextBody; }
            set { _TextBody = value; }
        }

        public void Init(string Version, int Schedule, int NumofgridviewPage_perrows, int SelectTopN, string C_DBConnstring,
        string SystemHashAlg, string SystemDateTimeFormat, string SplitSymbol, string SplitSymbol2, string SplitSymbol3,
        int PublicRoleID,
        string MailServer, int MailServerPort, string MailSender, List<string> MailReceiver, List<string> MailCC, bool MailUseSSL, bool MailBodyUseHTML, string MailPriority, int MailCodePage, string MailSubject, string MailBody,
        List<string> TextReceivers,
        string TextSubject, string TextBody)
        {
            Char[] splitsymbol = { ',' };

            this.Version = Version;
            this.Schedule = Schedule;

            this.NumofgridviewPage_perrows = NumofgridviewPage_perrows;
            this.SelectTopN = Convert.ToInt16(SelectTopN);

            this.C_DBConnstring = SecurityProcessor.TurnBase642String(C_DBConnstring);
            this.SystemHashAlg = SystemHashAlg;
            this.SystemDateTimeFormat = SystemDateTimeFormat;
            this.SplitSymbol = SplitSymbol;
            this.SplitSymbol2 = SplitSymbol2;
            this.SplitSymbol3 = SplitSymbol3;

            this.PublicRoleID = PublicRoleID;

            this.MailServer = MailServer;
            this.MailServerPort = Convert.ToInt16(MailServerPort);
            this.MailSender = MailSender;
            this.MailReceiver = MailReceiver;
            this.MailCC = MailCC;
            this.MailUseSSL = MailUseSSL;
            this.MailBodyUseHTML = MailBodyUseHTML;
            this.MailPriority = MailPriority;
            this.MailCodePage = MailCodePage;
            this.MailSubject = MailSubject;
            this.MailBody = MailBody;

            this.TextReceivers = TextReceivers;
            this.TextSubject = TextSubject;
            this.TextBody = TextBody;
        }

        public void Init()
        {
            Char[] splitsymbol = { ',' };

            this.Version = Version;
            this.Schedule = Schedule;

            this.LDAPName= WebConfigurationManager.AppSettings["LDAPName"];
            this.NumofgridviewPage_perrows = Convert.ToInt16(WebConfigurationManager.AppSettings["NumofgridviewPage_perrows"]);
            this.SelectTopN = Convert.ToInt16(WebConfigurationManager.AppSettings["SelectTopN"]);

            //this.C_DBConnstring = WebConfigurationManager.ConnectionStrings["C_DBConnstring"].ToString();//SecurityProcessor.TurnBase642String(WebConfigurationManager.ConnectionStrings["C_DBConnstring"].ToString());
            this.SystemHashAlg = WebConfigurationManager.AppSettings["SystemHashAlg"];
            this.SystemDateTimeFormat = WebConfigurationManager.AppSettings["SystemDateTimeFormat"];
            this.SplitSymbol = WebConfigurationManager.AppSettings["SplitSymbol"];
            this.SplitSymbol2 = WebConfigurationManager.AppSettings["SplitSymbol2"];
            this.SplitSymbol3 = WebConfigurationManager.AppSettings["SplitSymbol3"];

            this.PublicRoleID = Convert.ToInt16(WebConfigurationManager.AppSettings["PublicRoleID"]);

            this.MailServer = WebConfigurationManager.AppSettings["MailServer"];
            this.MailServerPort = Convert.ToInt16(WebConfigurationManager.AppSettings["MailServerPort"]);
            this.MailSender = WebConfigurationManager.AppSettings["MailSender"];
            this.MailReceiver = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["MailReceiver"], splitsymbol);
            this.MailCC = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["MailCC"], splitsymbol);
            this.MailUseSSL = Convert.ToBoolean(WebConfigurationManager.AppSettings["MailUseSSL"]);
            this.MailBodyUseHTML = Convert.ToBoolean(WebConfigurationManager.AppSettings["MailBodyUseHTML"]);
            this.MailPriority = WebConfigurationManager.AppSettings["MailPriority"];
            this.MailCodePage = Convert.ToInt32(WebConfigurationManager.AppSettings["MailCodePage"]);
            this.MailSubject = WebConfigurationManager.AppSettings["MailSubject"];
            this.MailBody = WebConfigurationManager.AppSettings["MailBody"];

            this.TextReceivers = StringProcessor.SplitString2Array(WebConfigurationManager.AppSettings["TextReceivers"], splitsymbol);
            this.TextSubject = WebConfigurationManager.AppSettings["TextSubject"];
            this.TextBody = WebConfigurationManager.AppSettings["TextBody"];
        }
    }
}