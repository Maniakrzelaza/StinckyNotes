using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.Lib
{
    public class Note
    {
        public Date DayDate { get; set; }
        public String NoteValue { get; set; }

        public Note(Date date, String note)
        {
            this.DayDate = date;
            this.NoteValue = note;
        }

        public Note(Date date) : this(date, "")
        {
        }

        public override String ToString()
        {
            return this.DayDate.ToString() + " " + this.NoteValue;
        }
    }
}
