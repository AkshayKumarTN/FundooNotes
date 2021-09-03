namespace FundooNotes.Repository.Interface
{
    using Models;
    using System.Collections.Generic;

    public interface INotesRepository
    {
        public string AddNewNote(NotesModel note);
        public string DeleteNote(int noteId);
        public string DeleteNoteForever(int noteId);
        public string EmptyTrash(int userId);
        public string UpdateNote(NotesModel note);
        public string PinNote(int noteId);
        public string UnPinNote(int noteId);
        public string Archive(int noteId);
        public string UnArchive(int noteId);
        public string NoteColor(int noteId, string color);
        public string SetReminder(int noteId, string reminder);
        public string DeleteReminder(int noteId);
        public string RestoreNote(int noteId);
        public List<NotesModel> PinnedNotes(int userId);
        public List<NotesModel> UnPinnedNotes(int userId);
        public List<NotesModel> ArchiveNotes(int userId);
        public List<NotesModel> TrashNotes(int userId);
        public List<NotesModel> ReminderNotes(int userId);
    }
}
