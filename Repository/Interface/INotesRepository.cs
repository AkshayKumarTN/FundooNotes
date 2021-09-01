namespace FundooNotes.Repository.Interface
{
    using Models;
    public interface INotesRepository
    {
        public string AddNewNote(NotesModel note);
        public string RemoveNote(int id);
        public string UpdateNote(NotesModel note);
    }
}
