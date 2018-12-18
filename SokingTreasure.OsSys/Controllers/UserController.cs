using SokingTreasure.OsSys.BLL;
using SokingTreasure.OsSys.Common;
using SokingTreasure.OsSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SokingTreasure.OsSys.Controllers
{
    /// <summary>
    /// 用户controller
    /// </summary>
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserLogin model, string LoginCode)
        {
            string userPwd = DataEncrypt.MD5Encrypt(model.LoginPwd.Trim());
            model.LoginPwd = userPwd;
            //判断验证码是否正确
            if (LoginCode.ToLower() == Session["code"].ToString().ToLower())
            {
                //判断用户是否存在
                if (UserManage.CheckUser(model))
                {
                    //给用户设置票证
                    FormsAuthentication.SetAuthCookie(model.LoginName.ToString(), false);
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    return Json(new { success = true });
                }
            }
            else
            {
                return Json(new { success = false });
            }
        }
        /// <summary>
        /// 新用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <param name="LoginCode"></param>
        /// <returns></returns>
        public ActionResult InsertUser(UserLogin model, string LoginCode,string ConfirmPwd)
        {
            string userPwd = DataEncrypt.MD5Encrypt(model.LoginPwd.Trim());
            string userPwd2 = DataEncrypt.MD5Encrypt(ConfirmPwd.Trim());
            //判断验证码是否正确
            if (LoginCode.ToLower() == Session["code"].ToString().ToLower())
            {
                //判断密码和确认密码是否一致
                if (userPwd == userPwd2)
                {
                    //添加用户
                    if (UserManage.CheckUser(model))
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                    else
                    {
                        return Json(new { success = 1 });
                    }
                }
                else
                {
                    return Json(new { success = 2 });
                }
            }
            else
            {
                return Json(new { success = 3 });
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetCodeImg(double? id)
        {
            string code = new ValidataCode().GetCode(4);
            Session["code"] = code;
            Session.Timeout = 10;
            byte[] img = new ValidataCode().CreateValidateGraphic(code);
            return File(img, @"img/jpeg");
        }
    }
}