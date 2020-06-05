using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using TrainingWebApplication.Models.CommonModel;
namespace TrainingWebApplication.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: HeaderMenu
        public ActionResult HeaderMenu()
        {          
            var NavFolder = Sitecore.Context.Database.GetItem("sitecore/content/Home/Global/NavLinks");
            var NavLinks = new List<HeaderMenu>();
            var MenuLinks = NavFolder.GetChildren();
            foreach (Item Menuitems in MenuLinks)
            {
                 
                HeaderMenu menu = new HeaderMenu();
                menu.NavTitle = Menuitems.Fields["NavTitle"].Value;
                Sitecore.Data.Fields.LinkField link = Menuitems.Fields["NavLink"];
                if (link.LinkType == "internal")
                {
                    menu.NavLink = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                }
                else
                {
                    menu.NavLink = link.Url;
                }
               
                NavLinks.Add(menu);
            }
            return View(NavLinks);
        }
        public ActionResult HomeCalloutSection()
        {
             
            var HomeCalloutFolder = Sitecore.Context.Database.GetItem("sitecore/content/Home/Global/HomeCallouts");
            var HomeCallouts = new List<CalloutSection>();
            var AllHomeCallout = HomeCalloutFolder.GetChildren();
            foreach (Item HomeCalloutItem in AllHomeCallout)
            {
                CalloutSection homeCallout = new CalloutSection();
                homeCallout.CalloutTitle = HomeCalloutItem.Fields["HomeCalloutTitle"].Value;
                homeCallout.CalloutSubtitle = HomeCalloutItem.Fields["HomeCalloutSubtitle"].Value;

                Sitecore.Data.Fields.LinkField link = HomeCalloutItem.Fields["HomeCalloutLink"];
                if (link.LinkType == "internal")
                {
                    homeCallout.CalloutLink = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                }
                else
                {
                    homeCallout.CalloutLink = link.Url;
                }
                 Sitecore.Data.Fields.ImageField imageField = HomeCalloutItem.Fields[""];
                //homeCallout.CalloutImage =imageField.MediaItem.ToString();
                //homeCallout.CalloutImage = FieldRenderer.Render(HomeCalloutItem, "HomeCalloutImage");
                HomeCallouts.Add(homeCallout);
            }
            return View(HomeCallouts);
        }
        public ActionResult SectionCallout()
        {
            var SectionCalloutFolder = Sitecore.Context.Database.GetItem("sitecore/content/Home/Global/Sections");
            var SectionCallouts = new List<CalloutSection>();
            var AllCalloutSection = SectionCalloutFolder.GetChildren();
            foreach (Item SectionCalloutItem in AllCalloutSection)
            {

                CalloutSection section = new CalloutSection();
                section.CalloutTitle = SectionCalloutItem.Fields["SectionTitle"].Value;
                section.CalloutSubtitle = SectionCalloutItem.Fields["SectionSubTitle"].Value;
                Sitecore.Data.Fields.LinkField link = SectionCalloutItem.Fields["SectionLink"];
                section.CalloutLink = link.Url;
                SectionCallouts.Add(section);
            }
            return View(SectionCallouts);
        }

 
    }
}