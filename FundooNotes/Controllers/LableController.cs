// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
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

    ///[Authorize]
    public class LableController : ControllerBase
    {
        /// <summary>
        /// lable field of type ILable
        /// </summary>
        private readonly ILableManager lable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController" /> class.
        /// </summary>
        /// <param name="lable"></param>
        public LableController(ILableManager lable)
        {
            this.lable = lable;
        }

        /// <summary>
        /// Controller method to Create lable
        /// </summary>
        /// <param name="lable">lable name</param>
        /// <returns>API response</returns>
        [HttpPost]
        [Route("api/CreateLable")]
        public IActionResult CreateLable([FromBody] LableModel lable)
        {
            try
            {
                var message = this.lable.CreateLable(lable);
                if (message.Equals("New Lable added Successfully"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = message, Data = lable });
                }

                return this.BadRequest(new ResponseModel<LableModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LableModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method to Update Lable 
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>API response</returns>
        [HttpPut]
        [Route("api/UpdateLable")]
        public IActionResult UpdateLable([FromBody] LableModel lable)
        {
            try
            {
                var message = this.lable.UpdateLable(lable);
                if (message.Equals("Lable updated Successfully"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = message, Data = lable });
                }

                return this.BadRequest(new ResponseModel<LableModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LableModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to delete lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>API response</returns>
        [HttpDelete]
        [Route("api/RemoveLable")]
        public IActionResult RemoveLable(int lableId)
        {
            try
            {
                var message = this.lable.DeleteLable(lableId);
                if (message.Equals("Lable Deleted Successfully"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = message, Data = lableId });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }
    }
}
