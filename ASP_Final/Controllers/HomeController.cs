using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.UI.WebControls.Expressions;
using ASP_Final.Models;

namespace ASP_Final.Controllers
{
    public class HomeController : Controller
    {
        private HenryEntities db = new HenryEntities();

        public ActionResult Index()
        {
            var allPublishers = db.PUBLISHER.ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var publisher in allPublishers)
            {
                PUBLISHER model = new PUBLISHER();
                model.PUBLISHER_NAME = publisher.PUBLISHER_NAME;
                model.PUBLISHER_CODE = publisher.PUBLISHER_CODE;

                model.BOOK = db.BOOK.Where(e => e.PUBLISHER_CODE == publisher.PUBLISHER_CODE).ToList();
                result.Add(model);
            }

            return View(result);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact(Contact model)
        {
            ViewBag.Message = "Info Saved";
            return Json(model);
        }

        public ActionResult Author()
        {
            return View();
        }

        public ActionResult AuthorNum(int? aNum)
        {
            List<AUTHOR> result = new List<AUTHOR>();
            if (aNum == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AUTHOR author = db.AUTHOR.Find(aNum);

            if (author == null)
            {
                return HttpNotFound();
            }

            result.Add(author);
            //return to Partial View and pass it model
            return View("Author", result);
        }

        [HttpPost]
        public ActionResult Author(Browse fromBrowse)
        {
            var allAuthors = db.AUTHOR.ToList();
            List<AUTHOR> result = new List<AUTHOR>();

            foreach (var author in allAuthors)
            {
                AUTHOR model = new AUTHOR();
                model.AUTHOR_NUM = author.AUTHOR_NUM;
                model.AUTHOR_LAST = author.AUTHOR_LAST;
                model.AUTHOR_FIRST = author.AUTHOR_FIRST;
                model.WROTE = db.WROTE.Where(e=>e.AUTHOR_NUM == author.AUTHOR_NUM && e.AUTHOR_NUM.ToString() == fromBrowse.AuthorSelected).ToList();

                result.Add(model);
            }

            return View(result);

        }
        public ActionResult Publisher()
        {
            return View();
        }

        public ActionResult PublishCode(string code)
        {
            List<PUBLISHER> result = new List<PUBLISHER>();
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PUBLISHER publisher = db.PUBLISHER.Find(code);

            if (publisher == null)
            {
                return HttpNotFound();
            }

            result.Add(publisher);
            //return to Partial View and pass it model
            return View("Publisher", result);
        }

        
        [HttpPost]
        public ActionResult Publisher(Browse fromBrowse)
        {
            var allPublishers = db.PUBLISHER.ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var publisher in allPublishers)
            {
                PUBLISHER model = new PUBLISHER();
                model.PUBLISHER_NAME = publisher.PUBLISHER_NAME;
                model.PUBLISHER_CODE = publisher.PUBLISHER_CODE;


                IOrderedQueryable<BOOK> allBooks = from b in db.BOOK
                    where b.PUBLISHER_CODE == publisher.PUBLISHER_CODE
                    where (string.IsNullOrEmpty(fromBrowse.PublisherSelected) ||
                           b.PUBLISHER_CODE.Contains(fromBrowse.PublisherSelected))
                    orderby b.PUBLISHER_CODE
                    select b;

                model.BOOK = allBooks.ToList();
                result.Add(model);
            }

            return View(result);
        }


        public ActionResult Location()
        {
            return View();
        }
        public ActionResult LocationNum(int? bNum)
        {
            List<BRANCH> result = new List<BRANCH>();
            if (bNum == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BRANCH branch = db.BRANCH.Find(bNum);

            if (branch == null)
            {
                return HttpNotFound();
            }

            result.Add(branch);
            //return to Partial View and pass it model
            return View("Location", result);
        }

        [HttpPost]
        public ActionResult Location(Browse fromBrowse)
        {
            var allLocations = db.BRANCH.ToList();
            List<BRANCH> result = new List<BRANCH>();

            foreach (var branch in allLocations)
            {
                BRANCH model = new BRANCH();
                model.BRANCH_LOCATION = branch.BRANCH_LOCATION;
                model.BRANCH_NAME = branch.BRANCH_NAME;
                model.BRANCH_NUM = branch.BRANCH_NUM;
                model.INVENTORY = db.INVENTORY.Where(e => e.BRANCH_NUM == branch.BRANCH_NUM && e.BRANCH_NUM.ToString() == fromBrowse.LocationSelected).ToList();
                result.Add(model);
            }

            return View(result);

        }

        public ActionResult Books()
        {
            var allPublishers = db.PUBLISHER.ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var publisher in allPublishers)
            {
                PUBLISHER model = new PUBLISHER();
                model.PUBLISHER_NAME = publisher.PUBLISHER_NAME;
                model.PUBLISHER_CODE = publisher.PUBLISHER_CODE;

                model.BOOK = db.BOOK.Where(e => e.PUBLISHER_CODE == publisher.PUBLISHER_CODE).ToList();
                result.Add(model);
            }

            return View(result);
        }
    }
}