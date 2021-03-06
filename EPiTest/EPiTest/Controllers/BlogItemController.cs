﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Core.Html;
using EPiServer.DataAbstraction;
using EPiServer.DynamicContent;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiTest.Business.Blog;
using EPiTest.Models.Pages.Blog;
using EPiTest.Models.ViewModels;

namespace EPiTest.Controllers
{
    public class BlogItemController : Controller
    {
        public int PreviewTextLength { get; set; }

        public ActionResult Preview(PageData currentPage, BlogListModel blogModel)
        {
            var pd = (BlogItemPage)currentPage;
            PreviewTextLength = 200;

            var model = new BlogItemPageModel(pd)
            {
                Tags = GetTags(pd),
                PreviewText = GetPreviewText(pd),
                ShowIntroduction = blogModel.ShowIntroduction,
                ShowPublishDate = blogModel.ShowPublishDate
            };

            return PartialView("Preview", model);
        }

        public ActionResult Full(BlogItemPage currentPage)
        {
            PreviewTextLength = 200;

            var model = new BlogItemPageModel(currentPage)
            {
                Category = currentPage.Category,
                Tags = GetTags(currentPage),
                PreviewText = GetPreviewText(currentPage),
                MainBody = currentPage.MainBody,
                StartPublish = currentPage.StartPublish
            };

            var editHints = ViewData.GetEditHints<BlogItemPageModel, BlogItemPage>();
            editHints.AddConnection(m => m.Category, p => p.Category);
            editHints.AddFullRefreshFor(p => p.Category);
            editHints.AddFullRefreshFor(p => p.StartPublish);



            return PartialView("Full", model);
        }

        public ActionResult Index(BlogItemPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);


            //Connect the view models logotype property to the start page's to make it editable
            var editHints = ViewData.GetEditHints<PageViewModel<BlogItemPage>, BlogItemPage>();
            editHints.AddConnection(m => m.CurrentPage.Category, p => p.Category);
            editHints.AddConnection(m => m.CurrentPage.StartPublish, p => p.StartPublish);


            return View(model);
        }

        public IEnumerable<BlogItemPageModel.TagItem> GetTags(BlogItemPage currentPage)
        {
            List<BlogItemPageModel.TagItem> tags = new List<BlogItemPageModel.TagItem>();
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();

            foreach (var item in currentPage.Category)
            {
                Category cat = categoryRepository.Get(item);

                tags.Add(new BlogItemPageModel.TagItem() { Title = cat.Name, Url = TagFactory.Instance.GetTagUrl(currentPage, cat) });
            }

            return tags;
        }



        protected string GetPreviewText(BlogItemPage page)
        {
            if (PreviewTextLength <= 0)
            {
                return string.Empty;
            }

            string previewText = String.Empty;

            if (page.MainBody != null)
            {
                previewText = page.MainBody.ToHtmlString();
            }

            if (String.IsNullOrEmpty(previewText))
            {
                return string.Empty;
            }

            //If the MainBody contains DynamicContents, replace those with an empty string
            StringBuilder regexPattern = new StringBuilder(@"<span[\s\W\w]*?classid=""");
            regexPattern.Append(DynamicContentFactory.Instance.DynamicContentId.ToString());
            regexPattern.Append(@"""[\s\W\w]*?</span>");
            previewText = Regex.Replace(previewText, regexPattern.ToString(), string.Empty, RegexOptions.IgnoreCase | RegexOptions.Multiline);

            return TextIndexer.StripHtml(previewText, PreviewTextLength);
        }


    }
}
