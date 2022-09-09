
//Checkpoint-2-Productlist
//Created by Malin Wirén

using Checkpoint_2;

// Global variables

ProductList productList = new ProductList();

bool quitEnterProductLoop;


//Main-method

EnterProduct();
MoreOptionsMenu();


//Methods

#region Enter a Product

void EnterProduct()
{   //Method that loops and adds new products to list until user writes Q to exit and at the end prints the list
    quitEnterProductLoop = false;
    while (true)  
    {
        Divider();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
        Console.ResetColor();

        string category = EnterCategory();
        if (quitEnterProductLoop) { break; }
        string productName = EnterProductName();
        if (quitEnterProductLoop) { break; }
        int price = EnterPrice();
        if (quitEnterProductLoop) { break; }  //repeat of the call to ensure that it quits when called and not after

        productList.AddProductToList(new Product(category, productName, price));

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("The product was succefully added!");
        Console.ResetColor();
    }
    Divider();
    productList.DisplayProductList();
    Divider();
}

string EnterCategory() 
{   //Method that allows the user to enter a category and makes sure that it isn't empty and the returns the name
    while (true)  //return statements breaks the loop
    {
        Console.Write("Enter a Category: ");
        string category = Console.ReadLine();
        if (EnterQuit(category))
        {
            quitEnterProductLoop = true;
            return "";
        }
        else if (category.Trim() != "")
        {
            return category;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error: Category can't be empty!");
            Console.ResetColor();
        }
    }
}

string EnterProductName()
{   //Method that allows the user to enter a product name and makes sure that it isn't empty the returns the name
    while (true)  //return statements breaks the loop
    {
        Console.Write("Enter a Product Name: ");
        string productName = Console.ReadLine();
        if (EnterQuit(productName))
        {
            quitEnterProductLoop = true;
            return "";
        }
        else if (productName.Trim() != "")
        {
            return productName;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error: Product Name can't be empty!");
            Console.ResetColor();
        }
    }
}

int EnterPrice()
{   //Method that allows the user to enter a price and makes sure that it is a number the returns the number
    while (true)  //return statements breaks the loop
    {
        Console.Write("Enter a Price: ");
        string priceString = Console.ReadLine();
        if (EnterQuit(priceString))
        {
            quitEnterProductLoop = true;
            return 0;
        }
        else if (int.TryParse(priceString, out int price))
        {
            return price;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error: Price needs to be a number!");
            Console.ResetColor();
        }
    }
}
#endregion

#region More Options to ReEnter or Search

void MoreOptionsMenu()
{   //Method that asks the user if they want to enter a new product, search for a product or exit the program
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
        Console.ResetColor();

        string inputString = Console.ReadLine();
        string input = inputString.Trim().ToUpper();

        if (input == "P")
        {
            EnterProduct();
        }
        else if (input == "S")
        {
            SearchProduct();
        }
        else if (input == "Q")
        {
            break;
        }
    }
}

void SearchProduct()
{   //Method that allows the user to enter a product name to serach for and if found prints the list
    Console.Write("Enter a Product Name: ");
    string input = Console.ReadLine();
    Product searchProduct = productList.SearchProductInList(input);
    if (searchProduct != null)
    {
        Divider();
        productList.DisplayProductList(searchProduct);
        Divider();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("The product was not in the list");
        Console.ResetColor();
    }
}
#endregion

bool EnterQuit(string input)
{   //Method that verifies if the user has entered a quit statemenrt and returns a bool
    string testInput = input.ToUpper().Trim();
    if (testInput == "Q" || testInput == "QUIT")
    {
        return true;
    }
    else
    {
        return false;
    }
}

void Divider()
{   //Method that writes a dividing line in the console window
    Console.WriteLine("--------------------------------------------------");
}