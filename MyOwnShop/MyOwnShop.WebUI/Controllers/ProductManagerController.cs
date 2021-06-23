﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOwnShop.Core.Models;
using MyOwnShop.Core.ViewModels;
using MyOwnShop.DataAccess.InMemory;

namespace MyOwnShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;
        ProductCategoryRepository productCategories;//So we can load our product categories from the database
        public ProductManagerController()
		{
            context = new ProductRepository();
            productCategories = new ProductCategoryRepository();
		}
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public  ActionResult Create()
		{
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
		}
        [HttpPost]
        public  ActionResult Create(Product product)
		{
			if (!ModelState.IsValid)
			{
                return View(product);
			}
			else
			{
                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
			}
		}
        public  ActionResult Edit(String Id)
		{
            Product product = context.Find(Id);
			if (product == null)
			{
                return HttpNotFound();
			}
			else
			{
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();

                return View(viewModel);
			}
		}
        [HttpPost]
        public  ActionResult Edit(Product product,string Id)
		{
            Product productToEdit = context.Find(Id); 
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
				if(!ModelState.IsValid){
                    return View(product);
				}
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Commit();

                return RedirectToAction("Index");

            }
        }
        public ActionResult Delete(string Id)
		{
            Product productToDelete = context.Find(Id);
			if (productToDelete == null)
			{
                return HttpNotFound();
			}
			else
			{
                return View(productToDelete);
			}

		}
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimDelete(string Id)
		{
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}