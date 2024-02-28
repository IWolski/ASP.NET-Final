using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;

namespace ASP_Final.Controllers
{
    public class BrowseController : Controller
    {
        private HenryEntities db = new HenryEntities();

        public ActionResult Index()
        {
            Browse model = new Browse();
            model.AllAuthorOptions = db.AUTHOR.OrderBy(s => s.AUTHOR_LAST).ToList().Select(c => new SelectListItem()
            {
                Text = c.AUTHOR_LAST + ", " + c.AUTHOR_FIRST,
                Value = c.AUTHOR_NUM.ToString()
            });
            return PartialView("~/Views/Shared/_Author.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(Browse model)
        {
            model.AllAuthorOptions = db.AUTHOR.OrderBy(s => s.AUTHOR_LAST).ToList().Select(c => new SelectListItem()
            {
                Text = c.AUTHOR_LAST + ", " + c.AUTHOR_FIRST,
                Value = c.AUTHOR_NUM.ToString()
            });
            return PartialView("~/Views/Shared/_Author.cshtml", model);
        }

        public ActionResult Publisher()
        {
            Browse model = new Browse();
            model.AllPublisherOptions = db.PUBLISHER.OrderBy(s => s.PUBLISHER_NAME).ToList().Select(c => new SelectListItem()
            {
                Text = c.PUBLISHER_NAME,
                Value = c.PUBLISHER_CODE.ToString()
            });
            return PartialView("~/Views/Shared/_Publisher.cshtml", model);
        }

        [HttpPost]
        public ActionResult Publisher(Browse model)
        {
            model.AllPublisherOptions = db.PUBLISHER.OrderBy(s => s.PUBLISHER_NAME).ToList().Select(c => new SelectListItem()
            {
                Text = c.PUBLISHER_NAME,
                Value = c.PUBLISHER_CODE.ToString()
            });
            return PartialView("~/Views/Shared/_Publisher.cshtml", model);
        }

        public ActionResult Location()
        {
            Browse model = new Browse();
            model.AllLocationOptions = db.BRANCH.OrderBy(s => s.BRANCH_NAME).ToList().Select(c => new SelectListItem()
            {
                Text = c.BRANCH_NAME,
                Value = c.BRANCH_NUM.ToString()
            });
            return PartialView("~/Views/Shared/_Location.cshtml", model);
        }
        [HttpPost]
        public ActionResult Location(Browse model)
        {
            model.AllLocationOptions = db.BRANCH.OrderBy(s => s.BRANCH_NAME).ToList().Select(c => new SelectListItem()
            {
                Text = c.BRANCH_NAME,
                Value = c.BRANCH_NUM.ToString()
            });
            return PartialView("~/Views/Shared/_Location.cshtml", model);
        }
    }
}