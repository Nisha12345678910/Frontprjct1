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
    public class ProductController : Controller
    {
        
        // GET: Product
        public ActionResult ProductCallout()
        {
            // var product = Sitecore.Context.Database.GetItem("sitecore/Content/Home/ProductPage");
            Item currentpage = Sitecore.Context.Item;
            var product = currentpage;
            Sitecore.Data.Fields.MultilistField productList = product.Fields["ProductCalloutList"];
            Item[] Products = productList.GetItems();
           var productCallouts = new List<ProductCallout>();
            foreach(Item ProductItem in Products)
            {
                ProductCallout product1 = new ProductCallout();
                product1.ProductTitle = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutTitle].Value;
                 Sitecore.Data.Fields.LinkField link = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutLink];               
                if (link.LinkType=="internal")
                {
                    product1.ProductLink = Sitecore.Links.LinkManager.GetItemUrl(link.TargetItem);
                }
                else {
                    product1.ProductLink = link.Url;
                }            
                Sitecore.Data.Fields.ImageField imgField = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutImage];
                string url = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                product1.ProductImage = url;
                product1.ProductSubTitle = ProductItem.Fields[Templates.ProductCallout.Fields.ProductCalloutSubTutle].Value;
                productCallouts.Add(product1);
           }            
            return View(productCallouts);
        }

        public ActionResult  GetProductList()
        {
            var product = Sitecore.Context.Database.GetItem("sitecore/Content/Home/ProductPage");
            var productlist = new List<Product>();
           
            foreach (Item ProductItem in product.Children)
            {
                Sitecore.Data.Fields.CheckboxField IsVisible = ProductItem.Fields["IsVisible"];
                if (IsVisible.Checked)
                {
                    Product product1 = new Product();
                    product1.ProductPageTitle = ProductItem.Name;
                    product1.ProductPageLink = ProductItem.Paths.ContentPath;
                    productlist.Add(product1);
                }
                
            }
            return View(productlist);
        }

    }
}