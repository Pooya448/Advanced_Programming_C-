using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            RecipeBook fromMom = new RecipeBook("دستور پخت های مادر", 20);
            
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine($"Press (N)ew, (D)el, (S)earch, (L)ist, sa(V)e or l(O)ad");
                cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.Key)
                {
                    case ConsoleKey.O:
                        LoadCase(fromMom);
                        break;
                    case ConsoleKey.V:
                        SaveCase(fromMom);
                        break;
                    case ConsoleKey.N:
                    
                        Console.WriteLine(SuccessMessage(fromMom.Add(NewRecipeGet()), true));
                        Clear();
                        break;
                    case ConsoleKey.D:
                        DeleteCase(fromMom);
                        break;
                    case ConsoleKey.S:
                        SearchInit();
                        ConsoleKeyInfo SearchMethod = Console.ReadKey();
                        Clear();
                        switch (SearchMethod.Key)
                        {
                            case ConsoleKey.K:
                                Clear();
                                KeywordSearchCase(fromMom);
                                break;

                            case ConsoleKey.T:
                                
                                Clear();
                                TitleSearchCase(fromMom);
                                break;
                            case ConsoleKey.C:
                                Clear();
                                CuisineSearchCase(fromMom);
                                break;
                            default:
                                Console.WriteLine($"Invalid Key: {cki.KeyChar}");
                                break;

                        }
                        break;
                    case ConsoleKey.L:
                        ListCase(fromMom);
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
        public static Recipe NewRecipeGet(bool IsTest = false)
        {
            Console.WriteLine("New Recipe");
            Pause();
            
            Console.WriteLine("Enter recipe Name :");
            string Aname = Console.ReadLine();
            
            Console.WriteLine("Write recipe instructions :");
            string instructions = Console.ReadLine();
            
            Console.WriteLine("Enter recipe Cuisine :");
            string cuisine = Console.ReadLine();
            
            Console.WriteLine("Enter Serving Count for your recipe :");
            int servingcount = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Please enter keywords in a row, Seperate using Space ");
            string keywordUnsplit = Console.ReadLine();
            string[] keywords = keywordUnsplit.Split(' ');
            if (!IsTest)
            {
                Console.WriteLine("Do you want to add the Ingredients now ?");
                ConsoleKeyInfo YN;
                Console.WriteLine("(Y)es");
                Console.WriteLine("(N)o");
                YN = Console.ReadKey();
                switch (YN.Key)
                {
                    case ConsoleKey.Y:
                        return new Recipe(Aname, instructions, CaseY(), servingcount, cuisine, keywords);
                    case ConsoleKey.N:

                        
                        return new Recipe(Aname, instructions, CaseN(), servingcount, cuisine, keywords);
                    default:
                        return null;
                }
            }
            else
            {
                int ingredientscount3 = int.Parse(Console.ReadLine());
                return new Recipe(Aname, instructions, ingredientscount3, servingcount, cuisine, keywords);
            }
           
            
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue !");
            Console.ReadLine();

        }
        public static string SuccessMessage(bool result, bool isAdd)
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

        public static void LoadCase(RecipeBook fromMom)
        {
            fromMom.Load(Recipe.RecipeFileAddress);
            Console.WriteLine("Seccessfully Loaded");
        }
        public static void SaveCase(RecipeBook fromMom)
        {
            fromMom.Save(Recipe.RecipeFileAddress);
            Console.WriteLine("Successfully Saved");
        }

        public static void DeleteCase(RecipeBook fromMom)
        {
            Console.WriteLine("Delete Recipe");
            Pause();
            Console.WriteLine("Please enter the name of your recipe");
            Console.WriteLine(SuccessMessage(fromMom.Remove(Console.ReadLine()), false));
        }

        public static void SearchInit()
        {
            Console.WriteLine("Search Recipe");
            Pause();
            Console.WriteLine();
            Console.WriteLine("How do you want to search for recipe ?");
            Console.WriteLine("Search by (T)itle");
            Console.WriteLine("Search by (K)eyword");
            Console.WriteLine("Search by (C)uisine");
        }
        public static void KeywordSearchCase(RecipeBook fromMom)
        {
            Console.WriteLine("Enter the Keyword :");
            List<Recipe> TempResult = fromMom.LookupByKeyword(Console.ReadLine());
            fromMom.ListRecipes(TempResult);
            Console.WriteLine("\nSelect recipe : ");
            fromMom.ShowRecipe(TempResult[int.Parse(Console.ReadLine()) - 1]);
        }
        public static void TitleSearchCase(RecipeBook fromMom)
        {
            Console.WriteLine("Enter the Title :");
            Recipe TempRecipe = fromMom.LookupByTitle(Console.ReadLine());
            Console.WriteLine($"1. {TempRecipe.Title}");
            Console.WriteLine("Press any key to show the recipe !");
            Console.Read();
            fromMom.ShowRecipe(TempRecipe);
        }
        public static void CuisineSearchCase(RecipeBook fromMom)
        {
            Console.WriteLine("Enter the Cuisine :");
            List<Recipe> TempResultC = fromMom.LookupByCuisine(Console.ReadLine());
            fromMom.ListRecipes(TempResultC);
            Console.WriteLine("\nSelect recipe : ");
            fromMom.ShowRecipe(TempResultC[int.Parse(Console.ReadLine()) - 1]);
        }
        public static void ListCase (RecipeBook fromMom)
        {
            Console.WriteLine("List Recipes");
            Pause();

            if (fromMom.ListOfRecipes.Count > 0)
            {
                fromMom.ListRecipes(fromMom.ListOfRecipes);
                Console.WriteLine("\nSelect recipe : ");
                int idx = int.Parse(Console.ReadLine()) - 1;
                fromMom.ShowRecipe(fromMom.ListOfRecipes[idx]);
            }
            else
                Console.WriteLine("No Recipes Added !!");
        }
        public static List<Ingredient> CaseY(bool IsTest = false)
        {
            Console.WriteLine("Please enter number of ingredients for this recipe :");
            int ingredientscount1 = int.Parse(Console.ReadLine());
            List<Ingredient> ingredients = new List<Ingredient>();
            if (!IsTest) ingredients = (Ingredient.InitialIngredient(ingredientscount1));
            return ingredients;
        }
        public static int CaseN ()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter number of ingredients for this recipe");
            int ingredientscount = int.Parse(Console.ReadLine());
            return ingredientscount;
        }

    }
}
