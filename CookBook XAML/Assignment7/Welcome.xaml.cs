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

namespace Assignment7
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        private string _Title;
        public string Title
        {
            set
            {
                _Title = value;
            }
            get
            {
                return _Title;
            }
        }
        public Welcome(string name)
        {
            InitializeComponent();
            WelcomeBlock.Text ="Welcome, " + name + "!";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Title = CookBookNameBox.Text;
        }
    }
}
