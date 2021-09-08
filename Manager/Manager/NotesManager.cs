// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager
{
    using FundooNotes.Manager.Interface;
    using Microsoft.AspNetCore.Http;
    using Models;
    using Repository.Interface;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// NotesManager class implements INotesManager interface
    /// </summary>
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// notes reference variable of type INotesRepository
        /// </summary>
        private readonly INotesRepository notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager" /> class.
        /// </summary>
        /// <param name="notes">INotesRepository</param>
        public NotesManager(INotesRepository notes)
        {
            this.notes = notes;
        }

        /// <summary>
        /// AddNewNote Method 
        /// </summary>
        /// <param name="note">noteId</param>
        /// <returns>string</returns>
        public string AddNewNote(NotesModel note)
        {
            string message = this.notes.AddNewNote(note);
            return message;
        }

        /// <summary>
        /// DeleteNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNote(int noteId)
        {
            string note = this.notes.DeleteNote(noteId);
            return note;
        }

        /// <summary>
        /// DeleteNoteForever Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNoteForever(int noteId)
        {
            string note = this.notes.DeleteNoteForever(noteId);
            return note;
        }

        /// <summary>
        /// EmptyTrash Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>string</returns>
        public string EmptyTrash(int userId)
        {
            string note = this.notes.EmptyTrash(userId);
            return note;
        }

        /// <summary>
        /// RestoreNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string RestoreNote(int noteId)
        {
            string note = this.notes.RestoreNote(noteId);
            return note;
        }

        /// <summary>
        /// UpdateNote Method
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>string</returns>
        public string UpdateNote(NotesModel note)
        {
            string message = this.notes.UpdateNote(note);
            return message;
        }

        /// <summary>
        /// PinNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string PinNote(int noteId)
        {
            string message = this.notes.PinNote(noteId);
            return message;
        }

        /// <summary>
        /// UnPinNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnPinNote(int noteId)
        {
            string message = this.notes.UnPinNote(noteId);
            return message;
        }

        /// <summary>
        /// Archive Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string Archive(int noteId)
        {
            string message = this.notes.Archive(noteId);
            return message;
        }

        /// <summary>
        /// UnArchive Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnArchive(int noteId)
        {
            string message = this.notes.UnArchive(noteId);
            return message;
        }

        /// <summary>
        /// NoteColor Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="color">color</param>
        /// <returns>string</returns>
        public string NoteColor(int noteId, string color)
        {
            string message = this.notes.NoteColor(noteId, color);
            return message;
        }

        /// <summary>
        /// SetReminder Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="reminder">reminder</param>
        /// <returns>string</returns>
        public string SetReminder(int noteId, string reminder)
        {
            string message = this.notes.SetReminder(noteId, reminder);
            return message;
        }

        /// <summary>
        /// DeleteReminder Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteReminder(int noteId)
        {
            string message = this.notes.DeleteReminder(noteId);
            return message;
        }

        /// <summary>
        /// PinnedNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel list</returns>
        public List<NotesModel> PinnedNotes(int userId)
        {
            List<NotesModel> message = this.notes.PinnedNotes(userId);
            return message;
        }

        /// <summary>
        /// UnPinnedNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel list</returns>
        public List<NotesModel> UnPinnedNotes(int userId)
        {
            List<NotesModel> message = this.notes.UnPinnedNotes(userId);
            return message;
        }

        /// <summary>
        /// ArchiveNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel list</returns>
        public List<NotesModel> ArchiveNotes(int userId)
        {
            List<NotesModel> message = this.notes.ArchiveNotes(userId);
            return message;
        }

        /// <summary>
        /// TrashNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel list</returns>
        public List<NotesModel> TrashNotes(int userId)
        {
            List<NotesModel> message = this.notes.TrashNotes(userId);
            return message;
        }

        /// <summary>
        /// ReminderNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel list</returns>
        public List<NotesModel> ReminderNotes(int userId)
        {
            List<NotesModel> message = this.notes.ReminderNotes(userId);
            return message;
        }

        /// <summary>
        /// AddImage Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="image">image</param>
        /// <returns>boolean</returns>
        public bool AddImage(int noteId, IFormFile image)
        {
            try
            {
                bool message = this.notes.AddImage(noteId, image);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
