using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint_2
{
    internal class Product
    {
        public string Category { get; private set; }
        public string ProductName { get; private set; }
        public int Price { get; private set; }

        public Product(string category, string productName, int price)
        {
            Category = category;
            ProductName = productName;
            Price = price;
        }

        public void DisplayProductPadded(int padding)
        {
            Console.WriteLine(Category.PadRight(padding) + ProductName.PadRight(padding) + Price);
        }
    }
}
