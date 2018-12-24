using SokingTreasure.OsSys.BLL;
using System;
using System.Collections.Generic;
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

            var trademarkList = TrademarkManage.GetTrademarkByWhere(index,limit,companyName,applyTimeBegin, applyTimeOver, commodityName).ToList();
            
            var count = TrademarkManage.GetTrademarkByWhere(index, limit, companyName, applyTimeBegin,applyTimeOver, commodityName).Count();
            return Json(new { code = 0, msg = "", tatol = count, data = trademarkList }, JsonRequestBehavior.AllowGet);
        }
    }
}