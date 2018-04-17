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
    /// Interaction logic for IngredientForm.xaml
    /// </summary>
    public partial class IngredientForm : Window
    {
        private Ingredient _TempIng;
        public Ingredient TempIng
        {
            set
            {
                _TempIng = value;
            }
            get
            {
                return _TempIng;
            }
        }
        public IngredientForm()
        {
            InitializeComponent();
            
           
        }
        /// <summary>
        /// unit menu button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

        }
        /// <summary>
        /// event handler when clicking Gram Option Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gram_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Grams";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }
        /// <summary>
        /// event handler when clicking number Option Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Number";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }
        /// <summary>
        /// event handler when clicking Kilo Gram Option Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KGram_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Kilo Grams";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }
        /// <summary>
        /// event handler when clicking LBS Option Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBS_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "lbs.";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }
        /// <summary>
        /// cancling the ingredient adding procedure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
        /// <summary>
        /// saving the current ingredient
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

                if (DescriptionBox.Text == "")
                {
                    DescriptionBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    DescriptionBlock.Foreground = Brushes.Black;
                }
                if (UnitTxtBox.Text == "")
                {
                    UnitBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    UnitBlock.Foreground = Brushes.Black;
                }
                if (QuantityBox.Text == "")
                {
                    QuantityBlock.Foreground = Brushes.Red;
                    Counter++;
                }
                else
                {
                    QuantityBlock.Foreground = Brushes.Black;
                }
                if (double.Parse(QuantityBox.Text) < 0)
                {
                    QuantityBlock.Foreground = Brushes.Red;
                    Counter++;

                }
                else
                {
                    QuantityBlock.Foreground = Brushes.Black;
                }


                if (Counter > 0)
                    throw new NullReferenceException();

                TempIng = new Ingredient(TitleBox.Text, DescriptionBox.Text, double.Parse(QuantityBox.Text), UnitTxtBox.Text);
                DialogResult = true;
            }
            catch (System.FormatException Exp)
            {
                MessageBox.Show("Please Enter a Valid Positive Number");
                QuantityBlock.Foreground = Brushes.Red;
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
    }
}
