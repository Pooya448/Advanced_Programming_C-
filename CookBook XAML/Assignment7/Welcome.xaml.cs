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

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public new string Title { get; set; }
        public Welcome(string name)
        {
            InitializeComponent();
            WelcomeBlock.Text ="Welcome, " + name + "!";

        }
        /// <summary>
        /// button indicating if the user pressed enter button on keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Title = CookBookNameBox.Text;
        }
    }
}
