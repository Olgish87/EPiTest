using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiTest.Models.Blocks;

namespace EPiTest.Models.ViewModels
{
    public class BlogListModel
    {
        public BlogListModel(BlogListBlock block)
        {
            Heading = block.Heading;
            ShowIntroduction = block.IncludeIntroduction;
            ShowPublishDate = block.IncludePublishDate;
        }
        public string Heading { get; set; }
        public IEnumerable<PageData> Blogs { get; set; }
        public bool ShowIntroduction { get; set; }
        public bool ShowPublishDate { get; set; }
    }
}