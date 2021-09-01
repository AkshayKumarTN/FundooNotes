namespace FundooNotes.Repository.Interface
{
    using Models;
    public interface INotesRepository
    {
        public string AddNewNote(NotesModel note);
    }
}
