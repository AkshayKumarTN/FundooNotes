namespace FundooNotes.Repository.Interface
{
    using Models;
    public interface INotesRepository
    {
        public string AddNewNote(NotesModel note);
        public string RemoveNote(int id);
        public string UpdateNote(NotesModel note);
        public string PinNotes(int noteId);
        public string UnPinNotes(int noteId);
        public string Archive(int noteId);
        public string UnArchive(int noteId);
    }
}
