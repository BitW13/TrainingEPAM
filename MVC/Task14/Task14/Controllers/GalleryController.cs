using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task14.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                return Redirect("~/Content/Gallery/" + id.ToString() + ".jpg");
            }
            return View();
        }
    }
}