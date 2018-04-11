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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment5;

namespace Assignment7
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private RecipeBook _MainBook;
        public RecipeBook MainBook
        {
            get
            {
                return _MainBook;
            }
            set
            {
                _MainBook = value;
            }
        }
        private bool IsInSearch = false;
        private bool IsSaved = false;
        public MainWindow()
        {
            
            InitializeComponent();
            
            Welcome WelcomeForm = new Welcome(Environment.UserName);
            if(WelcomeForm.ShowDialog().Value)
                MainBook = new RecipeBook(WelcomeForm.Title, 100);
            else
                MainBook = new RecipeBook("Default Title", 100);
            LabelTitle.Content = MainBook.BookTitle;
            
            
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            RecipeForm frm = new RecipeForm();
            if (frm.ShowDialog().Value)
            {
                IsSaved = false;
                Recipe TempRec = frm.TempRec;
                MainBook.Add(TempRec);
                UpdateRecipeListBox();
            }

            
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string LoadFilePath = null;
            openFileDialog.ShowDialog();
            LoadFilePath = openFileDialog.FileName;
            MainBook.ListOfRecipes.Clear();
            MainBook.Load(LoadFilePath);
            UpdateRecipeListBox();
            MessageBox.Show("Successfully Loaded Your File");
        }
        private void UpdateRecipeListBox()
        {
            RecipeListBox.Items.Clear();
            foreach(Recipe item in MainBook.ListOfRecipes)
            {
                ListBoxItem NewItem = new ListBoxItem();
                NewItem.Content = item.Title;
                RecipeListBox.Items.Add(NewItem.Content);
            }
        }
        private void ShowSearchResult (params Recipe[] Result)
        {
            BtnLoad.IsEnabled = false;
            BtnSave.IsEnabled = false;
            BtnNew.IsEnabled = false;
            BtnReturn.Visibility = Visibility.Visible;
            IsInSearch = true;
            RecipeListBox.Items.Clear();
            foreach (Recipe item in Result)
            {
                ListBoxItem NewItem = new ListBoxItem();
                NewItem.Content = item.Title;
                RecipeListBox.Items.Add(NewItem.Content);
            }

        }
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (Recipe item in MainBook.ListOfRecipes)
            {
                if(item.Title == RecipeListBox.SelectedItem.ToString())
                {
                    MainBook.ListOfRecipes.Remove(item);
                    IsSaved = false;
                    break;
                }
            }
            if (IsInSearch)
            {
                RecipeListBox.Items.Remove(RecipeListBox.SelectedItem);
            }
            else
            {
                UpdateRecipeListBox();
            }
            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            string SaveFilePath = null;
            SaveDialog.ShowDialog();
            SaveFilePath = SaveDialog.FileName;
            
            MainBook.Save(SaveFilePath);
            MessageBox.Show("Successfully Saved At : \n" + SaveFilePath);
            IsSaved = true;


        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < MainBook.ListOfRecipes.Count; i++)
            { 
                if (MainBook.ListOfRecipes[i].Title == RecipeListBox.SelectedItem.ToString())
                {
                    ShowRecipe ShowForm = new ShowRecipe(MainBook.ListOfRecipes[i]);
                    switch (ShowForm.ShowDialog().Value)
                    {
                        case true:
                            ShowRecipe EditForm = new ShowRecipe(MainBook.ListOfRecipes[i],true);
                            if (EditForm.ShowDialog().Value)
                            {
                                MainBook.ListOfRecipes[i] = EditForm.Sample;
                                IsSaved = false;
                            }


                            break;

                        case false:



                            break;
                    }
                    break;

                }
            }
        }

       
        private void SBKeywordItem_Click(object sender, RoutedEventArgs e)
        {
            ShowSearchResult(MainBook.LookupByKeyword(SearchBox.Text));
        }

        private void SBTitkeItem_Click(object sender, RoutedEventArgs e)
        {
            ShowSearchResult(MainBook.LookupByTitle(SearchBox.Text));
        }

        private void SBCuisineItem_Click(object sender, RoutedEventArgs e)
        {
            ShowSearchResult(MainBook.LookupByCuisine(SearchBox.Text));
        }

        
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            BtnReturn.Visibility = Visibility.Collapsed;
            BtnLoad.IsEnabled = true;
            BtnSave.IsEnabled = true;
            BtnNew.IsEnabled = true;
            UpdateRecipeListBox();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsSaved)
            {
                SaveWarning frm = new SaveWarning();
                if (frm.ShowDialog().Value)
                {
                    SaveFileDialog SaveDialog = new SaveFileDialog();
                    string SaveFilePath = null;
                    SaveDialog.ShowDialog();
                    SaveFilePath = SaveDialog.FileName;

                    MainBook.Save(SaveFilePath);
                    MessageBox.Show("Successfully Saved At : \n" + SaveFilePath);
                    IsSaved = true;
                    
                }
            }
        }
    }
}
