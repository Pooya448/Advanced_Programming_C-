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
        private bool IsInAllSearch = false;
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
        /// <summary>
        /// button used for creating new recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// button used for loading existing data from a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            IsInSearch = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string LoadFilePath = null;
            if (openFileDialog.ShowDialog().Value)
            {
                LoadFilePath = openFileDialog.FileName;
                MainBook.ListOfRecipes.Clear();
                MainBook.Load(LoadFilePath);
                UpdateRecipeListBox();
            }
            
               
            
        }
        /// <summary>
        /// updating recipe list box in main form
        /// </summary>
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
        /// <summary>
        /// showing search result in recipe list box 
        /// </summary>
        /// <param name="Result">the list containing recipe search info</param>
        private void ShowSearchResult(List<Recipe> result, Recipe titleResult, bool isTitle)
        {
            if (isTitle)
            {
                if (titleResult == null)
                {
                    MessageBox.Show("No Result Found");

                    return;
                }
                else
                {
                    BtnLoad.IsEnabled = false;
                    BtnSave.IsEnabled = false;
                    BtnNew.IsEnabled = false;
                    BtnReturn.Visibility = Visibility.Visible;

                    RecipeListBox.Items.Clear();
                    ListBoxItem NewItem = new ListBoxItem();
                    NewItem.Content = titleResult.Title;
                    RecipeListBox.Items.Add(NewItem.Content);
                }
                
                
            }
            else
            {
                if (result==null)
                {
                    MessageBox.Show("No Result Found");

                    return;
                }
                else
                {
                    BtnLoad.IsEnabled = false;
                    BtnSave.IsEnabled = false;
                    BtnNew.IsEnabled = false;
                    BtnReturn.Visibility = Visibility.Visible;

                    RecipeListBox.Items.Clear();
                    foreach (Recipe item in result)
                    {
                        ListBoxItem NewItem = new ListBoxItem();
                        NewItem.Content = item.Title;
                        RecipeListBox.Items.Add(NewItem.Content);
                    }
                }
                
            }
            

        }
        /// <summary>
        /// showing result of an all method search in recipe list box
        /// </summary>
        /// <param name="Result">the list containing recipe search info</param>
        private void ShowAllSearchResult (List<Recipe> Result)
        {
            if (Result.Count == 0)
            {
                MessageBox.Show("No Result Found");

                return;
            }
                    
            
            BtnLoad.IsEnabled = false;
            BtnSave.IsEnabled = false;
            BtnNew.IsEnabled = false;
            BtnReturn.Visibility = Visibility.Visible;
            
            RecipeListBox.Items.Clear();
                
            foreach (Recipe item in Result)
            {
                ListBoxItem NewItem = new ListBoxItem();
                NewItem.Content = item.Title + item.SearchMethod;
                RecipeListBox.Items.Add(NewItem.Content);
                }
        }
        /// <summary>
        /// method used for removing a recipe from the recipe list
        /// </summary>
        /// <param name="TitleSubject">title of the recipe</param>
        private void RemoveAction (string TitleSubject)
        {
            MainBook.Remove(TitleSubject);
            IsSaved = false;
            if (IsInSearch)
            {
                RecipeListBox.Items.Remove(RecipeListBox.SelectedItem);
            }
            else
            {
                UpdateRecipeListBox();
            }
        }
        /// <summary>
        /// button used for deleting a recipe from the cookbook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsInAllSearch)
                {
                    RemoveAction((RecipeListBox.SelectedItem.ToString()).Remove((RecipeListBox.SelectedItem.ToString()).IndexOf(" :")));
                }
                else
                {
                    RemoveAction(RecipeListBox.SelectedItem.ToString());
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
            
            
        }
        /// <summary>
        /// button used for saving the current cookbook into a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            string SaveFilePath = null;
            if (SaveDialog.ShowDialog().Value)
            {
                SaveFilePath = SaveDialog.FileName;
                MainBook.Save(SaveFilePath);
                MessageBox.Show("Successfully Saved At : \n" + SaveFilePath);
                IsSaved = true;
            }
            


        }
        /// <summary>
        /// method performing view action
        /// </summary>
        /// <param name="TitleSubject">recipe title for performinh view action</param>
        private void ViewAction (string TitleSubject)
        {
            Recipe Result = MainBook.LookupByTitle(TitleSubject);
            ShowRecipe ShowForm = new ShowRecipe(Result);
            if (ShowForm.ShowDialog().Value)
            {
                ShowRecipe EditForm = new ShowRecipe(Result, true);
                if (EditForm.ShowDialog().Value)
                {
                    //Predicate<Recipe> RecipeFinder = (Recipe x) => { return x.Title == Result.Title; };
                    MainBook.ListOfRecipes[MainBook.ListOfRecipes.IndexOf(Result)] = EditForm.Sample;
                    IsSaved = false;
                }
            }
        }
        /// <summary>
        /// button used for creating a new recipe and adding it to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsInAllSearch)
                {
                    ViewAction((RecipeListBox.SelectedItem.ToString()).Remove((RecipeListBox.SelectedItem.ToString()).IndexOf(" : ")));
                }
                else
                {
                    ViewAction(RecipeListBox.SelectedItem.ToString());
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
            
        }
        /// <summary>
        /// method called when keyword search method clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBKeywordItem_Click(object sender, RoutedEventArgs e)
        {
            IsInAllSearch = false;
            IsInSearch = true;
            ShowSearchResult(MainBook.LookupByKeyword(SearchBox.Text),null,false);
        }
        /// <summary>
        /// method called when title search method clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBTitkeItem_Click(object sender, RoutedEventArgs e)
        {
            IsInAllSearch = false;
            IsInSearch = true;
            ShowSearchResult(null,MainBook.LookupByTitle(SearchBox.Text),true);
        }
        /// <summary>
        /// method called when cuisine search method clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBCuisineItem_Click(object sender, RoutedEventArgs e)
        {
            IsInAllSearch = false;
            IsInSearch = true;
            ShowSearchResult(MainBook.LookupByCuisine(SearchBox.Text),null,false);
        }
        /// <summary>
        /// the mai search button code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SearchBox.Text == "")
                    throw new NullReferenceException();
                (sender as Button).ContextMenu.IsEnabled = true;
                (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
                (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                (sender as Button).ContextMenu.IsOpen = true;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Search Field Is Empty !");

            }

            

        }
        /// <summary>
        /// code for return button, the button returns to the main cookbook search after a search is happened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            IsInSearch = false;
            IsInAllSearch = false;
            BtnReturn.Visibility = Visibility.Collapsed;
            BtnLoad.IsEnabled = true;
            BtnSave.IsEnabled = true;
            BtnNew.IsEnabled = true;
            SearchBox.Text = "";
            UpdateRecipeListBox();
        }
        /// <summary>
        /// event handler of mainform closing event, used for asking the user if he/she wants to save in case of new changes added to the cookbook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// method called when All methods search method clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SBAllItem_Click(object sender, RoutedEventArgs e)
        {
            IsInAllSearch = true;
            IsInSearch = true;
            List<Recipe> AllSearchResult = new List<Recipe>();
            Recipe tempResTitle = MainBook.LookupByTitle(SearchBox.Text);
            if (tempResTitle != null) AllSearchResult.Add(tempResTitle);
            List<Recipe> tempResCuisine = new List<Recipe>();
            tempResCuisine = MainBook.LookupByCuisine(SearchBox.Text);
            if (tempResCuisine != null) AllSearchResult.AddRange(tempResCuisine);
            List<Recipe> tempResKey = new List<Recipe>();
            tempResKey = MainBook.LookupByKeyword(SearchBox.Text);
            if (tempResKey != null) AllSearchResult.AddRange(tempResKey);
            ShowAllSearchResult(AllSearchResult);
        }
    }
}
