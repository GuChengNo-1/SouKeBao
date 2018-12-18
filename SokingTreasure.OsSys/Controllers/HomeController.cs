using SokingTreasure.OsSys.BLL;
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
        public ActionResult Login()
        {
            UserLogin user = new UserLogin
            {
                LoginName = "admin",
                LoginPwd = "123456"
            };
            UserManage.GetWhereByUser(user);
            if (UserManage.CheckUser(user))
            {
                Response.Write("验证成功");
            }
            else
            {
                Response.Write("验证失败");
            }
            return View();
        }
        
    }
}