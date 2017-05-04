using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elga.Models;

namespace Elga.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public static ConcurrentDictionary<string, List<HttpPostedFileBase>> SessionFiles = new ConcurrentDictionary<string, List<HttpPostedFileBase>>();
        public ActionResult Index()
        {
            //return new RedirectResult("~/Content/Static/main.html");
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

                if (SessionFiles.ContainsKey(Session.SessionID))
                {
                    SessionFiles[Session.SessionID].Add(file);
                }
                else
                {
                    SessionFiles[Session.SessionID] = new List<HttpPostedFileBase> { file };
                }
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

        public ActionResult Submit(OrderModel model)
        {
            model.Files = SessionFiles[Session.SessionID] ?? new List<HttpPostedFileBase>();
            return Json(new { msg = model.Files.Select(s=>s.FileName + "\r\n") }, JsonRequestBehavior.AllowGet);
        }
    }
}