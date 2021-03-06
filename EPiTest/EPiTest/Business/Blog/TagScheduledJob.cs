﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.PlugIn;

namespace EPiTest.Business.Blog
{
    [ScheduledPlugIn(DisplayName = "Calculate Blog Tags")]
    public class TagScheduledJob
    {
        public TagScheduledJob()
        {
        }

        /// <summary>
        /// Starts the job
        /// </summary>
        /// <returns>A status message that will be logged</returns>
        public static string Execute()
        {
            //Do not use the start page in the future
            var tags = TagFactory.Instance.CalculateTags(PageReference.StartPage);

            TagRepository.Instance.SaveTags(tags);

            return "OK";
        }
    }
}
