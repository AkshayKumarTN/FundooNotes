using FundooNotes.Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notes;

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
