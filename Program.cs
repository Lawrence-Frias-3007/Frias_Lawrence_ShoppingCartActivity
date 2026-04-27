using System;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] products = new Product[]
            {
                new Product {id = 101, name = "Eggs", price = 230, remainingStock = 200, category = "Protein/Meat"},
                new Product {id = 102, name = "Bread", price = 75, remainingStock = 100, category = "Grains"},
                new Product {id = 103, name = "Milk", price = 150, remainingStock = 100, category = "Dairy"},
                new Product {id = 104, name = "Chicken", price = 250, remainingStock = 200, category = "Protein/Meat"},
                new Product {id = 105, name = "Pork", price = 330, remainingStock = 200, category = "Protein/Meat"},
                new Product {id = 106, name = "Beef", price = 450, remainingStock = 200, category = "Protein/Meat"},
                new Product {id = 107, name = "Sardines", price = 40, remainingStock = 250, category = "Fish/Meat"},
                new Product {id = 108, name = "Carrots", price = 80, remainingStock = 100, category = "Vegetables"},
                new Product {id = 109, name = "Garlic", price = 100, remainingStock = 100, category = "Vegetables"},
                new Product {id = 110, name = "Onions", price = 80, remainingStock = 100, category = "Vegetables"},
                new Product {id = 111, name = "Potato", price = 85, remainingStock = 100, category = "Vegetables"},
                new Product {id = 112, name = "Tomato", price = 70, remainingStock = 100, category = "Vegetables"}
            };

            Console.WriteLine("PRODUCT ID     PRODUCT NAME     PRICE (Php)     REMAINING STOCK");
            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            int productNumber;
            int quantity;
            string choice = "Y";

            int[] cartProductIds = new int[10];
            int[] cartQuantities = new int[10];

            int menuChoice;

            do
            {
                Console.WriteLine("\n******** MAIN MENU ********");
                Console.WriteLine("1 - Add Products");
                Console.WriteLine("2 - Manage Cart");
                Console.WriteLine("3 - Search Product name");
                Console.WriteLine("4 - Search By Category");
                Console.WriteLine("5 - Checkout");
                Console.Write("Enter your choice (1-5): ");
                while (!int.TryParse(Console.ReadLine(), out menuChoice))
                {
                    Console.WriteLine("\n-- Input must be a number between 1-5 --");
                    Console.Write("Enter your choice (1-5): ");
                }

                switch (menuChoice)
                {
                    case 1:
                        do
                        {
                            bool exists = false;
                        
                            Console.Write("\nEnter product number: ");
                        
                            if (!int.TryParse(Console.ReadLine(), out productNumber))
                            {
                                Console.WriteLine("\n-- Invalid product number --");
                                continue;
                            }
                        
                            int productIndex = 0;
                        
                            for (int i = 0; i < products.Length; i++)
                            {
                                if (products[i].id == productNumber)
                                {
                                    exists = true;
                                    productIndex = i;
                                    break;
                                }
                            }
                        
                            if (!exists)
                            {
                                Console.WriteLine("\n-- Product not found --");
                                continue;
                            }
                        
                            if (products[productIndex].remainingStock == 0)
                            {
                                Console.WriteLine("\n-- Product is out of stock --");
                                continue;
                            }
                        
                            Console.Write("Enter quantity: ");
                        
                            if (!int.TryParse(Console.ReadLine(), out quantity))
                            {
                                Console.WriteLine("\n-- Invalid quantity --");
                                continue;
                            }
                        
                            if (quantity <= 0)
                            {
                                Console.WriteLine("\n-- Invalid quantity --");
                                continue;
                            }
                        
                            if (!products[productIndex].HasEnoughStock(quantity))
                            {
                                Console.WriteLine("\n-- Not enough stock available --");
                                continue;
                            }
                        
                            bool foundInCart = false;
                        
                            for (int i = 0; i < cartProductIds.Length; i++)
                            {
                                if (cartProductIds[i] == productNumber)
                                {
                                    cartQuantities[i] += quantity;
                                    foundInCart = true;
                        
                                    products[productIndex].DeductStock(quantity);
                        
                                    Console.WriteLine("\n-- Item added --");
                                    break;
                                }
                            }
                        
                            if (!foundInCart)
                            {
                                bool added = false;
                        
                                for (int i = 0; i < cartProductIds.Length; i++)
                                {
                                    if (cartProductIds[i] == 0)
                                    {
                                        cartProductIds[i] = productNumber;
                                        cartQuantities[i] = quantity;
                                        added = true;
                        
                                        products[productIndex].DeductStock(quantity);
                        
                                        Console.WriteLine("\n-- Item added to cart --");
                                        break;
                                    }
                                }
                        
                                if (!added)
                                {
                                    Console.WriteLine("\n-- Cart is full (You can still add quantity to existing items) --");
                                }
                            }
                        
                            Console.Write("\nAdd more items? (Y/N): ");
                            choice = Console.ReadLine().ToUpper().Trim();
                        
                            while (choice != "Y" && choice != "N")
                            {
                                Console.Write("Type only 'Y' (yes) or 'N' (no): ");
                                choice = Console.ReadLine().ToUpper().Trim();
                            }
                        } while (choice != "N");
                        break;
                    case 2:
                        int cartChoice;
                        do
                        {
                            Console.WriteLine("\n******** CART MANAGEMENT MENU ********");
                            Console.WriteLine("1 - View Cart");
                            Console.WriteLine("2 - Remove an Item from Cart");
                            Console.WriteLine("3 - Update Quantity (subtract item quantity)"); // adding product quantity is already automated just by adding a product to cart
                            Console.WriteLine("4 - Clear Cart");
                            Console.WriteLine("5 - Exit");
                            Console.Write("Enter your choice (1-5): ");
                            while (!int.TryParse(Console.ReadLine(), out cartChoice))
                            {
                                Console.WriteLine("\n-- Input must be a number between 1-5 --");
                                Console.Write("Enter your choice (1-5): ");
                            }

                            switch (cartChoice)
                            {
                                case 1:
                                    Console.WriteLine("\n** CART **");
                                    bool hasItems = false;
                                    
                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] != 0)
                                        {
                                            hasItems = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!hasItems)
                                    {
                                        Console.WriteLine("-- No Items available --");
                                        break;
                                    }
                                    
                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] == 0)
                                        {
                                            continue;
                                        }
                                    
                                        for (int j = 0; j < products.Length; j++)
                                        {
                                            if (products[j].id == cartProductIds[i])
                                            {
                                                Console.WriteLine($"{products[j].id}: {products[j].name} x{cartQuantities[i]}");
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    bool hasItemCase2 = false;

                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] != 0)
                                        {
                                            hasItemCase2 = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!hasItemCase2)
                                    {
                                        Console.WriteLine("\n-- Cart is empty --");
                                        break;
                                    }
                                    
                                    int idRemove;

                                    Console.Write("Enter ID number of item you want to remove: ");
                                    while (!int.TryParse(Console.ReadLine(), out idRemove))
                                    {
                                        Console.WriteLine("\n-- Invalid input, item ID must be a number --");
                                        Console.Write("Enter ID number of item you want to remove: ");
                                    }
                                    
                                    if (idRemove == 0)
                                    {
                                        Console.WriteLine("\n-- Product does not exist in cart --");
                                        break;
                                    }
                                    
                                    bool existsRemove = false;
                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] == idRemove)
                                        {
                                            existsRemove = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!existsRemove)
                                    {
                                        Console.WriteLine("\n-- Product does not exist in cart --");
                                    }
                                    
                                    if (existsRemove)
                                    {
                                        for (int i = 0; i < cartProductIds.Length; i++)
                                        {
                                            if (cartProductIds[i] == idRemove)
                                            {
                                                for (int j = 0; j < products.Length; j++)
                                                {
                                                    if (products[j].id == idRemove)
                                                    {
                                                        products[j].remainingStock += cartQuantities[i];
                                                    }
                                                }
                                    
                                                cartProductIds[i] = 0;
                                                cartQuantities[i] = 0;
                                                Console.WriteLine("\nItem removed from cart");
                                                break;
                                            }
                                        }
                                    
                                    }
                                    break;
                                case 3:
                                    bool hasItemCase3 = false;

                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] != 0)
                                        {
                                            hasItemCase3 = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!hasItemCase3)
                                    {
                                        Console.WriteLine("\n-- Cart is empty --");
                                        break;
                                    }
                                    
                                    int idSubQty;
                                    int quantitySub;
                                    
                                    Console.Write("Enter product ID: ");
                                    while (!int.TryParse(Console.ReadLine(), out idSubQty))
                                    {
                                        Console.WriteLine("\n-- Invalid input, item ID must be a number --");
                                        Console.Write("Enter product Id: ");
                                    }
                                    
                                    if (idSubQty == 0)
                                    {
                                        Console.WriteLine("\n-- Product does not exist in cart --");
                                        break;
                                    }
                                    
                                    bool existsCase3 = false;
                                    int index = 0;
                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] == idSubQty)
                                        {
                                            index = i;
                                            existsCase3 = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!existsCase3)
                                    {
                                        Console.WriteLine("\n-- Product does not exist in cart --");
                                        break;
                                    }
                                    
                                    while (true)
                                    {
                                        Console.Write("Enter quantity you want to subtract: ");
                                        while (!int.TryParse(Console.ReadLine(), out quantitySub))
                                        {
                                            Console.WriteLine("\n-- Quantity must be a valid number --");
                                            Console.Write("Enter quantity you want to subtract: ");
                                        }
                                    
                                        if (quantitySub <= 0)
                                        {
                                            Console.WriteLine("\n-- Invalid input --");
                                            continue;
                                        }
                                    
                                        if (quantitySub > cartQuantities[index])
                                        {
                                            Console.WriteLine("\n-- Not enough quantity in cart --");
                                            continue;
                                        }
                                    
                                        for (int j = 0; j < products.Length; j++)
                                        {
                                            if (products[j].id == idSubQty)
                                            {
                                                products[j].remainingStock += quantitySub;
                                                break;
                                            }
                                        }
                                    
                                        cartQuantities[index] -= quantitySub;
                                    
                                        if (cartQuantities[index] == 0)
                                        {
                                            cartProductIds[index] = 0;
                                        }
                                    
                                        Console.WriteLine("\nItem quantity updated");
                                        break;
                                    }
                                    break;
                                case 4:
                                    bool hasItemCase4 = false;

                                    for (int i = 0; i < cartProductIds.Length; i++)
                                    {
                                        if (cartProductIds[i] != 0)
                                        {
                                            hasItemCase4 = true;
                                            break;
                                        }
                                    }
                                    
                                    if (!hasItemCase4)
                                    {
                                        Console.WriteLine("\n-- Cart is empty --");
                                        break;
                                    }
                                    
                                    string sureInput;

                                    Console.WriteLine("\nAre you sure? This will clear all your items in cart.");
                                    Console.Write("Y/N: ");
                                    sureInput = Console.ReadLine().ToUpper().Trim();
                                    
                                    while (sureInput != "Y" && sureInput != "N")
                                    {
                                        Console.Write("Type only 'Y' (yes) or 'N' (no): ");
                                        sureInput = Console.ReadLine().ToUpper().Trim();
                                    }
                                    
                                    if (sureInput == "Y")
                                    {
                                        for (int i = 0; i < cartProductIds.Length; i++)
                                        {
                                            if (cartProductIds[i] == 0)
                                            {
                                                continue;
                                            }
                                    
                                            for (int j = 0; j < products.Length; j++)
                                            {
                                                if (products[j].id == cartProductIds[i])
                                                {
                                                    products[j].remainingStock += cartQuantities[i];
                                                    break;
                                                }
                                            }
                                    
                                            cartProductIds[i] = 0;
                                            cartQuantities[i] = 0;
                                        }
                                    
                                        Console.WriteLine("\nCart cleared successfully");
                                    }
                                    break;
                                case 5:
                                    break;
                                default:
                                    Console.WriteLine("\n-- Invalid input --");
                                    break;
                            }
                        } while (cartChoice != 5);
                        break;
                    case 3:
                        string searchName;

                        Console.Write("\nEnter product name: ");
                        searchName = Console.ReadLine().Trim();
                        while (string.IsNullOrEmpty(searchName))
                        {
                            Console.WriteLine("\n-- Product name cannot be empty --");
                            Console.Write("Enter product name: ");
                            searchName = Console.ReadLine().Trim();
                        }
                        
                        bool nameExists = false;
                        int itemIndex = 0;
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].name.ToLower() == searchName.ToLower())
                            {
                                nameExists = true;
                                itemIndex = i;
                                break;
                            }
                        }
                        
                        if (!nameExists)
                        {
                            Console.WriteLine("\n-- Product name does not exist. Please check if spelling is correct --");
                            break;
                        }
                        
                        Console.WriteLine("\nPRODUCT ID     PRODUCT NAME     PRICE (Php)     REMAINING STOCK    CATEGORY");
                        products[itemIndex].DisplayProduct();
                        break;
                    case 4:
                        string searchCategory;

                        Console.Write("\nEnter item category: ");
                        searchCategory = Console.ReadLine().Trim();
                        while (string.IsNullOrEmpty(searchCategory))
                        {
                            Console.WriteLine("\n-- Product name cannot be empty --");
                            Console.Write("Enter item category: ");
                            searchCategory = Console.ReadLine().Trim();
                        }
                        
                        bool categoryExists = false;
                        
                        Console.WriteLine("\nPRODUCT ID     PRODUCT NAME     PRICE (Php)     REMAINING STOCK    CATEGORY");
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].category.ToLower().Contains(searchCategory.ToLower()))
                            {
                                products[i].DisplayProduct();
                                categoryExists = true;
                            }
                        }
                        
                        if (!categoryExists)
                        {
                            Console.WriteLine("\n-- No products found under that category --");
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("\n-- Invalid input --");
                        break;
                }
            } while (menuChoice != 5);

            double grandTotal = 0;
            double itemTotal;
            
            for (int i = 0; i < cartProductIds.Length; i++)
            {
                if (cartProductIds[i] == 0)
                {
                    continue;
                }
            
                for (int j = 0; j < products.Length; j++)
                {
            
                    if (products[j].id == cartProductIds[i])
                    {
                        itemTotal = products[j].GetItemTotal(cartQuantities[i]);
                        grandTotal += itemTotal;
                        break;
                    }
                }
            }
            
            double discount = 0;
            double discounted = 0;
            double finalTotal;
            
            if (grandTotal >= 5000)
            {
                discount = 10;
                discounted = grandTotal * (discount / 100);
            }
            
            finalTotal = grandTotal - discounted;
            
            Console.WriteLine($"\nFinal Total: Php.{finalTotal:N2}");
            
            double payment;
            double change;
            
            while (true)
            {
                Console.Write("\nEnter payment amount: ");
                while (!double.TryParse(Console.ReadLine(), out payment))
                {
                    Console.WriteLine("\n-- Payment must be numeric --");
                    Console.Write("Enter payment amount: ");
                }
            
                if (payment < finalTotal)
                {
                    Console.WriteLine("\n-- Insufficient payment --");
                    continue;
                }
            
                change = payment - finalTotal;
                Console.WriteLine($"Change: Php.{change:N2}");
                break;
            }
            
            Console.WriteLine("\n****** UPDATED STOCK ******");
            Console.WriteLine("PRODUCT NAME     REMAINING STOCK");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"   {products[i].name, -10}         {products[i].remainingStock}");
            }

        }
    }

    class Product
    {
        public int id;
        public string name;
        public double price;
        public int remainingStock;
        public string category;

        public void DisplayProduct()
        {
            Console.WriteLine($"{id, 5}   :        {name, -10}       {price, -15:N2}    {remainingStock, -10}   {category}");
        }

        public double GetItemTotal(int quantity)
        {
            return price * quantity;
        }

        public bool HasEnoughStock(int quantity)
        {
            if (quantity > remainingStock)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public void DeductStock(int quantity)
        {
            remainingStock -= quantity;
        }
    }
}
