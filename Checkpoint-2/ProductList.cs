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
        {   //Method that adds a product to the list
            products.Add(product);
        }
        public Product SearchProductInList(string productName)
        {   //Method that searches for a product in list and returns a new product that matcher the find or null if not found
            return products.Find(product => product.ProductName == productName);
        }
        public void DisplayProductList(Product searchProduct = null)
        {   //Method that prints the product list sorted by price with the sum added at the bottom
            //if a product was entered and the product wasn't null (therefor found)
            //the searched for product will be highlighted and there will be NO sum at the bottom
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
