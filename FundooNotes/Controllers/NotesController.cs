// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    

    [Authorize]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// Field 'notes' of type INotesManager
        /// </summary>
        private readonly INotesManager notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController" /> class.
        /// </summary>
        /// <param name="notes">INotesManager</param>
        public NotesController(INotesManager notes)
        {
            this.notes = notes;
        }

        /// <summary>
        /// Notes Controller
        /// </summary>
        /// <param name="notes">new notes</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("api/AddNewNote")]
        public IActionResult AddNewNote([FromBody] NotesModel notes)
        {
            var result = this.notes.AddNewNote(notes);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "New Note added Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Add New Note to Database" });
            }
        }

        /// <summary>
        /// DeleteNote
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult DeleteNote(int noteId)
        {
            var result = this.notes.DeleteNote(noteId);
            if (result.Equals("Note unpinned and trashed") || result.Equals("Note trashed"))
            {
                return this.Ok(new { success = true, Message = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// DeleteNoteForever
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("api/DeleteNoteForever")]
        public IActionResult DeleteNoteForever(int noteId)
        {
            var result = this.notes.DeleteNoteForever(noteId);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Note Deleted Forever Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// EmptyTrash
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("api/EmptyTrash")]
        public IActionResult EmptyTrash(int userId)
        {
            var result = this.notes.EmptyTrash(userId);
            if (result.Equals("All notes in Trash permanently deleted") || result.Equals("No notes in Trash"))
            {
                return this.Ok(new { success = true, Message = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// RestoreNote
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/RestoreNote")]
        public IActionResult RestoreNote(int noteId)
        {
            var result = this.notes.RestoreNote(noteId);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Note Restored Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// UpdateNote
        /// </summary>
        /// <param name="note">NotesModel</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/UpdateNote")]
        public IActionResult UpdateNote([FromBody] NotesModel note)
        {
            var result = this.notes.UpdateNote(note);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Note updated Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Error While updating note" });
            }
        }

        /// <summary>
        /// PinNote
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/PinNote")]
        public IActionResult PinNote(int noteId)
        {
            var result = this.notes.PinNote(noteId);
            if (result.Equals("Note unarchived and pinned") || result.Equals("Note pinned"))
            {
                return this.Ok(new { success = true, Message = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// UnPinNote
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/UnPinNote")]
        public IActionResult UnPinNote(int noteId)
        {
            var result = this.notes.UnPinNote(noteId);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "UnPinned  Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// Archive
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/Archive")]
        public IActionResult Archive(int noteId)
        {
            var result = this.notes.Archive(noteId);
            if (result.Equals("Note unpinned and archived") || result.Equals("Note archived"))
            {
                return this.Ok(new { success = true, Message = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// UnArchive
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/UnArchive")]
        public IActionResult UnArchive(int noteId)
        {
            var result = this.notes.UnArchive(noteId);
            if (result.Equals("Note unarchived"))
            {
                return this.Ok(new { success = true, Message = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// Set NoteColor
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="color">color</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/NoteColor")]
        public IActionResult NoteColor(int noteId, string color)
        {
            var result = this.notes.NoteColor(noteId, color);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "NoteColor Changed Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// SetReminder
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <param name="reminder"></param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/SetReminder")]
        public IActionResult SetReminder(int noteId, string reminder)
        {
            var result = this.notes.SetReminder(noteId, reminder);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Reminder Set Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// DeleteReminder
        /// </summary>
        /// <param name="noteId">noteId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/DeleteReminder")]
        public IActionResult DeleteReminder(int noteId)
        {
            var result = this.notes.DeleteReminder(noteId);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Reminder Deleted Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "Invalid NoteId" });
            }
        }

        /// <summary>
        /// Get PinnedNotes
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/PinnedNotes")]
        public IActionResult PinnedNotes(int userId)
        {
            var result = this.notes.PinnedNotes(userId);
            if (result.Count > 0)
            {
                return this.Ok(new { success = true, Message = "Retrieved Pinned Notes Successfully", Data=result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "No Pinned Notes" });
            }
        }

        /// <summary>
        /// Get UnPinnedNotes
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/UnPinnedNotes")]
        public IActionResult UnPinnedNotes(int userId)
        {
            var result = this.notes.UnPinnedNotes(userId);
            if (result.Count > 0)
            {
                return this.Ok(new { success = true, Message = "Retrieved UnPinned Notes Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "No UnPinned Notes" });
            }
        }

        /// <summary>
        /// Get ArchiveNotes
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/ArchiveNotes")]
        public IActionResult ArchiveNotes(int userId)
        {
            var result = this.notes.ArchiveNotes(userId);
            if (result.Count > 0)
            {
                return this.Ok(new { success = true, Message = "Retrieved Archive Notes Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "No Archive Notes" });
            }
        }

        /// <summary>
        /// Get TrashNotes
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/TrashNotes")]
        public IActionResult TrashNotes(int userId)
        {
            var result = this.notes.TrashNotes(userId);
            if (result.Count > 0)
            {
                return this.Ok(new { success = true, Message = "Retrieved Trash Notes Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "No Trash Notes" });
            }
        }

        /// <summary>
        /// GET ReminderNotes
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/ReminderNotes")]
        public IActionResult ReminderNotes(int userId)
        {
            var result = this.notes.ReminderNotes(userId);
            if (result.Count > 0)
            {
                return this.Ok(new { success = true, Message = "Retrieved Reminder Notes Successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = true, Message = "No Reminder Notes" });
            }
        }

        /// <summary>
        /// AddImage method to add image for Note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="image">selected image</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("addImage")]
        public IActionResult AddImage(int noteId, IFormFile image)
        {
            try
            {
                var result = this.notes.AddImage(noteId, image);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Image Added Successfully", Data = noteId });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "Adding Image Unsuccessfully" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }
    }
}
