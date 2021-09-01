namespace FundooNotes.Manager
{
    using FundooNotes.Manager.Interface;
    using Models;
    using Repository.Interface;

    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notes;

        public NotesManager(INotesRepository notes)
        {
            this.notes = notes;
        }

        public string AddNewNote(NotesModel note)
        {
            string message = this.notes.AddNewNote(note);
            return message;
        }

        public string RemoveNote(int id)
        {
            string note = this.notes.RemoveNote(id);
            return note;
        }
    }
}
