using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Website.ViewModels;
using Agility.Web;

namespace Website.Controllers
{
    public class ProductsController : Controller
    {


        public ActionResult ProductDetailsModule(Module_ProductDetails module)
        {
            var product = AgilityContext.GetDynamicPageItem<Product>();

            var model = new ProductDetailsModule();
            model.Module = module;

            if (product != null && product.ReferenceName == "Products")
            {
                model.Product = product;

                var category = new AgilityContentRepository<ProductCategory>("ProductCategories").Items().Where(i => i.ContentID == product.ProductCategoryID).FirstOrDefault();
                model.Category = category;
            }

            return PartialView(model);
        }

        public ActionResult ProductListingModule(Module_ProductListing module)
        {
            HttpContext.Response.Cache.VaryByParams["*"] = true;

            int categoryID = 0;
            int page = 0;
            int.TryParse(string.Format("{0}", Request.QueryString["category"]), out categoryID);
            int.TryParse(string.Format("{0}", Request.QueryString["page"]), out page);

            if (page == 0) page = 1;

            int totalCount = 0;
            int pageSize = module.ProductsPerPage;
            string rowFilter = "";

            if (categoryID > 0)
            {
                rowFilter = string.Format("ProductCategoryID = {0}", categoryID);
            }

            int skip = (page - 1) * pageSize;
            int take = pageSize;

            var products = new AgilityContentRepository<Product>("Products").Items(rowFilter, "Title ASC", take, skip, out totalCount);

            var model = new ProductListingModule();
            model.Categories = new AgilityContentRepository<ProductCategory>("ProductCategories").Items();
            model.FilteredCategory = model.Categories.Where(i => i.ContentID == categoryID).FirstOrDefault();
            model.Products = products;
            model.Module = module;

            var pagination = new Pagination();
            pagination.BaseUrl = Request.Url;
            pagination.CurrentPageNumber = page;
            pagination.ResultsPerPage = module.ProductsPerPage;
            pagination.PaginationAs = PaginationMode.PageNumbers;
            pagination.TotalResults = totalCount;

            model.Pagination = pagination;

            return PartialView(model);
        }

    }
}
