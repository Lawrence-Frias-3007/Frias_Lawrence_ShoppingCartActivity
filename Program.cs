using System;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] products = new Product[]
            {
                new Product {id = 101, name = "Eggs", price = 230, remainingStock = 200},
                new Product {id = 102, name = "Bread", price = 75, remainingStock = 100},
                new Product {id = 103, name = "Milk", price = 150, remainingStock = 100},
                new Product {id = 104, name = "Chicken", price = 250, remainingStock = 200},
                new Product {id = 105, name = "Pork", price = 330, remainingStock = 200},
                new Product {id = 106, name = "Beef", price = 450, remainingStock = 200},
                new Product {id = 107, name = "Sardines", price = 40, remainingStock = 250},
                new Product {id = 108, name = "Carrots", price = 80, remainingStock = 100},
                new Product {id = 109, name = "Garlic", price = 100, remainingStock = 100},
                new Product {id = 110, name = "Onions", price = 80, remainingStock = 100},
                new Product {id = 111, name = "Potato", price = 85, remainingStock = 100},
                new Product {id = 112, name = "Tomato", price = 70, remainingStock = 100}
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

                if (!int.TryParse(Console.ReadLine(),out quantity))
                {
                    Console.WriteLine("\n-- Invalid quantity --");
                    continue;
                }

                if (quantity <= 0)
                {
                    Console.WriteLine("\n-- Invalid quantity --");
                    continue;
                }

                if (quantity > products[productIndex].remainingStock)
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

                        products[productIndex].remainingStock -= quantity;
                        
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

                            products[productIndex].remainingStock -= quantity;

                            Console.WriteLine("\n-- Item added to cart --");
                            break;
                        }
                    }

                    if (!added)
                    {
                        Console.WriteLine("\n-- Cart is full (You can still add quantity to existing items) --");
                    }
                }

                Console.WriteLine("\n** CART **");

                for (int i = 0; i < cartProductIds.Length; i++)
                {
                    if (cartProductIds[i] == 0)
                    {
                        break;
                    }

                    for (int j = 0; j < products.Length; j++)
                    {
                        if (products[j].id == cartProductIds[i])
                        {
                            Console.WriteLine($"{products[j].name} x{cartQuantities[i]}");
                            break;
                        }
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

            Console.WriteLine("\n****************** RECEIPT ******************");

            double grandTotal = 0;
            double itemTotal;

            Console.WriteLine("PRODUCT NAME    PRICE      QUANTITY     ITEM TOTAL");
            for (int i = 0; i < cartProductIds.Length; i++)
            {
                if (cartProductIds[i] == 0)
                {
                    break;
                }
                
                for (int j = 0; j < products.Length; j++)
                {
                    
                    if (products[j].id == cartProductIds[i])
                    {
                        itemTotal = products[j].GetItemTotal(cartQuantities[i]);

                        Console.WriteLine($"{products[j].name, -8}    :   {products[j].price, -8:N2}x     {cartQuantities[i], -5}  =    {itemTotal:N2}");

                        grandTotal += itemTotal;
                        break;
                    }
                }
            }

            Console.WriteLine($"\nGrand Total = Php.{grandTotal:N2}");

            double discount = 0;
            double discounted = 0;
            double finalTotal;

            if (grandTotal >= 5000)
            {
                discount = 10;
                discounted = grandTotal * (discount / 100);
            }

            Console.WriteLine($"\nDiscount ({discount}%) = Php.{discounted:N2}");
            finalTotal = grandTotal - discounted;

            Console.WriteLine($"\nFinal Total = Php.{finalTotal:N2}");

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

        public void DisplayProduct()
        {
            Console.WriteLine($"{id, 5}   :        {name, -10}       {price, -15:N2}    {remainingStock}");
        }

        public double GetItemTotal(int quantity)
        {
            return price * quantity;
        }
    }
}
