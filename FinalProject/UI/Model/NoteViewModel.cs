using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoteViewModel
    {

        public NoteViewModel(string title, string text, string noteId, Color noteColor)
        {
            this.Title = title;
            this.Text = text;
            this.NoteId = noteId;
            this.NoteColor = new ViewColor(noteColor);
            this.EnumColor = noteColor;
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public string NoteId { get; set; }
        public ViewColor NoteColor { get; set; }
        public Color EnumColor { get; set; }
    }

    public class ViewColor
    {

        public Tuple<string,string> Color { get; set; }

        public Color EnumColor { get; set; }
        
        public ViewColor(Model.Color color)
        {
            switch (color)
            
            {
                case Model.Color.Red:
                    Color = new Tuple<string, string>("#A90D0D", "#D59494");
                    break;
                case Model.Color.Yellow:
                    Color = new Tuple<string, string>("#FFB901", "#FFF2B5");
                    break;
                case Model.Color.Purple:
                    Color = new Tuple<string, string>("#D901A9", "#FFC3F4");
                    break;
                case Model.Color.Violet:
                    Color = new Tuple<string, string>("#5D249B", "#DEC6FB");
                    break;
                case Model.Color.Blue:
                    Color = new Tuple<string, string>("#0179D7", "#C4E5FF");
                    break;
                case Model.Color.Green:
                    Color = new Tuple<string, string>("#118905", "#C7EFC7");
                    break;
                case Model.Color.Grey:
                    Color = new Tuple<string, string>("#777777", "#F9F9F9");
                    break;
                default:
                    break;
            }
        }

        

    }


}
