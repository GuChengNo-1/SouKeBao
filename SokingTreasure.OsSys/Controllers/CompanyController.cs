﻿using SokingTreasure.OsSys.BLL;
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
        public ActionResult GetCompanyAndBusiness(string id)
        {
            var data = CompanyInfoManage.GetCompanyAndBusinessById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        

    }
}