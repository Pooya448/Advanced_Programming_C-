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
    public class Recipe
    {
        private string _Title;
        private string _Cuisine;
        private int _ServingCount;
        private string _Instructions;
        private int _IngredientCount;
        private int Indicator = 0;
        public string[] KeyWords;
        public Ingredient[] RecipeIngredients;
        public bool IsIngredientsAdded = false;

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
            this._Title = title;
            this._Cuisine = cuisine;
            this._ServingCount = servingCount;
            this._Instructions = instructions;
            this.KeyWords = new string[keywords.Length];
            keywords.CopyTo(this.KeyWords, 0);
            ingredient.CopyTo(this._Ingredients, 0);
            this._IngredientCount = ingredient.Length;
            this.IsIngredientsAdded = true;

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
            this._Title = title;
            this._Cuisine = cuisine;
            this._ServingCount = servingCount;
            this._Instructions = instructions;
            this.KeyWords = new string[keywords.Length];
            keywords.CopyTo(this.KeyWords, 0);
            this._IngredientCount = ingredientCount;
            
        }

        /// <summary>
        /// اضافه کردن ماده اولیه 
        /// </summary>
        /// <param name="ingredient">ماده اولیه</param>
        /// <returns>عمل اضافه کردن موفقیت آمیز انجام شد یا خیر. در صورت تکمیل ظرفیت مقدار برگشتی "خیر" میباشد.</returns>
        public bool AddIngredient (Ingredient ingredient)
        {

            
            if (this.Indicator > this._IngredientCount)
                return false;
            else
            {
                _Ingredients[Indicator] = ingredient;
                Indicator++;
                this.IsIngredientsAdded = false;
                return true;
            }
        }
        /// <summary>
        /// حذف تمام مواد اولیه که با نام ورودی تطبیق میکند
        /// </summary>
        /// <param name="name">نام ماده اولیه برای حذف</param>
        /// <returns>آیا حداقل یک ماده اولیه حذف شد؟</returns>
        public bool RemoveIngredient(string name)
        {
            for(int i = 0; i < this._IngredientCount; i++)
                if(_Ingredients[i].Name == name)
                {
                    _Ingredients[i] = null;
                    for(int t = i+1; t < this._IngredientCount; t++)
                    {
                        _Ingredients[t - 1] = _Ingredients[t];
                    }
                    this._IngredientCount--;
                    this.Indicator--;
                    if (this._IngredientCount == 0)
                        this.IsIngredientsAdded = false;
                    return true;
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
            //if(newServingCount > this._ServingCount)
            //    for(int i=0;i < newServingCount - this._ServingCount; i++)
            //    {

            //    }
            this._ServingCount = newServingCount;
            
        }
        public static Ingredient[] InitialIngredient(int ingredientCount)
        {
            Ingredient[] Temp = new Ingredient[ingredientCount];
            for (int i = 1; i <= ingredientCount; i++)
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
            return $" Title : {this.Title}\n Instructions : {this.Instructions}\n Cuisine : {this.Cuisine}\n Serving Count : {this.ServingCount} \n Ingredients Count : {this._IngredientCount}\n";
            //return null;
        }
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                _Title = value; 
            }
        }
        public string Cuisine
        {
            get
            {
                return this._Cuisine;
            }
            set
            {
                _Cuisine = value;
            }
        }
        public int ServingCount
        {
            get
            {
                return this._ServingCount;
            }
            set
            {
                _ServingCount = value;
            }
        }
        public string Instructions
        {
            get
            {
                return this._Instructions;
            }
            set
            {
                _Instructions = value;
            }
        }
        public int IngredientCount
        {
            get
            {
                return this._IngredientCount;
            }
            set
            {
                _IngredientCount = value;
            }
        }



    }
}
