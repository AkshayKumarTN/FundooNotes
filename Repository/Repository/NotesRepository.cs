namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddNewNote(NotesModel note)
        {
            this.userContext.FundooNotes.Add(note);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string DeleteNote(int noteId)
        {
            try
            {
                string result = "UNSUCCESS";
                 var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Trash = true;
                    note.Reminder = null;
                    if(note.Pin == true)
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

        public string RestoreNote(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
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

        public string UpdateNote(NotesModel note)
        {
            if (note.NotesId != 0)
            {
                userContext.Entry(note).State = EntityState.Modified;
            }
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string PinNote(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Pin = true;
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

        public string UnPinNote(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
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

        public string Archive(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Archieve = true;
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

        public string UnArchive(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
                if (note != null)
                {
                    note.Archieve = false;
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

        public string NoteColor(int noteId, string color)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
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

        public string SetReminder(int noteId, string reminder)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
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

        public string DeleteReminder(int noteId)
        {
            try
            {
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == noteId).SingleOrDefault();
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

        public List<NotesModel> PinnedNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Pin==true && x.Trash == false && x.Archieve == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<NotesModel> UnPinnedNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Pin==false && x.Trash == false && x.Archieve == false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public List<NotesModel> ReminderNotes(int userId)
        {
            try
            {
                var notes = this.userContext.FundooNotes.Where(x => x.UserId == userId && x.Reminder !=null && x.Trash==false).ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
