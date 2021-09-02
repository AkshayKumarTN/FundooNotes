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

        public string RemoveNote(int noteId)
        {
            string note = this.notes.RemoveNote(noteId);
            return note;
        }

        public string UpdateNote(NotesModel note)
        {
            string message = this.notes.UpdateNote(note);
            return message;
        }

        public string PinNotes(int noteId)
        {
            string message = this.notes.PinNotes(noteId);
            return message;
        }
        public string UnPinNotes(int noteId)
        {
            string message = this.notes.UnPinNotes(noteId);
            return message;
        }
        public string Archive(int noteId)
        {
            string message = this.notes.Archive(noteId);
            return message;
        }
        public string UnArchive(int noteId)
        {
            string message = this.notes.UnArchive(noteId);
            return message;
        }
    }
}
