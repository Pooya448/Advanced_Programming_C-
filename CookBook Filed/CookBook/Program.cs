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
        public static Recipe NewRecipeGet (RecipeBook fromMom)
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
                    Recipe Temp1 = new Recipe(Aname, instructions, ingredients, servingcount, cuisine, keywords);
                    return Temp1;
                    break;
                case ConsoleKey.N:
                    Clear();
                    Console.WriteLine();
                    Console.WriteLine("Please enter number of ingredients for this recipe");
                    int ingredientscount2 = int.Parse(Console.ReadLine());
                    Recipe Temp2 = new Recipe(Aname, instructions, ingredientscount2, servingcount, cuisine, keywords);
                    return Temp2;
                    break;
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
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the title of your CookBOOK :");
            string CookBookTitle = Console.ReadLine();
            Console.WriteLine("Enter the capacity of your CookBOOK :");
            int CookBookCap = int.Parse(Console.ReadLine());
            RecipeBook CookBook = new RecipeBook(CookBookTitle, CookBookCap);
            Console.WriteLine("Your CookBOOK successfully created :-)");
            Pause();
            Clear();
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.O:
                        CookBook.Load(Recipe.RecipeFileAddress);
                        Console.WriteLine("Seccessfully Loaded");
                        break;
                    case ConsoleKey.V:
                        CookBook.Save(Recipe.RecipeFileAddress);
                        Console.WriteLine("Successfully Saved");
                        break;
                    case ConsoleKey.N:
                        switch (CookBook.Add(NewRecipeGet(CookBook)))
                        {
                            case true:
                                Clear();
                                Console.WriteLine("Recipe successfully added !");
                                break;
                            case false:
                                Clear();
                                Console.WriteLine("Failed to add your Recipe !!");
                                break;

                        }
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("Delete Recipe");
                        Pause();
                        Clear();
                        Console.WriteLine("Please enter the name of your recipe");
                        switch (CookBook.Remove(Console.ReadLine()))
                        {
                            case true:
                                Clear();
                                Console.WriteLine("Recipe successfully removed !");
                                break;
                            case false:
                                Clear();
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
                                Recipe[] TempResult = CookBook.LookupByKeyword(Console.ReadLine());
                                CookBook.ListRecipes(TempResult);
                                Console.WriteLine("\nSelect recipe : ");

                                CookBook.ShowRecipe(CookBook.SelectRecipe(TempResult, int.Parse(Console.ReadLine())));

                                break;
                            
                            case ConsoleKey.T:
                                Clear();
                                Console.WriteLine("Enter the Title :");
                                Recipe TempRecipe = CookBook.LookupByTitle(Console.ReadLine());
                                Console.WriteLine($"1. {TempRecipe.Title}");
                                Console.WriteLine("Press any key to show the recipe !");
                                Console.ReadKey();
                                CookBook.ShowRecipe(TempRecipe);
                                break;
                            case ConsoleKey.C:
                                Clear();
                                Console.WriteLine("Enter the Cuisine :");
                                Recipe[] TempResultC = CookBook.LookupByCuisine(Console.ReadLine());
                                CookBook.ListRecipes(TempResultC);
                                Console.WriteLine("\nSelect recipe : ");
                                CookBook.ShowRecipe(CookBook.SelectRecipe(TempResultC, int.Parse(Console.ReadLine())));
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
                        if (CookBook.NumberOfRecipes != 0)
                        {
                            CookBook.ListRecipes(CookBook.ListOfRecipes.ToArray());
                            Console.WriteLine("\nSelect recipe : ");
                            CookBook.ShowRecipe(CookBook.SelectRecipe(CookBook.ListOfRecipes.ToArray(), int.Parse(Console.ReadLine())));
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


    }
}
