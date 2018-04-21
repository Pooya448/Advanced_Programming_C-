using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// کتابچه دستور غذا
    /// </summary>
    public class RecipeBook{

        /// <summary>
        /// the list for holding recipes of a recipebook
        /// </summary>
        public List<Recipe> ListOfRecipes = new List<Recipe>();
        /// <summary>
        /// property of capacity of the recipebook
        /// </summary>
        public int Capacity { set; get; }
        /// <summary>
        /// property of recipebook title
        /// </summary>
        public string BookTitle { set; get; }

        /// <summary>
        /// ایجاد شیء کتابچه دستور غذا
        /// </summary>
        /// <param name="title">عنوان کتابچه غذا</param>
        /// <param name="capacity">ظرفیت کتابچه</param>
        public RecipeBook(string title, int capacity)
        {
            Capacity = capacity;
            BookTitle = title;
        }

        /// <summary>
        /// اضافه کردن یک دستور پخت جدید
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns>آیا اضافه کردن موفقیت آمیز انجام شد؟</returns>
        public bool Add (Recipe recipe)
        {
            ListOfRecipes.Add(recipe);
            if (ListOfRecipes[ListOfRecipes.IndexOf(recipe)]==recipe)
                return true;
            return false;
            
        }

        /// <summary>
        /// حذف دستور پخت
        /// </summary>
        /// <param name="recipeTitle">عنوان دستور پخت</param>
        /// <returns>آیا حذف دستور پخت درست انجام شد؟</returns>
        public bool Remove(string recipeTitle)
        {
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Title == recipeTitle)
                {
                    ListOfRecipes.RemoveAt(i);
                    return true;
                }
                    
                
            }
            return false;
                
        }

        /// <summary>
        /// پیدا کردن دستور پخت با عنوان
        /// </summary>
        /// <param name="title">عنوان دستور پخت</param>
        /// <returns>شیء دستور پخت</returns>
        public Recipe LookupByTitle(string title)
        {
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Title == title)
                    return ListOfRecipes[i];
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public Recipe[] LookupByKeyword(string keyword)
        {
            List<Recipe> foundRecipe = new List<Recipe>();
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                for (int j = 0; j < ListOfRecipes[i].KeyWords.Length; j++)
                {
                    if (ListOfRecipes[i].KeyWords[j] == keyword)
                    {
                        foundRecipe.Add(ListOfRecipes[i]);
                        break;
                    }
                }
            }
            return foundRecipe.ToArray();
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            List<Recipe> recipeFound = new List<Recipe>();
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Cuisine == cuisine)
                {
                    recipeFound.Add(ListOfRecipes[i]);
                    break;
                }
            }
            return recipeFound.ToArray();
        }
        
        public void ShowRecipe (Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine(recipe.ToString());

            for(int i = 0; i < recipe.IngredientsList.Count; i++)
            {
                if (recipe.IngredientsList.Count == 0)
                {
                    Console.WriteLine("No Ingredients Added !");
                }
                Console.WriteLine(recipe.IngredientsList[i].ToString());
            }
            
        }
        public void ListRecipes (Recipe[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Title}");
            }
        }
        
       
    }
}
