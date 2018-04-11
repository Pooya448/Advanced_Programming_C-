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

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

        }

        private void Gram_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Grams";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Number";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }

        private void KGram_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "Kilo Grams";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }

        private void LBS_Click(object sender, RoutedEventArgs e)
        {
            UnitTxtBox.Text = "lbs.";
            UnitTxtBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = true;
        }
        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (double.Parse(QuantityBox.Text) < 0)
                    throw new System.FormatException();
                if (TitleBox.Text == "")
                    throw new NullReferenceException();
                if (DescriptionBox.Text == "")
                    throw new NullReferenceException();
                if (UnitTxtBox.Text == "")
                    throw new NullReferenceException();
                if (QuantityBox.Text == "")
                    throw new NullReferenceException();
                TempIng = new Ingredient(TitleBox.Text, DescriptionBox.Text, double.Parse(QuantityBox.Text), UnitTxtBox.Text);
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
    }
}
