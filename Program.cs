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
                new Product {id = 110, name = "Onions", price = 80, remainingStock = 100}
            };

            for (int i = 0; i < products.Length; i++)
            {
                products[i].DisplayProduct();
            }

            int productNumber;
            int quantity;
            string choice = "Y";

            do
            {
                Console.Write("\nEnter product number: ");

                if (!int.TryParse(Console.ReadLine(), out productNumber))
                {
                    Console.WriteLine("\nInvalid product number");
                    continue;
                }

                Console.Write("Enter quantity: ");

                if (!int.TryParse(Console.ReadLine(),out quantity))
                {
                    Console.WriteLine("\nInvalid quantity");
                    continue;
                }

                Console.Write("\nAdd more items? (Y/N): ");
                choice = Console.ReadLine().ToUpper();

                while (choice != "Y" && choice != "N")
                {
                    Console.Write("Type only 'Y' (yes) or 'N' (no): ");
                    choice = Console.ReadLine().ToUpper();
                }

            } while (choice != "N");


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
            Console.WriteLine($"{id} : {name} = {price:F2} - {remainingStock}");
        }

        public double GetItemTotal(int quantity)
        {
            return price * quantity;
        }
    }
}
