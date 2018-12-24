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
    }
}