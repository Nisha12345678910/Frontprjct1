using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingWebApplication.Models.CommonModel;
using Utilities;

namespace TrainingWebApplication.Controllers
{
    public class Home1Controller : Controller
    {
        // GET: Home1
        public ActionResult Home1CalloutSection()
        {

            var home = Sitecore.Context.Database.GetItem("sitecore/content/Home/LandingPage");
            //var AllHomeCallout = HomeCalloutFolder.GetChildren();
            var HomeCallouts = new List<CalloutSection>();
              
            Sitecore.Data.Fields.MultilistField multiselectField = home.Fields["HomeCalloutList"];
            Item[] AllHomeCallout = multiselectField.GetItems();
            foreach (Item HomeCalloutItem in AllHomeCallout)
            {
                CalloutSection homeCallout = new CalloutSection();
                homeCallout.CalloutTitle= HomeCalloutItem.Fields[Templates.Callout.Fields.HomeCalloutTitle].Value ;
                 homeCallout.CalloutSubtitle = HomeCalloutItem.Fields[Templates.Callout.Fields.HomeCalloutSubtitle].Value;
                Sitecore.Data.Fields.LinkField link = HomeCalloutItem.Fields[Templates.Callout.Fields.HomeCalloutLink];
                homeCallout.CalloutLink = link.Url;
                Sitecore.Data.Fields.ImageField imgField = HomeCalloutItem.Fields[Templates.Callout.Fields.HomeCalloutImage];
                string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                homeCallout.CalloutImage = url;
                HomeCallouts.Add(homeCallout);
            }
            return View(HomeCallouts);
        }

        public ActionResult SectionCallout1()
        {

            var home = Sitecore.Context.Database.GetItem("sitecore/content/Home/LandingPage");
            //var AllHomeCallout = HomeCalloutFolder.GetChildren();
            var SectionCallouts = new List<CalloutSection>();

            Sitecore.Data.Fields.MultilistField multiselectField = home.Fields["SectionCalloutListItem"];
            Item[] AllSectionCallout = multiselectField.GetItems();
            foreach (Item SectionCalloutItem in AllSectionCallout)
            {
                CalloutSection sectionCallout = new CalloutSection();
                sectionCallout.CalloutTitle = SectionCalloutItem.Fields[Templates.SectionCallout.Fields.SectionTitle].Value;
                sectionCallout.CalloutSubtitle = SectionCalloutItem.Fields[Templates.SectionCallout.Fields.SectionSubtitle].Value;
                Sitecore.Data.Fields.LinkField link = SectionCalloutItem.Fields[Templates.SectionCallout.Fields.SectionLink];
                sectionCallout.CalloutLink = link.Url;
                Sitecore.Data.Fields.ImageField imgField = SectionCalloutItem.Fields[Templates.SectionCallout.Fields.SectiontImage];
                string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                sectionCallout.CalloutImage = url;
                SectionCallouts.Add(sectionCallout);
            }
            return View(SectionCallouts);
        }
    }
}