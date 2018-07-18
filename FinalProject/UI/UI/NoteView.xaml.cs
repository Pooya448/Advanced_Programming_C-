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
using Business;
using Repository;
using Model;

namespace UI
{
    /// <summary>
    /// Interaction logic for NoteView.xaml
    /// </summary>
    public partial class NoteView : Window
    {
        public Model.Color TempEnumColor { get; set; }
        public ViewColor TempViewColor { get; set; }

        public NoteLogic Logic { get; set; }
        public NoteViewModel ThisNote { get; set; }
        public bool IsEdit = false;
        public NoteView(NoteViewModel note, NoteLogic logic)
        {
            InitializeComponent();
            Logic = logic;
            ThisNote = note;
            TitleBox.Text = note.Title;
            FullTextBox.Text = note.Text;
            UpdateColors(ThisNote.NoteColor);
            IsEdit = true;
        }
        public NoteView(NoteLogic logic)
        {
            InitializeComponent();
            FullTextBox.Text = "Full Note Text Goes Here";
            TitleBox.Text = "Title Goes Here";
            TempEnumColor = Model.Color.Yellow;
            Logic = logic;
            ThisNote = null;
            IsEdit = false;
        }

        private void DeleteNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ThisNote == null)
            {

                this.Close();
                return;
                
            }
            Logic.DeleteNote(ThisNote.NoteId);
            this.Close();
            return;
        }

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {
                
                ThisNote.Text = FullTextBox.Text;
                ThisNote.Title = TitleBox.Text;
                Logic.Update(ThisNote);
                this.DialogResult = true;
                this.Close();
                return;
            } else
            {
                var tempNote = new NoteViewModel(TitleBox.Text, FullTextBox.Text, System.DateTime.Now.ToString(), TempEnumColor);
                Logic.NewNote(tempNote);
                this.DialogResult = true;
                this.Close();
                return;
            }

        }

        private void UpdateColors (ViewColor color)
        {
            BrushConverter newConvertor = new BrushConverter();  
            Brush newDarkBrush = (Brush)newConvertor.ConvertFrom(color.Color.Item1);
            Brush newLightBrush = (Brush)newConvertor.ConvertFrom(color.Color.Item2);
            this.TitleGrid.Background = newDarkBrush;
            this.AddNoteBtn.Background = newDarkBrush;
            this.DeleteNoteBtn.Background = newDarkBrush;
            this.ColorBtn.Background = newDarkBrush;
            this.FullTextBox.Background = newLightBrush;

        }
       

        private void ColorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {

                UI.Colors newColorForm = new UI.Colors(ThisNote.NoteColor);
                newColorForm.Top = this.Top + 42;
                newColorForm.Left = this.Left;
                newColorForm.Background = this.Background;
                newColorForm.ShowDialog();
                if(newColorForm.DialogResult == true)
                {
                
                    ThisNote.NoteColor = newColorForm.ColorSelected;
                    ThisNote.EnumColor = newColorForm.EnumColor;
                    UpdateColors(newColorForm.ColorSelected);

                }
            } else
            {
                Colors newColorForm = new Colors();
                newColorForm.Top = this.Top + 42;
                newColorForm.Left = this.Left;
                newColorForm.Background = this.Background;
                newColorForm.ShowDialog();
                if (newColorForm.DialogResult == true)
                {

                    UpdateColors(newColorForm.ColorSelected);
                    TempViewColor = newColorForm.ColorSelected;
                    TempEnumColor = newColorForm.EnumColor;

                }
            }
        }
    }
}
