using FundooNotes.Manager.Interface;
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
        [Route("api/NewNotes")]
        public IActionResult Notes([FromBody] NotesModel notes)
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
        public IActionResult RemoveEmployeeById(int id)
        {
            var result = this.notes.RemoveNote(id);
            if (result.Equals("Note Deleted Successfully"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
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
    }
}
