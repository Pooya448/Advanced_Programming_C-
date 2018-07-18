using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;


namespace Repository.Tests
{
    [TestClass()]
    public class NoteRepositoryTests
    {
        NoteRepository TestRepo;
        string Title = "TestTitle";
        string Text = "TestText";
        string Id = System.DateTime.Now.ToString();
        Model.Color NoteTestColor = Color.Blue;

        List<Note> NoteList;

        Note TestNote;

        

        [TestMethod()]
        public void ReadTest()
        {
            TestNote = new Note(); //For covering note.cs defauklt constructor
            TestNote = new Note(Title, Text, Id, NoteTestColor);
            TestRepo = new NoteRepository();
            TestRepo.NewNote(TestNote);
            var Found = TestRepo.Read(Id);
            Assert.AreEqual(Found.Title, TestNote.Title);
            Assert.AreEqual(Found.Text, TestNote.Text);
            Assert.AreEqual(Found.NoteId, TestNote.NoteId);
            Assert.AreEqual(Found.NoteColor, TestNote.NoteColor);
            TestRepo.DeleteNote(Id);

        }


        [TestMethod()]
        public void NewNoteTest()
        {
            TestNote = new Note(Title, Text, Id, NoteTestColor);
            TestRepo = new NoteRepository();
            TestRepo.NewNote(TestNote);
            NoteList = TestRepo.ReadAll();
            Assert.IsTrue(NoteList.Contains(TestNote));
            TestRepo.DeleteNote(Id);
            NoteList = TestRepo.ReadAll();
            Assert.IsFalse(NoteList.Contains(TestNote));

        }

        [TestMethod()]
        public void UpdateNoteTest()
        {
            TestNote = new Note(Title, Text, Id, NoteTestColor);
            TestRepo = new NoteRepository();
            TestRepo.NewNote(TestNote);
            TestNote.Title = "Updatedtitle";
            TestRepo.UpdateNote(TestNote);
            Assert.IsTrue((TestRepo.Read(TestNote.NoteId)).Title == "Updatedtitle");
            TestRepo.DeleteNote(Id);

        }

       
    }
}