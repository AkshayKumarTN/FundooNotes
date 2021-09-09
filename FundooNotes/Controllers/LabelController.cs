// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using FundooNotes.Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LabelController : ControllerBase
    {
        /// <summary>
        /// Label field of type ILable
        /// </summary>
        private readonly ILabelManager Label;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController" /> class.
        /// </summary>
        /// <param name="Label"></param>
        public LabelController(ILabelManager Label)
        {
            this.Label = Label;
        }

        /// <summary>
        /// Controller method to Create Label
        /// </summary>
        /// <param name="Label">Label name</param>
        /// <returns>API response</returns>
        [HttpPost]
        [Route("api/CreateLabel")]
        public IActionResult CreateLabel([FromBody] LabelModel Label)
        {
            try
            {
                var message = this.Label.CreateLabel(Label);
                if (message.Equals("New Label added Successfully"))
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Message = message, Data = Label });
                }

                return this.BadRequest(new ResponseModel<LabelModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LabelModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method to Update Label 
        /// </summary>
        /// <param name="Label">Label parameter</param>
        /// <returns>API response</returns>
        [HttpPut]
        [Route("api/UpdateLabel")]
        public IActionResult UpdateLabel([FromBody] LabelModel Label)
        {
            try
            {
                var message = this.Label.UpdateLabel(Label);
                if (message.Equals("Label updated Successfully"))
                {
                    return this.Ok(new ResponseModel<LabelModel>() { Status = true, Message = message, Data = Label });
                }

                return this.BadRequest(new ResponseModel<LabelModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LabelModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to delete Label
        /// </summary>
        /// <param name="id">Label id</param>
        /// <returns>API response</returns>
        [HttpDelete]
        [Route("api/RemoveLabel")]
        public IActionResult RemoveLabel(int labelId)
        {
            try
            {
                var message = this.Label.RemoveLabel(labelId);
                if (message.Equals("Label Removed Successfully"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = message, Data = labelId });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }

       
        /// <summary>
        /// Method to delete Label
        /// </summary>
        /// <param name="id">Label id</param>
        /// <returns>API response</returns>
        [HttpDelete]
        [Route("api/DeleteLabelFromUser")]
        public IActionResult DeleteLabelFromUser(int userId, string labelName)
        {
            try
            {
                var message = this.Label.DeleteLabelFromUser(userId, labelName);
                if (message.Equals("Label Deleted Successfully"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Label Deleted Successfully", Data = userId });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "Invalid Label Name" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to Retrieve Label By LableID
        /// </summary>
        /// <param name="labelId">Label ID</param>
        /// <returns>API response</returns>
        [HttpGet]
        [Route("api/GetLabelById")]
        public IActionResult GetLabelById(int userId)
        {
            try
            {
                var result = this.Label.GetLabelById(userId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<LabelModel>>() { Status = true, Message = "Label Retrieved", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<LabelModel>>() { Status = false, Message = "Unable to Retrieve Label" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<LabelModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to get Notes of Same lableName by its lableId
        /// </summary>
        /// <param name="lableId">label id</param>
        /// <returns>API response</returns>
        [HttpGet]
        [Route("api/RetriveNotesByLabelId")]
        public IActionResult RetriveNotesByLabelId(int lableId)
        {
            try
            {
                var result = this.Label.RetriveNotesByLabelId(lableId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Label Retrieved", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to Retrieve Label" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }
    }
}
