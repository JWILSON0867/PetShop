using PetShop;
using PetStore.Data;
using System;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection; // Ensure you have this using statement

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call CreateServiceCollection to get the IServiceProvider
            var services = CreateServiceCollection();

            // Get the product logic service
            var productLogic = services.GetService<IProductLogic>();

            Console.WriteLine("Press 1 to add a product");
            Console.WriteLine("Press 2 to view a DogLeash by name");
            Console.WriteLine("Type 'exit' to quit");

            string input = Console.ReadLine();

            while (input != "exit")
            {
                switch (input)
                {
                    case "1":
                        AddProduct(productLogic);
                        break;
                    case "2":
                        ViewDogLeashByName(productLogic);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press 1 to add a product");
                Console.WriteLine("Press 2 to view a DogLeash by name");
                Console.WriteLine("Type 'exit' to quit");
                input = Console.ReadLine();
            }

            Console.WriteLine("Exiting the application...");
        }

        private static IServiceProvider CreateServiceCollection()
        {
            var services = new ServiceCollection();

            // Register services here
            services.AddTransient<IProductRepository, ProductRepository>(); // Register the repository
            services.AddTransient<IProductLogic, ProductLogic>(); // Register the logic class

            return services.BuildServiceProvider();
        }

        private static void AddProduct(IProductLogic productLogic)
        {
            Console.WriteLine("Enter the product details in JSON format:");

            string jsonInput = Console.ReadLine();

            try
            {
                DogLeash dogLeash = JsonSerializer.Deserialize<DogLeash>(jsonInput);
                if (dogLeash != null)
                {
                    DogLeashValidator validator = new DogLeashValidator();
                    var validationResult = validator.Validate(dogLeash);

                    if (validationResult.IsValid)
                    {
                        productLogic.AddProduct(dogLeash);
                        Console.WriteLine("DogLeash added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid DogLeash data:");
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine($"- {error.ErrorMessage}");
                        }
                    }
                    return;
                }
            }
            catch (JsonException) { }

            try
            {
                CatFood catFood = JsonSerializer.Deserialize<CatFood>(jsonInput);
                if (catFood != null)
                {
                    CatFoodValidator validator = new CatFoodValidator();
                    var validationResult = validator.Validate(catFood);

                    if (validationResult.IsValid)
                    {
                        productLogic.AddProduct(catFood);
                        Console.WriteLine("CatFood added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid CatFood data:");
                        foreach (var error in validationResult.Errors)
                        {
                            Console.WriteLine($"- {error.ErrorMessage}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid CatFood data.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to parse JSON: {ex.Message}");
            }
        }

        private static void ViewDogLeashByName(IProductLogic productLogic)
        {
            Console.WriteLine("Enter the name of the DogLeash to view:");
            string name = Console.ReadLine();

            DogLeash dogLeash = productLogic.GetDogLeashByName(name);
            if (dogLeash != null)
            {
                Console.WriteLine(JsonSerializer.Serialize(dogLeash));
            }
            else
            {
                Console.WriteLine("DogLeash not found.");
            }
        }
    }
}
