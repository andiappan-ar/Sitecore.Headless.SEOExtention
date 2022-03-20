using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Headless.SEO.Extention.Helper;
using Sitecore.Headless.SEO.Extention.Models;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using System.Xml;
using System.Xml.Serialization;

namespace Sitecore.Headless.SEO.Extention.Sitemap
{
    public class SitemapProcessor
    {
        public void Process(PipelineArgs args)
        {
            Configure(RouteTable.Routes);
        }

        protected void Configure(RouteCollection routes)
        {
            routes.MapHttpRoute("sitemapstring", "/api/sitecore/HeadlessSEO/getsitemap", new
            {
                controller = "HeadlessSEO",
                action = "getsitemap"
            });
        }
        public string GetSitemapString(string siteRootPath)
        {
            // Sitemap list
            List<Url> sitemapList = new List<Url>();
            Action<ChildList> _GetChildItem = null;
            Action<Item> _GetCurrentItem = null;

            // Get site root item 
            Item siteRoot = Sitecore.Context.Database.GetItem(siteRootPath);

            _GetChildItem = x =>
            {

                Parallel.ForEach(x, y =>
                {
                    // Get only sitemap items
                    if (
                    TemplateManager.GetTemplate(y).InheritsFrom(CustomConstant.SitemapTemplateId) &&
                    SitecoreHelper.IsHideFromSitemap(y))
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

            return xml;
        }
    }
}