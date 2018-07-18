using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Color { Red,Yellow,Purple,Violet,Blue,Green,Grey}
    public class Note
    {
        public Note()
        {

        }
        public Note(string title,string text,string id,Color color)
        {
            this.Text = text;
            this.NoteId = id;
            this.Title = title;
            this.NoteColor = color;
        }
        public string Title { get; set; }
        public string Text { get; set; }
        [Key] public string NoteId { get; set; }
        public Color NoteColor { get; set; }
    }
}
