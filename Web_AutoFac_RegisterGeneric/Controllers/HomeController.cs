using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_AutoFac_RegisterGeneric.Models;

namespace Web_AutoFac_RegisterGeneric.Controllers
{
    public class HomeController : Controller
    {
        public UserApp app { get; set; }

        public ActionResult Index()
        {
            // app 可能为空
            app.DeleteList(new int[] { 2, 3, 12 } );
            return View();
        }


    }
}