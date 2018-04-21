using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// دستور پخت 
    /// </summary>
    public class Recipe: IEquatable<Recipe>
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
        public Recipe(string title, string instructions, Ingredient[] ingredient, int servingCount, string cuisine, string[] keywords)
        {
            Title = title;
            Cuisine = cuisine;
            ServingCount = servingCount;
            Instructions = instructions;
            KeyWords = new string[keywords.Length];
            keywords.CopyTo(KeyWords, 0);
            IngredientsList = new List<Ingredient>();
            IngredientsList.AddRange(ingredient);
            IngredientCount = ingredient.Length;
            AreIngsAdded = true;
            //Indicator = ingredient.Length;
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
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient (Ingredient ingredient)
        {
            IngredientsList.Add(ingredient);
            if (IngredientsList.Contains(ingredient))
                return true;
            return false;
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
            foreach(var item in IngredientsList)
                {
                    item.Quantity *= ratio;
                }
            
        }
        public static Ingredient[] InitialIngredient(int ingredientCount)
        {
            Ingredient[] Temp = new Ingredient[ingredientCount];
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"Please Enter name of ingredient {i} :");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Please Enter description of ingredient {i} :");
                string description = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Please Enter the unit of ingredient {i} :");
                string unit = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Please Enter the quantity of ingredient {i} :");
                double quantity = double.Parse(Console.ReadLine());
                Console.Clear();
                Temp[i] = new Ingredient(name, description, quantity, unit);
            }
            return Temp;
        }

        /// <summary>
        /// فیلد پیشتیبان برای Ingredients.
        /// </summary>
        private Ingredient[] _Ingredients;

        /// <summary>
        /// مواد اولیه
        /// </summary>
        public Ingredient[] Ingredients {
            get
            {
                return _Ingredients;
            }
            private set
            {
                Ingredients.CopyTo(_Ingredients, 0);
            }
        }

        public override string ToString()
        {
            return $" Title : {Title}\n Instructions : {Instructions}\n Cuisine : {Cuisine}\n Serving Count : {ServingCount} \n Ingredients Count : {IngredientsList.Count}\n";

        }

        bool IEquatable<Recipe>.Equals(Recipe other)
        {
            return this.Title == other.Title;
        }
    }
}
