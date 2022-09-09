using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_2
{
    internal class ProductList
    {
        private List<Product> products;
        private const int padding = 20;

        public ProductList()
        {
            products = new List<Product>();
        }

        public void AddProductToList(Product product)
        {
            products.Add(product);
        }
        public Product SearchProductInList(string productName)
        {
            return products.Find(product => product.ProductName == productName);
        }
        public void DisplayProductListPadded(Product searchProduct = null)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Category".PadRight(padding) + "Product".PadRight(padding) + "Price");
            Console.ResetColor();

            List<Product> sortedProducts = products.OrderBy(product => product.Price).ToList();
            int totalAmount = 0;

            bool search = false;
            foreach (Product product in sortedProducts)
            {
                if (product == searchProduct)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    search = true;
                }
                product.DisplayProductPadded(padding);
                Console.ResetColor();
                totalAmount += product.Price;
            }
            if (!search)
            {
                Console.WriteLine();
                Console.WriteLine("".PadRight(padding) + "Total amount:".PadRight(padding) + totalAmount);
            }
        }
    }
}
