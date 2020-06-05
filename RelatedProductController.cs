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
    public class RelatedProductController : Controller
    {
        // GET: RelatedProduct
        public ActionResult RelatedProducts()
        {
            Item currentPage = Sitecore.Context.Item;
            Sitecore.Data.Fields.MultilistField  relatedProducts = currentPage.Fields["RelatedProductList"];
            Item[] Products = relatedProducts.GetItems();
            var RelatedProductList = new List<ProductCallout>();
            foreach(Item ProductItem in Products)
            {
                ProductCallout product1 = new ProductCallout();
                product1.ProductTitle = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutTitle].Value;
                Sitecore.Data.Fields.LinkField link = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutLink];
                if (link.LinkType == "internal")
                {
                    product1.ProductLink = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                }
                else
                {
                    product1.ProductLink = link.Url;
                }
                Sitecore.Data.Fields.ImageField imgField = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutImage];
                string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                product1.ProductImage = url;
                product1.ProductSubTitle = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutSubTutle].Value;
                RelatedProductList.Add(product1);
            }

            return View(RelatedProductList);
        }
    }
}