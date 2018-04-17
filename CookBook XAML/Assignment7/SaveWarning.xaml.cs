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
    /// Interaction logic for SaveWarning.xaml
    /// </summary>
    public partial class SaveWarning : Window
    {
        public SaveWarning()
        {
            InitializeComponent();
        }
        /// <summary>
        /// event handler for "Yes" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        /// <summary>
        /// event handler for "No" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
