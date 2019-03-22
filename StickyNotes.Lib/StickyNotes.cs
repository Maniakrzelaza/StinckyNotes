using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.Lib
{
    public class StickyNotes
    {
        public LinkedList<Note> NoteList { get; set; }

        public StickyNotes()
        {
            this.NoteList = new LinkedList<Note>();
        }

        public void AddNote(Note note)
        {
            this.NoteList.AddLast(note);
        }

        public void RemoveNote(Note note)
        {
            this.NoteList.Remove(note);
        }
        public Note GetNewestNote()
        {
            return NoteList.Last.Value;
        }

    }
}
