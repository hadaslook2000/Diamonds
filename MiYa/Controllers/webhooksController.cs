using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiYa.Controllers
{
    public class webhooksController : Controller
    {
        // GET: webhooks
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult sendgrid()
        {
            return Json(12);
        }
    }
}