using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiTest.Models.Blocks
{
    /// <summary>
    /// Used to insert a list of pages, for example a news list
    /// </summary>
    [SiteContentType(GUID = "C5B623C6-8930-4F97-98F2-0E0B6965DEDF", DisplayName = "Tag Cloud Block")]
    [SiteImageUrl]
    public class TagCloudBlock : SiteBlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [CultureSpecific]
        [DefaultValue("Tags")]
        public virtual string Heading { get; set; }

        [Display(Name = "Blog Tag Link Page", GroupName = SystemTabNames.Content)]
        public virtual PageReference BlogTagLinkPage { get; set; }
    }
}