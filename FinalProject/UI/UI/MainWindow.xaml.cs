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
using Business;


namespace UI
{
    public class NoteListItem : ListBoxItem
    {
        public string NoteId { get; set; }
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NoteLogic Logic { get; set; } 
        public void UpdateListBox(List<Model.NoteViewModel> list)
        {
            NoteListBox.Items.Clear();
            foreach (var item in list)
            {
                NoteListItem listItem = new NoteListItem();
                listItem.Content = item.Title;
                listItem.NoteId = item.NoteId;
                NoteListBox.Items.Add(listItem);
            }
            
        }
        public MainWindow()
        {
            InitializeComponent();
            Logic = new NoteLogic();
            UpdateListBox(Logic.ReadAll());
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(startupPath);

        }

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            NoteView NewDialog = new NoteView(Logic);
            NewDialog.Left = this.Left + 452;
            NewDialog.Top = this.Top;
            NewDialog.ShowDialog();
            UpdateListBox(Logic.ReadAll());
        }

        

        private void ColorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NoteListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((NoteListItem)NoteListBox.SelectedItem) == null)
                return;
            NoteView newDialog = new NoteView(Logic.Read(((NoteListItem)NoteListBox.SelectedItem).NoteId), Logic);
            newDialog.Left = this.Left + 452;
            newDialog.Top = this.Top;
            newDialog.ShowDialog();
            UpdateListBox(Logic.ReadAll());


        }
    }
}
