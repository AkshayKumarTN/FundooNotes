// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// NotesRepository Class
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// Field userContext of type userContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Field configuration of type IConfiguration
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository" /> class.
        /// </summary>
        /// <param name="userContext">UserContext</param>
        /// <param name="configuration">IConfiguration</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// AddNewNote Method
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>string</returns>
        public string AddNewNote(NotesModel note)
        {
            this.userContext.FundooNotes.Add(note);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        /// <summary>
        /// DeleteNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNote(int noteId)
        {
            try
            {
                string result = "UNSUCCESS";
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Trash = true;
                    note.Reminder = null;
                    if (note.Pin == true)
                    {
                        note.Pin = false;
                        result = "Note unpinned and trashed";
                    }
                    else
                    {
                        result = "Note trashed";
                    }
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// DeleteNoteForever Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteNoteForever(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Find(noteId);
                this.userContext.FundooNotes.Remove(note);
                this.userContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// EmptyTrash Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>string</returns>
        public string EmptyTrash(int userId)
        {
            try
            {
                string result = "UNSUCCESS";
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                if (notes.Count != 0)
                {
                    this.userContext.FundooNotes.RemoveRange(notes);
                    this.userContext.SaveChangesAsync();
                    result = "All notes in Trash permanently deleted";
                }
                else
                {
                    result = "No notes in Trash";
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// RestoreNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string RestoreNote(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Trash = false;
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return "SUCCESS";
                }
                return "UNSUCCESS";
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// UpdateNote Method
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>string</returns>
        public string UpdateNote(NotesModel note)
        {
            if (note.NoteId != 0)
            {
                userContext.Entry(note).State = EntityState.Modified;
            }
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        /// <summary>
        /// PinNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string PinNote(int noteId)
        {
            try
            {
                string result = "UNSUCCESS";
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Pin = true;
                    if (note.Archieve == true)
                    {
                        note.Archieve = false;
                        result = "Note unarchived and pinned";
                    }
                    else
                    {
                        result = "Note pinned";
                    }
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnPinNote Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnPinNote(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Pin = false;
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return "SUCCESS";
                }
                return "UNSUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archive Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string Archive(int noteId)
        {
            try
            {
                string result = "UNSUCCESS";
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Archieve = true;
                    if (note.Pin == true)
                    {
                        note.Pin = false;
                        result = "Note unpinned and archived";
                    }
                    else
                    {
                        result = "Note archived";
                    }
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnArchive Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string UnArchive(int noteId)
        {
            try
            {
                string result = "UNSUCCESS";
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Archieve = false;
                    result = "Note unarchived";
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// NoteColor Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="color">color</param>
        /// <returns>string</returns>
        public string NoteColor(int noteId, string color)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Color = color;
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return "SUCCESS";
                }
                return "UNSUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// SetReminder Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="reminder">reminder</param>
        /// <returns>string</returns>
        public string SetReminder(int noteId, string reminder)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Reminder = reminder;
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return "SUCCESS";
                }
                return "UNSUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DeleteReminder Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>string</returns>
        public string DeleteReminder(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Reminder = null;
                    this.userContext.FundooNotes.Update(note);
                    this.userContext.SaveChanges();
                    return "SUCCESS";
                }
                return "UNSUCCESS";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// PinnedNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> PinnedNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Pin == true && x.Trash == false && x.Archieve == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UnPinnedNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> UnPinnedNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Pin == false && x.Trash == false && x.Archieve == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ArchiveNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> ArchiveNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Archieve == true && x.Trash == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// TrashNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> TrashNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ReminderNotes Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>NotesModel List</returns>
        public List<NotesModel> ReminderNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Reminder != null && x.Trash == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// AddImage Method
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="image">IFormFile</param>
        /// <returns>boolean</returns>
        public bool AddImage(int noteId, IFormFile image)
        {
            try
            {
                bool result;
                var note = this.userContext.FundooNotes.Find(noteId);
                if (note != null)
                {
                    Account account = new Account(
                        configuration["CloudinaryAccount:CloudName"],
                        configuration["CloudinaryAccount:ApiKey"],
                        configuration["CloudinaryAccount:ApiSecret"]
                    );
                    var path = image.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    note.Image = uploadResult.Url.ToString();
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    result = true;
                    return result;
                }

                result = false;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
