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
                        Console.WriteLine(SuccessMessage(fromMom.Add(NewRecipeGet(fromMom)),true));
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        Pause();
                        Clear();
                        Console.WriteLine("Please enter the name of your recipe");
                        Console.WriteLine(SuccessMessage(fromMom.Remove(Console.ReadLine()), false));
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine("Search Recipe");
                        Pause();
                        Clear();
                        Console.WriteLine("How do you want to search for recipe ?");
                        Console.WriteLine("Search by (T)itle");
                        Console.WriteLine("Search by (K)eyword");
                        Console.WriteLine("Search by (C)uisine");
                        ConsoleKeyInfo SearchMethod = Console.ReadKey();
                        Clear();
                        switch (SearchMethod.Key)
                        {
                            case ConsoleKey.K:
                                Clear();
                                Console.WriteLine("Enter the Keyword :");
                                Recipe[] TempResult = fromMom.LookupByKeyword(Console.ReadLine());
                                fromMom.ListRecipes(TempResult);
                                Console.WriteLine("\nSelect recipe : ");
                                fromMom.ShowRecipe(TempResult[int.Parse(Console.ReadLine()) - 1]);
                                break;                            
                            case ConsoleKey.T:
                                Clear();
                                Console.WriteLine("Enter the Title :");
                                Recipe TempRecipe = fromMom.LookupByTitle(Console.ReadLine());
                                Console.WriteLine($"1. {TempRecipe.Title}");
                                Console.WriteLine("Press any key to show the recipe !");
                                Console.ReadKey();
                                fromMom.ShowRecipe(TempRecipe);
                                break;
                            case ConsoleKey.C:
                                Clear();
                                Console.WriteLine("Enter the Cuisine :");
                                Recipe[] TempResultC = fromMom.LookupByCuisine(Console.ReadLine());
                                fromMom.ListRecipes(TempResultC);
                                Console.WriteLine("\nSelect recipe : ");
                                fromMom.ShowRecipe(TempResultC[int.Parse(Console.ReadLine()) - 1]);
                                break;
                            default:
                                Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                break;
                        }
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("List Recipes");
                        Pause();
                        Clear();
                        if (fromMom.ListOfRecipes.Count == 0)
                        {
                            fromMom.ListRecipes(fromMom.ListOfRecipes.ToArray());
                            Console.WriteLine("\nSelect recipe : ");
                            fromMom.ShowRecipe(fromMom.ListOfRecipes[int.Parse(Console.ReadLine())-1]);
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
                Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }
        public static Recipe NewRecipeGet(RecipeBook fromMom)
        {
            Console.WriteLine("New Recipe");
            Pause();
            Clear();
            Console.WriteLine("Enter recipe Name :");
            string Aname = Console.ReadLine();
            Clear();
            Console.WriteLine("Write recipe instructions :");
            string instructions = Console.ReadLine();
            Clear();
            Console.WriteLine("Enter recipe Cuisine :");
            string cuisine = Console.ReadLine();
            Clear();
            Console.WriteLine("Enter Serving Count for your recipe :");
            int servingcount = int.Parse(Console.ReadLine());
            Clear();
            Console.WriteLine("Please enter keywords in a row, Seperate using Space ");
            string keywordUnsplit = Console.ReadLine();
            string[] keywords = keywordUnsplit.Split(' ');
            Clear();
            Console.WriteLine("Do you want to add the Ingredients now ?");
            ConsoleKeyInfo YN;
            Console.WriteLine("(Y)es");
            Console.WriteLine("(N)o");
            YN = Console.ReadKey();
            switch (YN.Key)
            {
                case ConsoleKey.Y:
                    Clear();
                    Console.WriteLine("Please enter number of ingredients for this recipe :");
                    int ingredientscount1 = int.Parse(Console.ReadLine());
                    Ingredient[] ingredients = new Ingredient[ingredientscount1];
                    Recipe.InitialIngredient(ingredientscount1).CopyTo(ingredients, 0);
                    return new Recipe(Aname, instructions, ingredients, servingcount, cuisine, keywords);
                case ConsoleKey.N:
                    Clear();
                    Console.WriteLine();
                    Console.WriteLine("Please enter number of ingredients for this recipe");
                    int ingredientscount2 = int.Parse(Console.ReadLine());
                    return new Recipe(Aname, instructions, ingredientscount2, servingcount, cuisine, keywords);
                default:
                    return null;
            }
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue !");
            Console.ReadKey();
        }
        public static string SuccessMessage (bool result, bool isAdd)
        {
            if (isAdd)
            {
                if (result)
                    return "Recipe successfully added !";
                else
                    return "Failed to add your Recipe !!";
            }
            else
            {
                if (result)
                    return "Recipe successfully removed !";
                else
                    return "Failed to remove your Recipe !";
            }
        }

    }
}
