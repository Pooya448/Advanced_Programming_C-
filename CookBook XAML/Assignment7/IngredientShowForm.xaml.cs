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
    /// Interaction logic for IngredientShowForm.xaml
    /// </summary>
    public partial class IngredientShowForm : Window
    {
        private Ingredient _Sample;
        public Ingredient Sample
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
        public IngredientShowForm(Ingredient Ing)
        {
            InitializeComponent();
            UnitTxtBox.Text = Ing.Unit;
            DescriptionBox.Text = Ing.Description;
            TitleBox.Text = Ing.Name;
            QuantityBox.Text = Ing.Quantity.ToString();
            this.Title = "Viewing Ingredient : " + Ing.Name;
        }
        public IngredientShowForm(Ingredient Ing, bool Enable)
        {
            InitializeComponent();
            this.Title = "Editting Ingredient : " + Ing.Name;
            UnitTxtBox.Text = Ing.Unit;
            DescriptionBox.Text = Ing.Description;
            TitleBox.Text = Ing.Name;
            QuantityBox.Text = Ing.Quantity.ToString();
            UnitTxtBox.IsEnabled = true;
            DescriptionBox.IsEnabled = true;
            TitleBox.IsEnabled = true;
            QuantityBox.IsEnabled = true;
            UnitTxtBox.IsReadOnly = false;
            DescriptionBox.IsReadOnly = false;
            TitleBox.IsReadOnly = false;
            QuantityBox.IsReadOnly = false;
            UpdateIngBtn.Visibility = Visibility.Visible;
            Sample = Ing;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateIngBtn_Click(object sender, RoutedEventArgs e)
        {
            Sample.Name = TitleBox.Text;
            Sample.Unit = UnitTxtBox.Text;
            Sample.Quantity = double.Parse(QuantityBox.Text);
            Sample.Description = DescriptionBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
