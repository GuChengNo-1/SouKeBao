using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;
using System.Collections;
using SokingTreasure.OsSys.BLL;

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

        public ActionResult Derive()
        {


        }

        /// <summary>
        /// 企业数据展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CompanyShow(string id)
        {
            ViewData["companyId"] = id;
            if (id != null)
            {
                return View();
            }
            return RedirectToAction("HomePage","Home");
        }
        /// <summary>
        /// 企业详情数据展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCompanyAndBusiness(string id)
        {
            var data = CompanyInfoManage.GetCompanyAndBusinessById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
    }
}