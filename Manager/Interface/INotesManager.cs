namespace FundooNotes.Manager.Interface
{
    using Models;
    public interface INotesManager
    {
        public string AddNewNote(NotesModel note);
        public string RemoveNote(int id);
        public string UpdateNote(NotesModel note);
    }
}
