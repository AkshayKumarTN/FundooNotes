﻿namespace FundooNotes.Manager.Interface
{
    using Models;
    public interface INotesManager
    {
        public string AddNewNote(NotesModel note);
        public string DeleteNote(int noteId);
        public string DeleteNoteForever(int noteId);
        public string UpdateNote(NotesModel note);
        public string PinNote(int noteId);
        public string UnPinNote(int noteId);
        public string Archive(int noteId);
        public string UnArchive(int noteId);
        public string NoteColor(int noteId, string color);
        public string SetReminder(int noteId, string reminder);
        public string DeleteReminder(int noteId);
        public string RestoreNote(int noteId);

    }
}
