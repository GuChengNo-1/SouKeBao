using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SokingTreasure.OsSys.Controllers
{
    public class CopyrightController : Controller
    {
        // GET: Copyright
        public ActionResult CopyrightWorksShow()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }
    }
}