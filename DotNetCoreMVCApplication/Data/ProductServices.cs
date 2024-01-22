using DotNetCoreMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace DotNetCoreMVCApplication.Data
{
    public class ProductServices
    {
        private static List<ProductViewModel> product_list = new List<ProductViewModel>();  //globally declare list
        private static int lastProductId = 0; 

        public void AddProduct(ProductViewModel product)
        {
            product.Id = ++lastProductId; // add a primary id for each record
            
            product_list.Add(product);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            return product_list;
        }
    }
}
