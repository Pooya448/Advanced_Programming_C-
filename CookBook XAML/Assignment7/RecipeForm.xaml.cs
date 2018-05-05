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
        
        
        public List<Ingredient> IngList = new List<Ingredient>();
        private Recipe _TempRec;
        public Recipe TempRec { set { _TempRec = value; } get { return _TempRec; } }
        public RecipeForm()
        {
            InitializeComponent();
            TempRec = new Recipe(IngList);
            
        }
        /// <summary>
        /// creating new ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            IngredientForm IngForm = new IngredientForm();
            
            if (IngForm.ShowDialog().Value)
            {
                IngList.Add(IngForm.TempIng);
                UpdateIngredientListbox();
            }


        }
        /// <summary>
        /// saving the recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Counter = 0;


                if (TitleBox.Text == "")
                {
                    TitleBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    TitleBlock.Foreground = Brushes.Black;
                }
                if (CuisineBox.Text == "")
                {
                    CuisineBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    CuisineBlock.Foreground = Brushes.Black;
                }
                if (KeywordsBox.Text == "")
                {
                    KeywordsBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    KeywordsBlock.Foreground = Brushes.Black;
                }
                if (int.Parse(SCountBox.Text) < 0)
                {
                    SCountBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    SCountBlock.Foreground = Brushes.Black;
                }
                if (Counter > 0)
                    throw new NullReferenceException();
                TempRec = new Recipe(TitleBox.Text, "Instructions", IngList, int.Parse(SCountBox.Text), CuisineBox.Text, KeywordsBox.Text.Split());
                DialogResult = true;
            }
            catch (System.FormatException)
            {
                SCountBlock.Foreground = Brushes.Red;
                MessageBox.Show("Please Enter a Valid Positive Number \n Complete All Fields");
                Hide();
                ShowDialog();
            }

            
            
            catch (NullReferenceException)
            {
                MessageBox.Show("Please Complete All Fields");
                Hide();
                ShowDialog();
            }
            Close();
        }
        /// <summary>
        /// updating the ingredient list box in recipeform
        /// </summary>
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
        /// <summary>
        /// deleting an ingredient from the ingredient list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            IngList.Remove(TempRec.IngLookUp(IngredientsListBox.SelectedItem.ToString()));
            UpdateIngredientListbox();
        }
        /// <summary>
        /// viewing selected ingredient from the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {  
            Ingredient Result = TempRec.IngLookUp(IngredientsListBox.SelectedItem.ToString());
            IngredientShowForm ShowIng = new IngredientShowForm(Result);
            ShowIng.ShowDialog();
        }
        /// <summary>
        /// cancling the recipe adding procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanclBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}
