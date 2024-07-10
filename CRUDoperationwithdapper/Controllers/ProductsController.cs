using CRUDoperationwithdapper.Models;
using CRUDoperationwithdapper.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperationwithdapper.Controllers
{
    public class ProductsController : Controller
    {

        private readonly Iproduct productRepository;

        public ProductsController(Iproduct product)
        {
            productRepository = product;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productRepository.Get();
            return View(products);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await productRepository.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                await productRepository.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await productRepository.Find(id);
            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProductModel model)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var product = await productRepository.Find(id);

            if (product == null)
            {
                return BadRequest();
            }
            await productRepository.Update(model);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product = await productRepository.Find(id);

            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
        // POST: Products/Delete/{id}
        [HttpPost, ActionName("DeleteConfirmed")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            var product = await productRepository.Find(id);
            await productRepository.Remove(product);
            return RedirectToAction(nameof(Index));






        }
    }
}
