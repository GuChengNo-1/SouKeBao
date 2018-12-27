using SokingTreasure.OsSys.BLL;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SokingTreasure.OsSys.Controllers
{
    public class TrademarkController : Controller
    {
        // GET: Trademark
        [HttpGet]
        public ActionResult TrademarkShow()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        /// <summary>
        /// 商标数据接口
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult TrademarkListShow(int index, int limit)
        {
            //查询条件（企业名称）
            var companyName = Request.Params["companyName"] == "" ? null : Request.Params["companyName"];
            //查询条件（申请日期开始）
            var applyTimeBegin = Request.Params["applyTimeBegin"] == "" ? null : Request.Params["applyTimeBegin"];
            //查询条件（申请日期结束）
            var applyTimeOver = Request.Params["applyTimeOver"] == "" ? null : Request.Params["applyTimeOver"];
            //查询条件（商品名称）
            var commodityName = Request.Params["commodityName"] == "" ? null : Request.Params["commodityName"];
            int count;
            DataTable table = TrademarkManage.GetTrademarkByWhere(index, limit, companyName, applyTimeBegin, applyTimeOver, commodityName, out count);
            List<CompanyAndTrademark> trademarkList = new List<CompanyAndTrademark>();
            foreach (DataRow reader in table.Rows)
            {
                CompanyAndTrademark cat = new CompanyAndTrademark();
                cat.NumberId = reader["numberId"].ToString();
                cat.Id = (int)reader["Id"];
                cat.CompanyId = (int)reader["CompanyId"];
                cat.CompanyName = reader["CompanyName"].ToString();
                cat.CompanyUrl = reader["CompanyUrl"].ToString();
                cat.CompanyType = reader["CompanyType"].ToString();
                cat.ApplyTime = (DateTime)reader["ApplyTime"];
                cat.Category = reader["Category"].ToString();
                cat.CommodityName = reader["CommodityName"].ToString();
                cat.TrademarkName = reader["TrademarkName"].ToString();
                cat.LegalRepresentative = reader["LegalRepresentative"].ToString();
                cat.ProcessState = reader["ProcessState"].ToString();
                cat.Registration = reader["Registration"].ToString();
                cat.CompanyPhone = reader["LegalRepresentative"].ToString();
                cat.CompanyEmail = reader["CompanyEmail"].ToString();
                trademarkList.Add(cat);
            }
            return Json(new { code = 0, msg = "", tatol = count, data = trademarkList.ToList() }, JsonRequestBehavior.AllowGet);
        }
    }
}