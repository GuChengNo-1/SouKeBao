﻿using SokingTreasure.OsSys.BLL;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SokingTreasure.OsSys.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            return View();
        }

        /// <summary>
        /// 新闻中心
        /// </summary>
        /// <returns></returns>
        public ActionResult Presscenter()
        {
            return View();
        }

        /// <summary>
        /// 收件箱
        /// </summary>
        /// <returns></returns>
        public ActionResult Inbox()
        {
            return View();
        }

        /// <summary>
        /// 日历
        /// </summary>
        /// <returns></returns>
        public ActionResult Calendar()
        {
            return View();
        }

        /// <summary>
        /// 文本编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Textedit()
        {
            return View();
        }
    }
}