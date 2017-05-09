using System;
using System.Web;
using System.Web.Mvc;
using Elga.Models;

namespace Elga.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new RedirectResult("~/Content/Static/main.html");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Upload(OrderModel model)
        {
            var httpRequest = HttpContext.Request;

            foreach (string inputTagName in httpRequest.Files)
            {

                var headers = httpRequest.Headers;

                var file = httpRequest.Files[inputTagName];
                System.Diagnostics.Debug.WriteLine(file.FileName);

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {

                    // UploadWholeFile(ContentBase, resultList);
                }
                else
                {

                    //UploadPartialFile(headers["X-File-Name"], ContentBase, resultList);
                }

            }
            return Json("Ok");
        }

        [HttpPost]
        public ActionResult Submit(OrderModel model)
        {
            return Json(new { msg = "adsasd" }, JsonRequestBehavior.AllowGet);
        }
    }
}