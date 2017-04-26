using System;
using System.Web.Mvc;

namespace Elga.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public JsonResult Upload()
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
    }
}