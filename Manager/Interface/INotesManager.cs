// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Interface
{
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// INotesManager interface
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// AddNewNote Method Declaration
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>string</returns>
        public string AddNewNote(NotesModel note);

        /// <summary>
        /// DeleteNote Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNote(int noteId);

        /// <summary>
        /// DeleteNoteForever Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNoteForever(int noteId);

        /// <summary>
        /// EmptyTrash Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>string</returns>
        public string EmptyTrash(int userId);

        /// <summary>
        /// UpdateNote Method Declaration
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>string</returns>
        public string UpdateNote(NotesModel note);

        /// <summary>
        /// PinNote Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string PinNote(int noteId);

        /// <summary>
        /// UnPinNote Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnPinNote(int noteId);

        /// <summary>
        /// Archive Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string Archive(int noteId);

        /// <summary>
        /// UnArchive Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnArchive(int noteId);

        /// <summary>
        /// NoteColor Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="color">color</param>
        /// <returns>string</returns>
        public string NoteColor(int noteId, string color);

        /// <summary>
        /// SetReminder Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="reminder">reminder</param>
        /// <returns>string</returns>
        public string SetReminder(int noteId, string reminder);

        /// <summary>
        /// DeleteReminder Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteReminder(int noteId);

        /// <summary>
        /// RestoreNote Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string RestoreNote(int noteId);

        /// <summary>
        /// AddImage Method Declaration
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="image">IFormFile</param>
        /// <returns>Boolean</returns>
        public bool AddImage(int noteId, IFormFile image);

        /// <summary>
        /// PinnedNotes Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> PinnedNotes(int userId);

        /// <summary>
        /// UnPinnedNotes Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> UnPinnedNotes(int userId);

        /// <summary>
        /// ArchiveNotes Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> ArchiveNotes(int userId);

        /// <summary>
        /// TrashNotes Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> TrashNotes(int userId);

        /// <summary>
        /// ReminderNotes Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> ReminderNotes(int userId);

    }
}
