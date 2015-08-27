using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using EPS.DAL;
using EPS.Models;

namespace EPS.Models
{
    public class MyDynamicNodeProvider:DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();

            using (EPSContext context =new EPSContext())
            {
                var LoginUserID = HttpContext.Current.Session["UserID"].ToString();
                int UserRole = Convert.ToInt32(HttpContext.Current.Session["UserRole"].ToString());
                var query = from rm in context.ROLEFUNCMAPPINGS
                            where rm.RId == UserRole
                            join f in context.FUNCS on rm.FId equals f.FId into memu
                            from x in memu.DefaultIfEmpty()
                            select new
                            {
                                PId = x.PId,
                                FId = x.FId,
                                FuncName=x.FuncName,
                                Controller=x.Controller,
                                Action=x.Action,
                                Url= x.Url,
                                ShowOrder=x.ShowOrder
                            };
                var SysMenus = query.OrderBy(c=>c.ShowOrder).ToList();

                foreach (var menu in SysMenus)
                {
                    DynamicNode Node = new DynamicNode()
                    {
                        Title = menu.FuncName,
                        ParentKey= menu.PId > 0 ? menu.PId.ToString():"",
                        Key=menu.FId.ToString(),
                        Controller=menu.Controller,
                        Action=menu.Action,
                        Url=menu.Url
                    };

                    returnValue.Add(Node);
                }
            }

            return returnValue;
        }
    }
}