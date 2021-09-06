// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Manager.Interface;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// CollaboratorController Class
    /// </summary>
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// AddCollaborator method to Add collaborator
        /// </summary>
        /// <param name="collaboraters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/AddCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorsModel collaboraters)
        {
            try
            {
                var message = this.collaboratorManager.AddCollaborator(collaboraters);
                if (message.Equals("New Collaborator added Successfully !"))
                {
                    return this.Ok(new ResponseModel<CollaboratorsModel>() { Status = true, Message = message, Data = collaboraters });
                }

                return this.BadRequest(new ResponseModel<CollaboratorsModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<CollaboratorsModel>() { Status = false, Message = ex.Message });
            }
        }


        /// <summary>
        /// RemoveCollaborator method to Remove collaborator
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("api/RemoveCollaborator")]
        public IActionResult RemoveCollaborator(int collaboratorId)
        {
            try
            {
                var result = this.collaboratorManager.DeleteCollaborator(collaboratorId);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Collaborator Deleted Successfully !", Data = collaboratorId });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "Unable to delete this Collaborator." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }
    }
}
