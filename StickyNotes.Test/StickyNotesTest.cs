using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using StickyNotes.Lib;

namespace StickyNotes.Test
{
    class StickyNotesTest
    {
        StickyNotes.Lib.StickyNotes sutStickyNotes;
        [SetUp]
        public void SetUp()
        {
            sutStickyNotes = new StickyNotes.Lib.StickyNotes();
        }

        [Test]
        public void ShouldAddNoteToStickyNotes()
        {
            //Arrange
            Note note = new Note(new Date(), "Sample Note");

            //Act
            sutStickyNotes.AddNote(note);

            //Assert
            CollectionAssert.Contains(sutStickyNotes.NoteList, note);
        }

        [Test]
        public void ShouldNotBeEmpty()
        {
            //Arrange
            Note note = new Note(new Date(), "Sample Note");

            //Act
            sutStickyNotes.AddNote(note);

            //Assert
            CollectionAssert.IsNotEmpty(sutStickyNotes.NoteList);
        }
        [Test]
        public void ShouldRemoveNoteProperly()
        {
            //Arrange
            Note note1 = new Note(new Date(), "Sample Note 1");
            Note note2 = new Note(new Date(), "Sample Note 2");
            Note note3 = new Note(new Date(), "Sample Note 3");
            Note note4 = new Note(new Date(), "Sample Note 4");

            //Act
            sutStickyNotes.AddNote(note1);
            sutStickyNotes.AddNote(note2);
            sutStickyNotes.AddNote(note3);
            sutStickyNotes.RemoveNote(note2);
            sutStickyNotes.AddNote(note4);

            //Assert
            CollectionAssert.DoesNotContain(sutStickyNotes.NoteList, note2);
        }

        [Test]
        public void ShouldHaveAllElementsOfNoteType()
        {
            //Arrange
            Note note1 = new Note(new Date(), "Sample Note 1");
            Note note2 = new Note(new Date(), "Sample Note 2");
            Note note3 = new Note(new Date(), "Sample Note 3");

            //Act
            sutStickyNotes.AddNote(note1);
            sutStickyNotes.AddNote(note2);
            sutStickyNotes.AddNote(note3);
            sutStickyNotes.AddNote(note2);
            sutStickyNotes.AddNote(note3);

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(sutStickyNotes.NoteList, typeof(Note));
        }

        [Test]
        public void ShouldTakeLastNoteProperly()
        {
            //Arrange
            Note note1 = new Note(new Date(), "Sample Note 1");
            Note note2 = new Note(new Date(), "Sample Note 2");
            Note note3 = new Note(new Date(), "Sample Note 3");
            sutStickyNotes.AddNote(note1);
            sutStickyNotes.AddNote(note2);
            sutStickyNotes.AddNote(note3);

            //Act
            Note newestNote = sutStickyNotes.GetNewestNote();

            //Assert
            Assert.That(note3, Is.EqualTo(newestNote));
        }

        [TearDown]
        public void TearDown()
        {
            sutStickyNotes = null;
        }
    }
}
