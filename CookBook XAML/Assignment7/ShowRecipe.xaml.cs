﻿using System;
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
    /// Interaction logic for ShowRecipe.xaml
    /// </summary>
    public partial class ShowRecipe : Window
    {
        private Recipe _Sample;
        public Recipe Sample
        {
            get
            {
                return _Sample;
            }
            set
            {
                _Sample = value;
            }
        }
        /// <summary>
        /// constructor for show recipe form class and used for showing and editting a recipe
        /// </summary>
        /// <param name="Rec"></param>
        public ShowRecipe(Recipe Rec)
        {
            InitializeComponent();
            TitleBox.Text = Rec.Title;
            SCountBox.Text = Rec.ServingCount.ToString();
            KeywordsBox.Text = String.Join(" ",Rec.KeyWords);
            CuisineBox.Text = Rec.Cuisine;
            ShowListBox(Rec);
            Sample = Rec;
            this.Title = "Viewing Recipe : " + Rec.Title;
            EditIngBtn.Visibility = Visibility.Collapsed;
            UpdateBtn.Visibility = Visibility.Collapsed;
            CancleBtn.Visibility = Visibility.Collapsed;
            EditIngBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            CancleBtn.IsEnabled = false;


            BtnView.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Visible;
            CloseBtn.Visibility = Visibility.Visible;
            BtnView.IsEnabled = true;
            EditBtn.IsEnabled = true;
            CloseBtn.IsEnabled = true;
        }
        public ShowRecipe(Recipe Rec,bool Enable)
        {
            InitializeComponent();
            TitleBox.Text = Rec.Title;
            SCountBox.Text = Rec.ServingCount.ToString();
            KeywordsBox.Text = String.Join(" ", Rec.KeyWords);
            CuisineBox.Text = Rec.Cuisine;
            ShowListBox(Rec);
            Sample = Rec;
            this.Title = "Editting Recipe : " + Rec.Title;
            TitleBox.IsReadOnly = false;
            SCountBox.IsReadOnly = false;
            KeywordsBox.IsReadOnly = false;
            CuisineBox.IsReadOnly = false;

            EditIngBtn.Visibility = Visibility.Visible;
            UpdateBtn.Visibility = Visibility.Visible;
            CancleBtn.Visibility = Visibility.Visible;
            EditIngBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            CancleBtn.IsEnabled = true;

            BtnView.Visibility = Visibility.Collapsed;
            EditBtn.Visibility = Visibility.Collapsed;
            CloseBtn.Visibility = Visibility.Collapsed;
            BtnView.IsEnabled = false;
            EditBtn.IsEnabled = false;
            CloseBtn.IsEnabled = false;

        }
        /// <summary>
        /// showing ingredient list box in recipe form
        /// </summary>
        /// <param name="Rec">recipe which it's ingredient are shown</param>
        private void ShowListBox (Recipe Rec)
        {
            foreach(Ingredient item in Rec.IngredientsList)
            {
                ListBoxItem NewItem = new ListBoxItem();
                NewItem.Content = item.Name;
                IngredientsListBox.Items.Add(NewItem.Content);
            }
        }
        /// <summary>
        /// closing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
        /// <summary>
        /// when clicked the edit shape of the current form shows up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }
        /// <summary>
        /// button for viewing the current ingredients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ingredient item in Sample.IngredientsList)
            {
                if (item.Name == IngredientsListBox.SelectedItem.ToString())
                {
                    IngredientShowForm ShowIng = new IngredientShowForm(item);
                    ShowIng.ShowDialog();
                    break;

                }
            }
        }
        /// <summary>
        /// editing the selected ingredient from the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditIngBtn_Click(object sender, RoutedEventArgs e)
        {
            
            for(int i = 0; i < Sample.IngredientsList.Count; i++)
            {
                if (Sample.IngredientsList[i].Name == IngredientsListBox.SelectedItem.ToString())
                {
                    IngredientShowForm ShowIng = new IngredientShowForm(Sample.IngredientsList[i], true);
                    if (ShowIng.ShowDialog().Value)
                    {
                        Sample.IngredientsList[i] = ShowIng.Sample;
                    }
                    break;

                }
            }
                
            
        }
        /// <summary>
        /// updating the recipe and saving the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Sample.KeyWords = KeywordsBox.Text.Split();
            Sample.Title = TitleBox.Text;
            Sample.ServingCount = int.Parse(SCountBox.Text);
            Sample.Cuisine = CuisineBox.Text;
            DialogResult = true;
            Close();
        }
        /// <summary>
        /// cancling the edit procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}