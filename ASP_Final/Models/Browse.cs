using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Final.Models
{
    public class Browse
    {
        public string PublisherSelected { get; set; }

        public IEnumerable<SelectListItem> AllPublisherOptions { get; set; }
        public string AuthorSelected { get; set; }

        public IEnumerable<SelectListItem> AllAuthorOptions { get; set; }

        public string LocationSelected { get; set; }

        public IEnumerable<SelectListItem> AllLocationOptions { get; set; }

    }
}