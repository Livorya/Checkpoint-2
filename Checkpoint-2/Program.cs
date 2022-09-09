
//Checkpoint-2-Productlist
//Created by Malin Wirén

using Checkpoint_2;

// Global variables

ProductList productList = new ProductList();

bool quitEnterProductLoop = false;


//Main-method

EnterProduct();
MoreOptionsMenu();


//Methods

#region Enter a Product

void EnterProduct()
{
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
    productList.DisplayProductListPadded();
    Divider();
}

string EnterCategory() 
{
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
            return Captalized(category);
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
{
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
            return Captalized(productName);
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
{
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
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
        Console.ResetColor();

        string inputString = Console.ReadLine();
        string input = inputString.Trim().ToUpper();

        if (input == "P")
        {
            ReEnterProduct();
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

void ReEnterProduct()
{
    quitEnterProductLoop = false;
    EnterProduct();
}

void SearchProduct()
{
    Console.Write("Enter a Product Name: ");
    string input = Console.ReadLine();
    Product searchProduct = productList.SearchProductInList(Captalized(input));
    if (searchProduct != null)
    {
        Divider();
        productList.DisplayProductListPadded(searchProduct);
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
{
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

string Captalized(string input)
{
    string trimmedInput = input.Trim();
    if (string.IsNullOrEmpty(trimmedInput))
    {
        return "";
    }
    trimmedInput = char.ToUpper(trimmedInput[0]) + trimmedInput.Substring(1).ToLower();
    return trimmedInput;
}

void Divider()
{
    Console.WriteLine("--------------------------------------------------");
}