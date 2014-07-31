using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Orchard.Aboutme.Util;


namespace Orchard.Aboutme.Controllers
{
    public class AbouteMeAccessController : Controller
    {
        public ActionResult UserInfo(string username,
            string header = "y", string app = "y", string link = "y", string loc = "n", string edu = "n",
            string work = "n", string tags = "n")
        {
            ViewData["showHeader"] = header == "y";
            ViewData["showApps"] = app == "y";
            ViewData["showLinks"] = link == "y";
            ViewData["showLocation"] = loc == "y";
            ViewData["showEducation"] = edu == "y";
            ViewData["showWork"] = work == "y";
            ViewData["showTags"] = tags == "y";

            var userInfo = AboutmeHelper.GetAboutmeInfo(username);
            return View(userInfo);
        }
    }
}