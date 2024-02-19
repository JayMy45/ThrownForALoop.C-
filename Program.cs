List<Product> products = new List<Product>()
{
 new Product()
 {
     Name = "Football",
     Price = 15.00M,
     Sold = false,
     StockDate = new DateTime(2021, 1, 1),
     ManufactureYear = 2020,
     Condition = 4.2

 },
 new Product ()
 {
    Name = "Hockey Stick",
    Price = 12.00M,
    Sold = false,
    StockDate = new DateTime(2024, 1, 21),
        ManufactureYear = 2023,
        Condition = 2.5

 },
 new Product ()
 {
    Name = "Soccer Ball",
    Price = 10.00M,
    Sold = false,
    StockDate = new DateTime(2021, 6, 1),
    ManufactureYear = 2019,
    Condition = 4.9

 },
 new Product ()
 {
    Name = "Tennis Racket",
    Price = 20.00M,
    Sold = false,
    StockDate = new DateTime(2021, 6, 1),
    ManufactureYear = 2021,
    Condition = 5.0

 },
 new Product ()
 {
    Name = "Baseball Glove",
    Price = 25.00M,
    Sold = false,
    StockDate = new DateTime(2023, 1, 1),
    ManufactureYear = 2022,
    Condition = 4.0

 },
 new Product ()
 {
    Name = "Basketball",
    Price = 30.00M,
    Sold = false,
    StockDate = new DateTime(2024, 1, 1),
    ManufactureYear = 2020,
    Condition = 4.2

 },
 new Product ()
 {
    Name = "Golf Club",
    Price = 40.00M,
    Sold = false,
    StockDate = new DateTime(2021, 1, 1),
    ManufactureYear = 2020,
    Condition = 4.1

 },
 new Product ()
 {
    Name = "Ping Pong Paddle",
    Price = 5.00M,
    Sold = true,
    StockDate = new DateTime(2021, 1, 1),
    ManufactureYear = 2020,
    Condition = 4.2

 }
};


string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment
I just remembered I hate sports!!!";

Console.WriteLine(greeting);

string? choice = null;
while (choice != "0")
{
   Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products
                        ");
   choice = Console.ReadLine();
   if (choice == "0")
   {
      Console.WriteLine("Goodbye!");
   }
   else if (choice == "1")
   {
      ListProducts();
   }
   else if (choice == "2")
   {
      ViewProductDetails();
   }
   else if (choice == "3")
   {
      ViewLatestProducts();
   }
}

//! create a method to view the product details
void ViewProductDetails()
{
   ListProducts();

   Product chosenProduct = null;

   while (chosenProduct == null)
   {
      Console.WriteLine("Please enter a product number: ");
      try
      {
         int response = int.Parse(Console.ReadLine().Trim());
         chosenProduct = products[response - 1];
      }
      catch (FormatException)
      {
         Console.WriteLine("Do Better pimpin");
      }
      catch (ArgumentOutOfRangeException)
      {
         Console.WriteLine("Invalid input, please enter a number between 1 and 4: ");
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
   }

   /*
   Console.WriteLine("Please enter a product number: ");

   int response = int.Parse(Console.ReadLine().Trim());

   while (response > products.Count || response < 1)
   {
      Console.WriteLine("Invalid input, please enter a number between 1 and 4: ");

   }

   Product chosenProduct = products[response - 1];
   */

   // get the current date and time
   DateTime now = DateTime.Now;

   // calculate the time the product has been in stock
   TimeSpan timeInStock = now - chosenProduct.StockDate;

   Console.WriteLine(@$"You chose: {chosenProduct.Name}, which costs {chosenProduct.Price} dollars. 
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
   decimal totalValue = 0.0M;
   foreach (Product product in products)
   {
      if (!product.Sold)
      {
         totalValue += product.Price;
      }
   }
   Console.WriteLine($"The total value: {totalValue} dollars.\n");

   Console.WriteLine("Products:");
   for (int i = 0; i < products.Count; i++)
   {
      Console.WriteLine($"{i + 1}. {products[i].Name}");
   }
}

void ViewLatestProducts()
{
   // create a new empty List to store the latest products
   List<Product> latestProducts = new List<Product>();
   // Calculate a DateTime 90 days in the past
   DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
   //loop through the products
   foreach (Product product in products)
   {
      //Add a product to latestProducts if it fits the criteria
      if (product.StockDate > threeMonthsAgo && !product.Sold)
      {
         latestProducts.Add(product);
      }
   }
   // print out the latest products to the console 
   for (int i = 0; i < latestProducts.Count; i++)
   {
      Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
   }
   string? choice = null;
   while (choice != "0")
   {
      Console.WriteLine(@"Choose an option:
                        0. Main Menu
                        1. View Product Details
                        ");
      choice = Console.ReadLine();
      if (choice == "0")
      {
         Console.WriteLine("Main Menu");
      }
      else if (choice == "1")
      {
         ViewLatestProductDetails(latestProducts);
      }
   }

}

//original ViewLatestProductDetails method from lesson.
/*
void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}

*/


// create a method to view the product details modified
/*  void ViewLatestProductDetails(List<Product> latestProducts)
  {
     Product NewProducts = null;
     while (NewProducts == null)

     {
        {
           for (int i = 0; i < latestProducts.Count; i++)
           {
              if (latestProducts[i] != null)
              {
                 Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
              }
              else
              {
                 Console.WriteLine($"{i + 1}. [Product is null]");
              }
           }

           Console.WriteLine("Please enter a product number: ");
           try
           {
              int response = int.Parse(Console.ReadLine().Trim());
              NewProducts = latestProducts[response - 1];
           }
           catch (FormatException)
           {
              Console.WriteLine("Do Better pimpin");
           }
           catch (ArgumentOutOfRangeException)
           {
              Console.WriteLine("Invalid input, please enter a number between 1 and 4: ");
           }
           catch (Exception ex)
           {
              Console.WriteLine(ex.Message);
           }
        }
        DateTime now = DateTime.Now;

        // calculate the time the product has been in stock
        TimeSpan timeInStock = now - NewProducts.StockDate;

        Console.WriteLine(@$"You chose: {NewProducts.Name}, which costs {NewProducts.Price} dollars. 
It is {now.Year - NewProducts.ManufactureYear} years old. 
It {(NewProducts.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}");
     }
  }
}
*/

//updated ViewLatestProductDetails method to prevent ArgumentOutOfRangeException
void ViewLatestProductDetails(List<Product> latestProducts)
{
   Product NewProducts = null;

   // Ensure latestProducts is not null and has elements before proceeding
   if (latestProducts == null || latestProducts.Count == 0)
   {
      Console.WriteLine("No products available.");
      return; // Exit the method early if no products are available
   }

   while (NewProducts == null)
   {
      // Display available products
      for (int i = 0; i < latestProducts.Count; i++)
      {
         Console.WriteLine($"{i + 1}. {latestProducts[i]?.Name ?? "[Product is null]"}");
      }

      Console.WriteLine("Please enter a product number: ");
      try
      {
         int response = int.Parse(Console.ReadLine().Trim());

         // Adjusted to prevent ArgumentOutOfRangeException
         if (response > 0 && response <= latestProducts.Count)
         {
            NewProducts = latestProducts[response - 1];
         }
         else
         {
            throw new ArgumentOutOfRangeException();
         }
      }
      catch (FormatException)
      {
         Console.WriteLine("Do Better pimpin");
      }
      catch (ArgumentOutOfRangeException)
      {
         Console.WriteLine($"Invalid input, please enter a number between 1 and {latestProducts.Count}: ");
      }
      catch (Exception ex)
      {
         Console.WriteLine(ex.Message);
      }
   }

   // Ensure NewProducts is not null before accessing its properties
   if (NewProducts != null)
   {
      DateTime now = DateTime.Now;

      // Calculate the time the product has been in stock
      TimeSpan timeInStock = now - NewProducts.StockDate;

      Console.WriteLine(@$"You chose: {NewProducts.Name}, which costs {NewProducts.Price} dollars. 
It is {now.Year - NewProducts.ManufactureYear} years old. 
It {(NewProducts.Sold ? "is not available" : $"has been in stock for {timeInStock.Days} days.")}");
   }
}
