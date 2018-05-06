using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// the list for holding ingredient items
        /// </summary>
        public List<Ingredient> IngredientsList = new List <Ingredient>();
        /// <summary>
        /// array for holding keywords of a recipe
        /// </summary>
        public string[] KeyWords;
        /// <summary>
        /// property of title of the recipe
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// property of cuisine of the recipe
        /// </summary>
        public string Cuisine { set; get; }
        /// <summary>
        /// property of serving count for the recipe
        /// </summary>
        public int ServingCount { set; get; }
        /// <summary>
        /// property of instructions for the recipe
        /// </summary>
        public string Instructions { get; set; }
        /// <summary>
        /// property of ingredient count for this recipe
        /// </summary>
        public int IngredientCount { get; set; }


        /// <summary>
        /// ایجاد دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredients">لیست مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, List<Ingredient> ingredient, int servingCount, string cuisine, string[] keywords)
        {
            Title = title;
            Cuisine = cuisine;
            ServingCount = servingCount;
            Instructions = instructions;
            KeyWords = new string[keywords.Length];
            keywords.CopyTo(KeyWords, 0);
            IngredientsList = new List<Ingredient>();
            IngredientsList.AddRange(ingredient);
            IngredientCount = ingredient.Count;
        }

        /// <summary>
        /// ایجاد شئ دستور پخت جدید
        /// </summary>
        /// <param name="title">عنوان</param>
        /// <param name="instructions">دستورات</param>
        /// <param name="ingredientCount">تعداد مواد مورد نیاز</param>
        /// <param name="servingCount">تعداد افراد</param>
        /// <param name="cuisine">سبک غذا</param>
        /// <param name="keywords">کلمات کلیدی</param>
        public Recipe(string title, string instructions, int ingredientCount, int servingCount, string cuisine, string[] keywords)
        {
            Title = title;
            Cuisine = cuisine;
            ServingCount = servingCount;
            Instructions = instructions;
            KeyWords = new string[keywords.Length];
            keywords.CopyTo(this.KeyWords, 0);
            IngredientCount = ingredientCount;

        }
        /// <summary>
        /// third constructor used for testing only
        /// </summary>
        /// <param name="list"></param>
        public Recipe (List<Ingredient> list)
        {
            this.IngredientsList = list;
        }
        /// <summary>
        /// method for searching a ingredient in a recipe's ingredient list
        /// </summary>
        /// <param name="selectedTitle"></param>
        /// <returns>found ingredient</returns>
        public Ingredient IngLookUp (string selectedTitle)
        {
            foreach (Ingredient item in IngredientsList)
            
                if (item.Name == selectedTitle) return item;
            
            return null;
            
        }


        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient (Ingredient ingredient)
        {
            IngredientsList.Add(ingredient);
            
                return true;
            
        }
        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                if (IngredientsList[i].Name == name)
                {
                    IngredientsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// بروز کردن تعداد افرادی که این دستور غذا برای آن تعداد مناسب است
        /// مقادیر مواد اولیه به نسبت لازم اضافه میشود
        /// </summary>
        /// <param name="newServingCount">تعداد افراد جدید</param>
        public void UpdateServingCount(int newServingCount)
        {
            double ratio = newServingCount / ServingCount;
            ServingCount = newServingCount;
            foreach (var item in IngredientsList)
            {
                item.Quantity *= ratio;
            }

        }
       

        
        /// <summary>
        /// file address for save and load
        /// </summary>
        public static string RecipeFileAddress { get; internal set; } = @"Recipe.txt";
        /// <summary>
        /// string showing the method which the recipe is resulted
        /// </summary>
        public string SearchMethod { get; set; }
        /// <summary>
        /// override for the system to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" Title : {Title}\n Instructions : {Instructions}\n Cuisine : {Cuisine}\n Serving Count : {ServingCount} \n Ingredients Count : {IngredientsList.Count}\n";

        }
        /// <summary>
        /// method for writing recipe info into file
        /// </summary>
        /// <param name="Writer"></param>
        public void Serialize (StreamWriter Writer)
        {
            Writer.WriteLine(Title);
            Writer.WriteLine(Cuisine);
            Writer.WriteLine(ServingCount);
            Writer.WriteLine(Instructions);
            Writer.WriteLine(IngredientCount);
            Writer.WriteLine(String.Join(" ",KeyWords));
                foreach(Ingredient Sample in IngredientsList)
                {
                    Sample.Serilize(Writer);
                }

        }
        /// <summary>
        /// method for reading recipe info from a file
        /// </summary>
        /// <param name="Reader"></param>
        /// <returns></returns>
        public static Recipe Deserialize (StreamReader Reader)
        {
            string RTitle = Reader.ReadLine();
            if (RTitle == null)
                return null;
            string RCuisine = Reader.ReadLine();
            int RServingCount = int.Parse(Reader.ReadLine());
            string RInstructions = Reader.ReadLine();
            int RIngredientCount = int.Parse(Reader.ReadLine());
            string[] RKeywords = Reader.ReadLine().Split();
            List <Ingredient> RIng = new List<Ingredient>();
                for (int i = 0; i < RIngredientCount; i++)
                {
                RIng.Add(Ingredient.Deserialize(Reader));
                }
            return new Recipe(RTitle,RInstructions,RIng,RServingCount,RCuisine,RKeywords);

        }
        
        

       


    }
}
