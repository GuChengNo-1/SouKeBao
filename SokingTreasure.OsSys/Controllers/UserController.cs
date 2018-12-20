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
        private static int UserId;
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.Cookies["LoginName"] != null)
            {
                ViewData["LoginName"] = Request.Cookies["LoginName"].Value.ToString();
            }
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
                    return Json(new { success = 1});
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
        /// 记住用户
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginByRberUser(UserLogin model, string LoginCode)
        {
            string userPwd = DataEncrypt.MD5Encrypt(model.LoginPwd.Trim());
            model.LoginPwd = userPwd;
            //判断验证码是否正确
            if (LoginCode.ToLower() == Session["code"].ToString().ToLower())
            {
                //判断用户是否存在
                if (UserManage.CheckUser(model))
                {
                    if (Request.Cookies.AllKeys.Contains("LoginName"))
                    {
                        var cookietest = Request.Cookies["LoginName"];
                        cookietest.Expires = DateTime.Now.AddDays(-3);
                        Response.Cookies.Add(cookietest);
                    }
                    HttpCookie cookie = new HttpCookie("LoginName", model.LoginName);
                    cookie.Expires = DateTime.Now.AddDays(3);
                    Request.Cookies.Add(cookie);
                    //给用户设置票证
                    FormsAuthentication.SetAuthCookie(model.LoginName.ToString(), false);
                    return RedirectToRoute("HomePage", "Home");
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
        public ActionResult InsertUser(UserLogin model, string LoginCode, string ConfirmPwd)
        {
            string userPwd = DataEncrypt.MD5Encrypt(model.LoginPwd.Trim());
            model.LoginPwd = userPwd;
            string userPwd2 = DataEncrypt.MD5Encrypt(ConfirmPwd.Trim());
            //判断验证码是否正确
            if (LoginCode.ToLower() == Session["code"].ToString().ToLower())
            {

                //判断密码和确认密码是否一致
                if (userPwd == userPwd2)
                {
                    //判断用户名是否已存在
                    if (UserManage.UserIfExist(model.LoginName))
                    {
                        return Json(new { success = 1 });
                    }
                    else
                    {
                        //添加用户
                        if (UserManage.InsertUser(model))
                        {
                            return RedirectToAction("Login", "User");
                        }
                        else
                        {
                            return Json(new { success = 2 });
                        }
                    }
                }
                else
                {
                    return Json(new { success = 3 });
                }
            }
            else
            {
                return Json(new { success = 4 });
            }
        }
        /// <summary>
        /// 验证用户注册信息
        /// </summary>
        /// <param name="verifyEmail"></param>
        /// <param name="verifyPhone"></param>
        /// <param name="verifyName"></param>
        /// <param name="loginCode"></param>
        /// <returns></returns>
        public ActionResult VerifyUser(string verifyEmail, string verifyPhone, string verifyName, string loginCode)
        {
            UserLogin model = new UserLogin()
            {
                LoginEmail = verifyEmail,
                LoginPhone = verifyPhone,
                LoginName = verifyName
            };
            //判断验证码是否正确
            if (loginCode.ToLower() == Session["code"].ToString().ToLower())
            {
                //判断用户信息是否正确(id不为0则查询到数量>=1)
                if (UserManage.VerifyUser(model).Id != 0)
                {
                    UserId = UserManage.VerifyUser(model).Id;
                    return Json(new { success = 1, userId = UserId });
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
        [HttpGet]
        public ActionResult UserResetPwd(string id)
        {
            return View();
        }
        /// <summary>
        /// 用户重置密码
        /// </summary>
        /// <param name="loginPwd">新密码</param>
        /// <param name="loginPwd2">确认密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UserResetPwd(string loginPwd, string confirmPwd)
        {
            string secrecyPwd = DataEncrypt.MD5Encrypt(loginPwd.Trim());
            string secrecyPwd2 = DataEncrypt.MD5Encrypt(confirmPwd.Trim());
            //新密码是否和确认密码一致
            if (secrecyPwd == secrecyPwd2)
            {
                //重置密码
                if (UserManage.AlterUserPwd(UserId, secrecyPwd))
                {
                    return Json(new { success = 1 });
                    //return RedirectToAction("HomePage", "Home");
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