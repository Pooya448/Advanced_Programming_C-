using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue !");
            Console.ReadKey();
        }
        public static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);

            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press N(ew), D(el), S(earch) or L(ist)");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.N:
                        Console.WriteLine("New Recipe");
                        Pause();
                        Console.Clear();
                        Console.WriteLine("Enter recipe Name :");
                        string Aname = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Write recipe instructions :");
                        string instructions = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter recipe Cuisine :");
                        string cuisine = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Enter Serving Count for your recipe :");
                        int servingcount = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Please enter keywords in a row, Seperate using Space ");
                        string keywordUnsplit = Console.ReadLine();
                        string[] keywords = keywordUnsplit.Split(' ');
                        Console.Clear();
                        Console.WriteLine("Do you want to add the Ingredients now ?");
                        ConsoleKeyInfo YN;
                        Console.WriteLine("(Y)es");
                        Console.WriteLine("(N)o");
                        YN = Console.ReadKey();
                        switch (YN.Key)
                        {
                            case ConsoleKey.Y:
                                Console.Clear();
                                Console.WriteLine("Please enter number of ingredients for this recipe :");
                                int ingredientscount1 = int.Parse(Console.ReadLine());
                                Ingredient[] ingredients = new Ingredient[ingredientscount1];
                                Recipe.InitialIngredient(ingredientscount1).CopyTo(ingredients,0);
                                switch(fromMom.Add(new Recipe(Aname, instructions, ingredients, servingcount, cuisine, keywords)))
                                {
                                    case true:
                                        Console.Clear();
                                        Console.WriteLine("Recipe successfully added !");
                                        break;
                                    case false:
                                        Console.Clear();
                                        Console.WriteLine("Failed to add your Recipe !!");
                                        break;
                                    default:
                                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                        break;

                                }
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Please enter number of ingredients for this recipe");
                                int ingredientscount2 = int.Parse(Console.ReadLine());
                                switch (fromMom.Add(new Recipe(Aname, instructions, ingredientscount2, servingcount, cuisine, keywords)))
                                {
                                    case true:
                                        Console.Clear();
                                        Console.WriteLine("Recipe successfully added !");
                                        break;
                                    case false:
                                        Console.Clear();
                                        Console.WriteLine("Failed to add your Recipe !!");
                                        break;
                                    default:
                                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                        break;

                                }
                                break;
                        }
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        Pause();
                        Console.Clear();
                        Console.WriteLine("Please enter the name of your recipe");
                        string Rname = Console.ReadLine();
                        switch (fromMom.Remove(Rname))
                        {
                            case true:
                                Console.Clear();
                                Console.WriteLine("Recipe successfully removed !");
                                break;
                            case false:
                                Console.Clear();
                                Console.WriteLine("Failed to remove your recipe of choice :( ");
                                break;
                            default:
                                Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                break;
                        }

                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        Pause();
                        Console.Clear();
                        Console.WriteLine("How do you want to search for recipe ?");
                        Console.WriteLine("Search by (T)itle");
                        Console.WriteLine("Search by (K)eyword");
                        Console.WriteLine("Search by (C)uisine");
                        ConsoleKeyInfo SearchMethod = Console.ReadKey();
                        Console.Clear();
                        switch (SearchMethod.Key)
                        {
                            case ConsoleKey.K:
                                Console.Clear();
                                Console.WriteLine("Enter the Keyword :");
                                Recipe[] TempResult = fromMom.LookupByKeyword(Console.ReadLine());
                                fromMom.ListRecipes(TempResult);
                                Console.WriteLine("\nSelect recipe : ");

                                fromMom.ShowRecipe(fromMom.SelectRecipe(TempResult, int.Parse(Console.ReadLine())));

                                break;
                            
                            case ConsoleKey.T:
                                Console.Clear();
                                Console.WriteLine("Enter the Title :");
                                Recipe TempRecipe = fromMom.LookupByTitle(Console.ReadLine());
                                Console.WriteLine($"1. {TempRecipe.Title}");
                                Console.WriteLine("Press any key to show the recipe !");
                                Console.ReadKey();
                                fromMom.ShowRecipe(TempRecipe);
                                break;
                            case ConsoleKey.C:
                                Console.Clear();
                                Console.WriteLine("Enter the Cuisine :");
                                Recipe[] TempResultC = fromMom.LookupByCuisine(Console.ReadLine());
                                fromMom.ListRecipes(TempResultC);
                                Console.WriteLine("\nSelect recipe : ");
                                fromMom.ShowRecipe(fromMom.SelectRecipe(TempResultC, int.Parse(Console.ReadLine())));
                                break;
                            default:
                                Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                break;

                        }
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        Pause();
                        Console.Clear();
                        if(fromMom.NumberOfRecipes != 0)
                        {
                            fromMom.ListRecipes(fromMom.ListOfRecipes.ToArray());
                            Console.WriteLine("\nSelect recipe : ");
                            fromMom.ShowRecipe(fromMom.SelectRecipe(fromMom.ListOfRecipes.ToArray(), int.Parse(Console.ReadLine())));
                        }
                            
                        else
                            Console.WriteLine("No Recipes Added !!");
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Esc");
                        break;
                    default:
                        Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                        break;
                }

                Console.WriteLine("Press any key to continue, Esc to exit");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }


    }
}
