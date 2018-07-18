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
using Model;

namespace UI
{
    /// <summary>
    /// Interaction logic for Colors.xaml
    /// </summary>
    public partial class Colors : Window
    {
        public ViewColor ColorSelected { get; set; }
        public Model.Color EnumColor { get; set; }

        public Colors(ViewColor original)
        {
            InitializeComponent();
            ColorSelected = original;
            
        }
        public Colors()
        {
            InitializeComponent();
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Yellow);
            EnumColor = Model.Color.Yellow;
            DialogResult = true;
            Close();
            return;
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Green);
            EnumColor = Model.Color.Green;
            DialogResult = true;
            Close();
            return;
        }

        private void Pink_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Purple);
            EnumColor = Model.Color.Purple;
            DialogResult = true;
            Close();
            return;
        }

        private void Blue_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Blue);
            EnumColor = Model.Color.Blue;
            DialogResult = true;
            Close();
            return;
        }

        private void Violet_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Violet);
            EnumColor = Model.Color.Violet;
            DialogResult = true;
            Close();
            return;
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Red);
            EnumColor = Model.Color.Red;
            DialogResult = true;
            Close();
            return;
        }

        private void Grey_Click(object sender, RoutedEventArgs e)
        {
            ColorSelected = new ViewColor(Model.Color.Grey);
            EnumColor = Model.Color.Grey;
            DialogResult = true;
            Close();
            return;
        }
    }
}
