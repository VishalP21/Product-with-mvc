using Microsoft.AspNetCore.Mvc;

namespace Product_with_mvc.Controllers
{
    public class ProductController : Controller
    {
        

        public IActionResult Index()
        {
           using NorthwndContext context = new NorthwndContext();

            var product = context.Products.ToList();

            return View(product);
        }

		public IActionResult addproduct()
		{

			return View();

		}

		public IActionResult updateproduct(int id)
		{
			using NorthwndContext context = new NorthwndContext();
			var record = context.Products.SingleOrDefault(y => y.ProductId == id);
			return View("addproduct", record);
		}

		[HttpPost]

        public IActionResult addproduct(Product product)
        {
			using NorthwndContext context = new NorthwndContext();

            if(product.ProductId == 0)
            {
            context.Products.Add(product);
            }
            else
            {
                var recrd = context.Products.SingleOrDefault(x => x.ProductId == product.ProductId);
                recrd.ProductName = product.ProductName;
                recrd.UnitPrice = product.UnitPrice;
            }
            context.SaveChanges();
			return RedirectToAction("Index");
        }

        public IActionResult deleteproduct(int id)
        {
			using NorthwndContext context = new NorthwndContext();
            var record = context.Products.SingleOrDefault(y=>y.ProductId == id);
            context.Products.Remove(record);
            context.SaveChanges();
            return RedirectToAction("Index");
		}

    }
}
