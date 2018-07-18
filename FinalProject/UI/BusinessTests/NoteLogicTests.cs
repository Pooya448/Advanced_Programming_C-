using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.Tests
{
    [TestClass()]
    public class NoteLogicTests
    {
        NoteLogic TestLogic;
        Note TestNote;
        NoteViewModel TestViewModel;
        string Title = "TestTitle";
        string Text = "TestText";
        string Id = System.DateTime.Now.ToString();
        Model.Color NoteTestColor = Color.Blue;

        [TestMethod()]
        public void MapTest()
        {
            TestLogic = new NoteLogic();
            TestNote = new Note(Title, Text, Id, NoteTestColor);
            TestViewModel = TestLogic.MapToNoteViewModel(TestNote);
            Note ReturnedNote = TestLogic.MapToNote(TestViewModel);
            Assert.AreEqual(TestNote.Text, ReturnedNote.Text);
            Assert.AreEqual(TestNote.Title, ReturnedNote.Title);
            Assert.AreEqual(TestNote.NoteId, ReturnedNote.NoteId);
            Assert.AreEqual(TestNote.NoteColor, ReturnedNote.NoteColor);
        }

        [TestMethod]
        public void ModelTests()
        {
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Green;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Grey;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Purple;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Red;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Violet;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Yellow;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            NoteTestColor = Color.Default;
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            TestViewModel = null;

        }

        [TestMethod()]
        public void NewNoteAndDeleteNoteTest()
        {
            TestLogic = new NoteLogic();
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            TestLogic.NewNote(TestViewModel);
            var Found = TestLogic.Read(TestViewModel.NoteId);
            Assert.AreEqual(TestViewModel.Title, Found.Title);
            Assert.AreEqual(TestViewModel.Text, Found.Text);
            Assert.AreEqual(TestViewModel.NoteColor.Color, Found.NoteColor.Color);
            Assert.AreEqual(TestViewModel.EnumColor, Found.EnumColor);
            TestLogic.DeleteNote(TestViewModel.NoteId);
            var FoundList = TestLogic.ReadAll();
            Assert.IsFalse(FoundList.Contains(TestViewModel));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            TestLogic = new NoteLogic();
            TestViewModel = new NoteViewModel(Title, Text, Id, NoteTestColor);
            TestLogic.NewNote(TestViewModel);
            TestViewModel.Title = "UpdatedTitle";
            TestViewModel.Text = "UpdatedText";
            TestLogic.Update(TestViewModel);
            var Found = TestLogic.Read(TestViewModel.NoteId);
            Assert.AreEqual(TestViewModel.Title, Found.Title);
            Assert.AreEqual(TestViewModel.Text, Found.Text);
        }
    }
}