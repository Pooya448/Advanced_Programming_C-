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
    public class RecipeBook
    {
        private int _NumberOfRecipes = 0;
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
            this.ListOfRecipes.Add(recipe);
            if (ListOfRecipes.Contains(recipe))
            {
                this._NumberOfRecipes++;
                return true;
            }
                
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
                    this._NumberOfRecipes--;
                }
                    
                return true;
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
            int Indicator = 0;
            int Counter = 0;
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                for (int j = 0; j < ListOfRecipes[i].KeyWords.Length; j++)
                {
                    if (ListOfRecipes[i].KeyWords[j] == keyword)
                    {
                        Counter++;
                    }
                }
            }
            Recipe[] KeyWordResult = new Recipe[Counter];
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                for(int j = 0; j< ListOfRecipes[i].KeyWords.Length; j++)
                {
                    if (ListOfRecipes[i].KeyWords[j] == keyword)
                    {
                        KeyWordResult[Indicator] = ListOfRecipes[i];
                        Indicator++;
                    }    
                }                   
            }
            return KeyWordResult;
        }

        /// <summary>
        /// پیدا کردن دستور پخت غذا با سبک پخت
        /// </summary>
        /// <param name="cuisine">سبک پخت</param>
        /// <returns>لیست دستور غذاهای سبک پخت داده شده</returns>
        public Recipe[] LookupByCuisine(string cuisine)
        {
            int Indicator = 0;
            int Counter = 0;
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Cuisine == cuisine)
                {
                    Counter++;
                }
            }
            Recipe[] CuisineResult = new Recipe[Counter];
            for (int i = 0; i < ListOfRecipes.Count; i++)
            {
                if (ListOfRecipes[i].Cuisine == cuisine)
                {
                    CuisineResult[Indicator] = ListOfRecipes[i];
                    Indicator++;
                }
            }
            return CuisineResult;
        }
        public Recipe SelectRecipe (Recipe[] list, int index)
        {
            return list[index-1];
        }
        public void ShowRecipe (Recipe recipe)
        {
            Console.Clear();
            Console.WriteLine(recipe.ToString());

            for(int i = 0; i < recipe.IngredientCount; i++)
            {
                if (!recipe.IsIngredientsAdded)
                {
                    Console.WriteLine("No Ingredients Added !");
                }
                Console.WriteLine(recipe.RecipeIngredients[i].ToString());
            }
            
        }
        public void ListRecipes (Recipe[] list)
        {
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Title}");
            }
        }
        static int Capacity;
        static string BookTitle;
        public List <Recipe> ListOfRecipes = new List <Recipe> ();
        public int NumberOfRecipes
        {
            get
            {
                return this._NumberOfRecipes;
            }
            set
            {
                this._NumberOfRecipes = value;
            }
        }
        
       
    }
}
