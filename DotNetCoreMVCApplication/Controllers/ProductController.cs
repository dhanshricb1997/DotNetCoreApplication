using DotNetCoreMVCApplication.Data;
using DotNetCoreMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace DotNetCoreMVCApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _productService;

        public ProductController(ProductServices productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            List<ProductViewModel> allProducts = _productService.GetAllProducts();  // get all the record
            return View(allProducts);
        }
        [HttpGet]
        public IActionResult addProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addProduct(ProductViewModel viewModel)
        {
            
            if (viewModel.productName == null)
            {
                return View(viewModel);
            }
            else if(viewModel.productDescription == null)
            {
                return View(viewModel);
            }
            else
            _productService.AddProduct(viewModel);
            ModelState.Clear();
            return RedirectToAction("Index");
            
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the product by ID
            ProductViewModel productToEdit = _productService.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (productToEdit == null)
            {
                return NotFound(); // Product not found
            }

            return View(productToEdit);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel editedProduct)
        {
            // Find the original product by ID
            ProductViewModel originalProduct = _productService.GetAllProducts().FirstOrDefault(p => p.Id == editedProduct.Id);

            if (originalProduct == null)
            {
                return NotFound(); // Product not found
            }

            // Update the properties of the original product
            originalProduct.productName = editedProduct.productName;
            originalProduct.productDescription = editedProduct.productDescription;

            // Redirect to the index page after editing
            return RedirectToAction("Index");
        }

    }
}
