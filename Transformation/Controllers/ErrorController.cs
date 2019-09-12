using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transformation.Controllers
{
    public class ErrorController : BaseController
    {
        [HandleError]
        public ActionResult Index()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}