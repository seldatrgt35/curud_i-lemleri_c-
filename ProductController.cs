using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // 1️⃣ **Tüm Ürünleri Listeleme**
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // 2️⃣ **Yeni Ürün Ekleme (GET)**
        public IActionResult Create()
        {
            return View();
        }

        // 2️⃣ **Yeni Ürün Ekleme (POST)**
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // 3️⃣ **Ürün Güncelleme (GET)**
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // 3️⃣ **Ürün Güncelleme (POST)**
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // 4️⃣ **Ürün Silme**
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
