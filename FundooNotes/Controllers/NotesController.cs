using FundooNotes.Manager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
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
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Note Moved To Trash Successfully" });
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
        public IActionResult UpdateEmployeeDetails([FromBody] NotesModel note)
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
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Pinned  Successfully" });
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
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Archive  Successfully" });
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
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "UnArchive  Successfully" });
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
    }
}
