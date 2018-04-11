using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Assignment5;

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for RecipeForm.xaml
    /// </summary>
    public partial class RecipeForm : Window
    {
        //static string TestTitle = "Test";
        //static string TestInstructions = "Test";
        //static string TestCuisine = "Test";
        //static string[] TestKeywords = new string[] { "Test1", "Test2" };
        //static int TestServingCount = 5;
        //static int TestInCount = 0;
        //private Recipe _TempRec = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
        //public Recipe TempRec { set; get; }
        public List<Ingredient> IngList = new List<Ingredient>();
        private Recipe _TempRec;
        public Recipe TempRec { set { _TempRec = value; } get { return _TempRec; } }
        public RecipeForm()
        {
            InitializeComponent();
            
        }
        
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            IngredientForm IngForm = new IngredientForm();
            
            if (IngForm.ShowDialog().Value)
            {
                Ingredient TempIng = IngForm.TempIng;
                IngList.Add(TempIng);
                UpdateIngredientListbox();
            }


        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (int.Parse(SCountBox.Text) < 0)
                    throw new System.FormatException();
                if (TitleBox.Text == "")
                    throw new NullReferenceException();
                if (CuisineBox.Text == "")
                    throw new NullReferenceException();
                if (KeywordsBox.Text == "")
                    throw new NullReferenceException();
                TempRec = new Recipe(TitleBox.Text, "Instructions", IngList.ToArray(), int.Parse(SCountBox.Text), CuisineBox.Text, KeywordsBox.Text.Split());
                this.DialogResult = true;
            }
            catch (System.FormatException Exp)
            {
                MessageBox.Show("Please Enter a Valid Positive Number");
                Hide();
                ShowDialog();
            }
            catch (NullReferenceException Exp)
            {
                MessageBox.Show("Please Complete All Fields");
                Hide();
                ShowDialog();
            }
            Close();
        }
        private void UpdateIngredientListbox()
        {
            IngredientsListBox.Items.Clear();
            foreach (Ingredient item in IngList)
            {
                ListBoxItem NewItem = new ListBoxItem();
                NewItem.Content = item.Name;
                IngredientsListBox.Items.Add(NewItem.Content);

            }
        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Ingredient item in IngList)
            {
                if (item.Name == IngredientsListBox.SelectedItem.ToString())
                {
                    IngList.Remove(item);
                    break;
                }
            }
            UpdateIngredientListbox();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            
            foreach(Ingredient item in IngList)
            {
                if (item.Name == IngredientsListBox.SelectedItem.ToString())
                {
                    IngredientShowForm ShowIng = new IngredientShowForm(item);
                    ShowIng.ShowDialog();
                    break;
                   
                }
            }
        }

        private void CanclBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
