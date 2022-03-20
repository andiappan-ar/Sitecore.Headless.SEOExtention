using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;

namespace Sitecore.Headless.SEO.Extention.Helper
{
    internal static class SitecoreHelper
    {
        internal static bool IsPresentationAvailable(Item item)
        {
            Field presentation = item.Fields[Sitecore.FieldIDs.LayoutField];
            return (presentation != null && (!string.IsNullOrEmpty(presentation.Value)));
        }

        internal static string GetDropLinkValue(Item item, string fieldName) {
            ReferenceField field = item.Fields[fieldName];
            return ((field == null) || (field.TargetItem == null)) ? null : field.TargetItem["Value"];
        }

        internal static Func<Item, bool> IsHideFromSitemap = (x) =>
        {
            bool isHideFromSitemap = false;
            if (x != null)
            {
                Sitecore.Data.Fields.CheckboxField checkboxField = x.Fields[CustomConstant.SitemapIsHideFromSitemapField];
                if (checkboxField != null && !checkboxField.Checked)
                    isHideFromSitemap = true;
            }
            return isHideFromSitemap;
        };
    }
}