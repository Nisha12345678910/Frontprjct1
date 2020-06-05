using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using TrainingWebApplication.Models.CommonModel;
using Utilities;

namespace TrainingWebApplication.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult ContentList()
        {
            Item []content = Sitecore.Context.Database.SelectItems("/sitecore/content/home//*");
             
            List<PageItem> Items = new List<PageItem>();
            
            foreach (Item contentItem in content)
            {
                //Sitecore.Data.Fields.CheckboxField IsVisible = contentItem.Fields["IsVisible"];
                //if (contentItem.TemplateID!=Templates.PageItem.Fields.TempId && IsVisible.Checked)
                //{
                    PageItem item = new PageItem();
                    item.PageTitle = contentItem.DisplayName;
                    item.PageLink = contentItem.Paths.ContentPath;
                    Items.Add(item);
                    //if (contentItem.HasChildren)
                    //{
                    //    foreach (Item contentItem1 in contentItem.Children)
                    //    {
                    //        PageItem item1 = new PageItem();
                    //        item1.PageTitle = contentItem1.Name;
                    //        item1.PageLink = contentItem1.Paths.ContentPath;
                    //        Items.Add(item1);

                    //    }
                    //}
             //   }
 
            }
            return View(Items);
        }
    }
}