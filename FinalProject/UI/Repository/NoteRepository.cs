using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NoteRepository
    {
        public Context Context;
        public NoteRepository()
        {
            Context = new Context(); 
        }
        public void NewNote (Note note)
        {
            Context.Entry(note).State = System.Data.Entity.EntityState.Added;
            Context.SaveChanges();

            
        }
        public List<Note> ReadAll ()
        {
            var notes = Context.Notes.ToList();
            return notes;
        }

        public Note Read (string noteId)
        {
            var note = Context.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
            return note;
        }

        public void UpdateNote (Note note)
        {
            Context.Entry(note).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();

        }
        public void DeleteNote (string noteId)
        {

            Context.Entry(Read(noteId)).State = System.Data.Entity.EntityState.Deleted;
            Context.SaveChanges();
            return;
        }
    }
}
