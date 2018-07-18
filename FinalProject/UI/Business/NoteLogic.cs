using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;



namespace Business
{
    public class NoteLogic
    {
        public Note MapToNote (NoteViewModel noteViewM)
        {
            return new Note(noteViewM.Title, noteViewM.Text, noteViewM.NoteId, noteViewM.EnumColor);
        }

        public NoteViewModel MapToNoteViewModel (Note note)
        {
            return new NoteViewModel(note.Title,note.Text,note.NoteId,note.NoteColor);
        }

        NoteRepository noteRepo = new NoteRepository();

        public void NewNote(NoteViewModel noteViewM)
        {

            var note = MapToNote(noteViewM);
            noteRepo.NewNote(note);
        }

        public void Update(NoteViewModel note)
        {
            Note update = new Note();
            List<Note> changed = noteRepo.ReadAll();
            for (int i = 0; i < changed.Count; i++)
            {
                if (changed[i].NoteId == note.NoteId)
                {
                    changed[i].Title = note.Title;
                    changed[i].Text = note.Text;
                    changed[i].NoteColor = note.EnumColor;
                    update = changed[i];
                    break;
                }

            }
            noteRepo.UpdateNote(update);
        }

        public List<NoteViewModel> ReadAll()
        {
            var notes = noteRepo.ReadAll();
            List<NoteViewModel> results = new List<NoteViewModel>();
            foreach (Note item in notes)
            {
                results.Add(MapToNoteViewModel(item));
            }
            
            return results;
        }

        public void DeleteNote (string noteId)
        {
            noteRepo.DeleteNote(noteId);
        }

       public NoteViewModel Read (string id)
        {
            var note = noteRepo.Read(id);
            return MapToNoteViewModel(note);
        }
    }
}
