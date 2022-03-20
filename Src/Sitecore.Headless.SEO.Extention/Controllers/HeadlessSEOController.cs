using Sitecore.Headless.SEO.Extention.Sitemap;
using Sitecore.Mvc.Controllers;
using System.Web.Http;

namespace Sitecore.Headless.SEO.Extention.Controllers
{
    public class HeadlessSEOController : SitecoreController
    {
      
        public string getsitemap(string siteRootPath)
        {
            string sitemapXML = (string.IsNullOrEmpty(siteRootPath))?string.Empty:(new SitemapProcessor()).GetSitemapString(siteRootPath);
            return sitemapXML;
        }
    }
}