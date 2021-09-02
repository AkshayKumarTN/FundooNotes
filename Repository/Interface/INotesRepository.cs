namespace FundooNotes.Repository.Interface
{
    using Models;
    public interface INotesRepository
    {
        public string AddNewNote(NotesModel note);
        public string DeleteNote(int noteId);
        public string DeleteNoteForever(int noteId);
        public string UpdateNote(NotesModel note);
        public string PinNotes(int noteId);
        public string UnPinNotes(int noteId);
        public string Archive(int noteId);
        public string UnArchive(int noteId);
        public string NoteColor(int noteId, string color);
        public string SetReminder(int noteId, string reminder);
        public string DeleteReminder(int noteId);
        public string RestoreNote(int noteId);
    }
}
