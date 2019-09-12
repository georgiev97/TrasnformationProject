using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Transformation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {         
            return View();
        }

    }
}