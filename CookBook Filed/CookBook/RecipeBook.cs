using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public bool Add(Recipe recipe)
        {
            ListOfRecipes.Add(recipe);
           return true;
            

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
                {
                    ListOfRecipes[i].SearchMethod = " : By Title";
                    return ListOfRecipes[i];
                }
                
            }
            return null;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با کلمه کلیدی
        /// </summary>
        /// <param name="keyword">کلمه کلیدی</param>
        /// <returns>دستور غذاهای دارای کلمه کلیدی</returns>
        public List<Recipe> LookupByKeyword(string keyword)
        {
            List<Recipe> foundRecipe = new List<Recipe>();
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                for (int j = 0; j < ListOfRecipes[i].KeyWords.Length; j++)
                {
                    if (ListOfRecipes[i].KeyWords[j] == keyword)
                    {
                        ListOfRecipes[i].SearchMethod = " : By Keywords";
                        foundRecipe.Add(ListOfRecipes[i]);
                        break;
                    }
                }
            }
            if (foundRecipe.Count == 0)
                return null;
            else
                return foundRecipe;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public List<Recipe> LookupByCuisine(string cuisine)
        {
            List<Recipe> recipeFound = new List<Recipe>();
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Cuisine == cuisine)
                {
                    ListOfRecipes[i].SearchMethod = " : By Cuisine";
                    recipeFound.Add(ListOfRecipes[i]);
                    break;
                }
            }
            if (recipeFound.Count == 0)
                return null;
            else
                return recipeFound;
        }
        public bool ShowRecipe (Recipe recipe)
        {
            Console.WriteLine();
            Console.WriteLine(recipe.ToString());
            if (recipe.IngredientsList.Count > 0)
            {
                for (int i = 0; i < recipe.IngredientsList.Count; i++)
                {
                    Console.WriteLine(recipe.IngredientsList[i].ToString());
                }
                return true;
            }

            return false;

        }
        public bool ListRecipes (List<Recipe> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Title}");
            }
            return true;
        }
        
        
        public void Save (string Path)
        {
            using (StreamWriter Writer = new StreamWriter(Path, false, Encoding.UTF8))
            {
                foreach (Recipe sample in ListOfRecipes)
                {
                    if (sample != null)
                        sample.Serialize(Writer);
                }
            }
        }
        public bool Load (string Path)
        {
            if (File.Exists(Path))
            {
                Recipe Temp;
                using (StreamReader Reader = new StreamReader(Path))
                    while ((Temp = Recipe.Deserialize(Reader)) != null)
                    {
                        Add(Temp);
                    }
                return true;
            }
            else
                return false;
        }
       
    }
}
