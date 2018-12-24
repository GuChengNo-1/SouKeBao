using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SokingTreasure.OsSys.Controllers
{
    public class CompanyController : Controller
    {
        /// <summary>
        /// 企业信息
        /// </summary>
        /// <returns></returns>
        // GET: Company
        public ActionResult CompanyInfo()
        {
            return View();
        }

        //public ActionResult CompanyInfo(int limit,int offset)
        //{
        //    var data = new List<object>() {
        //        new {
        //            Id =1,
        //            CompanyName ="深圳仁民健康股份(北京)有限公司",
        //            LegalRepresentative ="杨元庆",
        //            CompanyPhone="1873331425",
        //            CompanyEmail="2543600431@qq.com",
        //            CompanyUrl="http://www.lenovo.com.cn",
        //            CompanyProfile="联想集团是1984年中国科学院计算技术研究所投资20万元人民币，由11名科技人员创办的中国的一家在信息产业内多元化发展的大型企业集团，是富有创新性的国际化的科技公司。"
        //        }
        //    };
        //    var total = data.Count;
        //    var rows = data.Skip(offset).Take(limit).ToList();
        //    return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        //}
    }
}