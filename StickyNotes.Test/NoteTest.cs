using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using StickyNotes.Lib;

namespace StickyNotes.Test
{
    class NoteTest
    {
        private Note sutDay;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ShouldAddNoteProperly()
        {
            Date date = new Date("yyyy-mm-dd");
            date.ChangeDate("1994-07-01");

            sutDay = new Note(date, "Test Note String");
            StringAssert.AreEqualIgnoringCase("1994-07-01 Test Note String", sutDay.ToString());
        }

        [Test]
        public void ShouldContainNote()
        {
            Date date = new Date("yyyy-mm-dd");
            date.ChangeDate("1994-07-01");
            sutDay = new Note(date, "Test Note String");
            StringAssert.Contains("Note", sutDay.ToString());
        }

        [Test]
        public void ShouldEndsWithRing()
        {
            Date date = new Date("yyyy-mm-dd");
            date.ChangeDate("1994-07-01");
            sutDay = new Note(date, "Test Note String");
            StringAssert.EndsWith("ring", sutDay.ToString());
        }

        [TearDown]
        public void TearDown()
        {
            sutDay = null;
        }
    }
}
