﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiTest.Models.Pages.Blog;

namespace EPiTest.Models.ViewModels
{
    public class BlogItemPageModel : PageViewModel<BlogItemPage>
    {
        public BlogItemPageModel(BlogItemPage currentPage)
            : base(currentPage)
        { }

        public IEnumerable<TagItem> Tags { get; set; }

        public string PreviewText { get; set; }
        public DateTime StartPublish { get; set; }
        public XhtmlString MainBody { get; set; }

        public bool ShowPublishDate { get; set; }

        public bool ShowIntroduction { get; set; }
        public CategoryList Category { get; set; }

        public class TagItem
        {
            public string Title { get; set; }
            public string Url { get; set; }
        }
    }
}