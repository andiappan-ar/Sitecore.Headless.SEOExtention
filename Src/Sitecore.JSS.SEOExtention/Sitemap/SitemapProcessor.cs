using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Events;
using Sitecore.JSS.SEOExtension.Helper;
using Sitecore.JSS.SEOExtention.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Sitecore.JSS.SEOExtension.Sitemap
{
    public class SitemapProcessor
    {
        public void OnItemSaved(object sender, EventArgs args)
        {
            // Sitemap list
            List<Url> sitemapList = new List<Url>();
            Action<ChildList> _GetChildItem = null;
            Action<Item> _GetCurrentItem = null;

            // Get site root item 
            Item siteRoot = Sitecore.Context.ContentDatabase.GetItem("{3009CDDD-A5E2-5B02-869B-366FC84F9E64}");

            _GetChildItem = x =>
            {

                Parallel.ForEach(x, y =>
                {
                    // Get only sitemap items
                    if (TemplateManager.GetTemplate(y).InheritsFrom(CustomConstant.SitemapTemplateId) && SitecoreHelper.IsHideFromSitemap(y))
                    {
                        _GetCurrentItem(y);
                    }
                });

            };
            _GetCurrentItem = x =>
            {

                if (x != null)
                {
                    sitemapList.Add(new Url()
                    {
                        Changefreq = SitecoreHelper.GetDropLinkValue(x, CustomConstant.SitemapchangefreqField),
                        Priority = SitecoreHelper.GetDropLinkValue(x, CustomConstant.SitemapchangefreqField),
                        Lastmod = x.Statistics.Updated,
                        //Image = ,
                        Loc = x.Paths.FullPath,

                    });

                    if (x.Children.Any() && x.Children.Count() > 0)
                        _GetChildItem(x.Children);
                }


            };

            _GetCurrentItem(siteRoot);

            XmlSerializer xsSubmit = new XmlSerializer(typeof(SitemapURLSet));
            var subReq = new SitemapURLSet()
            {
                Url = sitemapList
            };

            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }

            File.WriteAllText("/sitemap.xml", xml);
        }
    }
}