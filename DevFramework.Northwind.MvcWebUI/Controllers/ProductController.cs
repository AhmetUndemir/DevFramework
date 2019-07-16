using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryID = 1,
                ProductName = "Notebook",
                QuantityPerUnit = "2",
                UnitPrice = 22
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryID = 1,
                ProductName = "Notebook",
                QuantityPerUnit = "2",
                UnitPrice = 2
            },
            new Product
            {
                CategoryID = 1,
                ProductName = "Notebook",
                QuantityPerUnit = "2",
                UnitPrice = 10
            }
            );

            return "Done";
        }
    }
}