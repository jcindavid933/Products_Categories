using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using products_categories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace products_categories.Controllers
{
    public class HomeController : Controller
    {
        private Context dbContext;

        public HomeController(Context context)
        {
            dbContext = context;
        }
        public ViewResult Index()
        {
            List<Product> products = dbContext.Product.ToList();
            ViewBag.products = products;
            return View();
        }

        [HttpPost("create_product")]
        public IActionResult Product(Product product)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(product);
                dbContext.SaveChanges();
                product = new Product();
                return RedirectToAction("Index");
            }
            else
            {
                List<Product> products = dbContext.Product.ToList();
                ViewBag.products = products;
                return View("Index", product);
            }
        }

        [HttpGet("categories")]
        public ViewResult Categories()
        {
            List<Category> categories = dbContext.Category.ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost("create_category")]
        public IActionResult Category(Category category)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(category);
                dbContext.SaveChanges();
                category = new Category();
                return RedirectToAction("Categories");
            }
            else
            {
                List<Category> categories = dbContext.Category.ToList();
                ViewBag.categories = categories;
                return View("Categories", category);
            }
        }
        [HttpGet("categories/{id}")]
        public ViewResult Category_Show(int id)
        {
            Category category = dbContext.Category.Include(p => p.Associations).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == id);
            ViewBag.products = dbContext.Product.ToList();
            return View(category);
        }

        [HttpGet("products/{id}")]
        public ViewResult Product_Show(int id)
        {
            Product product = dbContext.Product.Include(p => p.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == id);
            ViewBag.categories = dbContext.Category.ToList();
            return View(product);
        }

        [HttpPost("Associations")]
        public IActionResult CreateAssociation(int cat, int pro)
        {
            Product product = dbContext.Product.Include(p => p.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == id);
            Boolean found = product.Associations.Any(a => a.ProductId == pro);
            if (!found)
            {
                Associations association = new Associations{ProductId=pro, CategoryId=cat};
                dbContext.Associations.Add(association);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
            // return Redirect($"products/");
        }
    }
}
