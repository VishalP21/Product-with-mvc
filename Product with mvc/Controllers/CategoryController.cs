using Microsoft.AspNetCore.Mvc;

namespace Product_with_mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult dis()
        {
            using NorthwndContext context = new NorthwndContext();
            var v = context.Categories.ToList();
            return View(v);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult delete(int id)
        {
            using NorthwndContext ctx = new NorthwndContext();
            var data = ctx.Categories.SingleOrDefault(y=>y.CategoryId == id);
            ctx.Categories.Remove(data);
            ctx.SaveChanges();
            return RedirectToAction("dis");
        }

        public IActionResult Edit(int id)
        {
            using NorthwndContext ctx = new NorthwndContext();
            var data = ctx.Categories.SingleOrDefault(y => y.CategoryId == id);
            return View("Index",data);
        }


        [HttpPost]

        public IActionResult Index(Category category)
        {
            using NorthwndContext context = new NorthwndContext();
            if(category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                var p = context.Categories.SingleOrDefault(y=>y.CategoryId == category.CategoryId);
                p.CategoryName = category.CategoryName;
                p.Description = category.Description;
            }
            
            context.SaveChanges();
            return RedirectToAction("dis");
        }
    }
}
