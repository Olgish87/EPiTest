using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiTest.Business.Blog;
using EPiTest.Models.Blocks;

namespace EPiTest.Models.ViewModels
{
    public class TagCloudModel
    {
        public TagCloudModel(TagCloudBlock block)
        {
            Heading = block.Heading;
        }

        public string Heading { get; set; }

        public IEnumerable<TagItem> Tags { get; set; }

    }
}