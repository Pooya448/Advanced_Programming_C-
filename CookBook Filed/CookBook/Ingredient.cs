﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment5
{
    /// <summary>
    /// یک جزء از ترکیبات دستور غذا
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// ایجاد شئ مشخصات یکی از مواد اولیه دستور غذا
        /// </summary>
        /// <param name="name">نام</param>
        /// <param name="description">توضیح</param>
        /// <param name="quantity">مقدار</param>
        /// <param name="unit">واحد مقدار</param>
        public Ingredient(string name, string description, double quantity, string unit)
        {
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Unit = unit;

        }

        /// <summary>
        /// نام ماده اولیه
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// توضیح: از کجا پیدا کنیم یا اگر نداشتیم جایگزین چه چیزی استفاده کنیم
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// مقدار
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// واحد مقدار: مثلا گرم، کیلوگرم، عدد
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// تبدیل به متن
        /// </summary>
        /// <returns>متن معادل برای این ماده اولیه - قابل استفاده برای چاپ در خروجی</returns>
        public override string ToString()
        {
            return $"{Name}:\t{Quantity} {Unit} - {Description}\n";
        }
        public void Serilize (StreamWriter Writer)
        {
            Writer.WriteLine(Name);
            Writer.WriteLine(Description);
            Writer.WriteLine(Quantity);
            Writer.WriteLine(Unit);
        }
        
        public static Ingredient Deserialize (StreamReader Reader)
        {
            string RName = Reader.ReadLine();
            string RDescription = Reader.ReadLine();
            Double RQuantity = double.Parse(Reader.ReadLine());
            string RUnit = Reader.ReadLine();
            return new Ingredient(RName, RDescription, RQuantity, RUnit);
        }
        public static List<Ingredient> InitialIngredient(int ingredientCount, bool IsTest = false,StringBuilder sb = null)
        {
            List<Ingredient> takenFromUser = new List<Ingredient>();
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Please Enter name of ingredient {i+1} :");
                string name = Console.ReadLine();
                
                Console.WriteLine($"Please Enter description of ingredient {i+1} :");
                string description = Console.ReadLine();
                
                Console.WriteLine($"Please Enter the unit of ingredient {i+1} :");
                string unit = Console.ReadLine();
                
                Console.WriteLine($"Please Enter the quantity of ingredient {i+1} :");
                double quantity = double.Parse(Console.ReadLine());
                takenFromUser.Add(new Ingredient(name, description, quantity, unit));
                
            }
            return takenFromUser;
        }

    }
}
