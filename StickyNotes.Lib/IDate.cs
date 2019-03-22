using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes.Lib
{
    interface IDate
    {
        void ChangeDate(String date);
        bool IsLeaterThanNow();
        void ChangeDateFormat(String format);
        void ChangeDelimiter(Char delimiter);
    }
}
