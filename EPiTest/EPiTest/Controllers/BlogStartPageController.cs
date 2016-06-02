using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiTest.Business;
using EPiTest.Models.Pages.Blog;
using EPiTest.Models.ViewModels;

namespace EPiTest.Controllers
{
    public class BlogStartPageController : PageControllerBase<BlogStartPage>
    {
        private ContentLocator contentLocator;
        private IContentLoader contentLoader;
        public BlogStartPageController(ContentLocator contentLocator, IContentLoader contentLoader)
        {
            this.contentLocator = contentLocator;
            this.contentLoader = contentLoader;
        }

        public ActionResult Index(BlogStartPage currentPage)
        {

            var model = new PageViewModel<BlogStartPage>(currentPage);



            return View(model);
        }


    }
}
