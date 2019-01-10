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
    public class ShareholderController : Controller
    {
        /// <summary>
        /// 股东信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShareholderShow()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }

        /// <summary>
        /// 展示股东信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult ShareholderListShow(int index,int limit)
        {
            //查询条件 (股东姓名)
            var ShareholderName = Request.Params["ShareholderName"] == "" ? null : Request.Params["ShareholderName"];
            int count;
            DataTable table = ShareholderManage.GetShareholderByWhere(index, limit, ShareholderName, out count);
            List<Shareholder> shareholderList = new List<Shareholder>();
            foreach (DataRow reader in table.Rows)
            {
                Shareholder sha = new Shareholder()
                {
                    NumberId = reader["numberId"].ToString(),
                    Id = (int)reader["Id"],
                    ShareholderName = reader["ShareholderName"].ToString(),
                    CapitalKey = reader["CapitalKey"].ToString(),
                    Contributive = reader["Contributive"].ToString(),
                    ContributiveTime = (DateTime)reader["ContributiveTime"]
                };
                shareholderList.Add(sha);
            }
            return Json(new { code = 0, msg = "", tatol = count, data = shareholderList.ToList() }, JsonRequestBehavior.AllowGet);
        }

    }
}