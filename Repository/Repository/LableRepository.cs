// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------


namespace FundooNotes.Repository.Repository
{
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Web.Mvc;

    [Authorize]
    public class LableRepository : ILableRepository
    {
        private readonly UserContext userContext;

        public LableRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to Create/Add New Lable
        /// </summary>
        /// <param name="lable"></param>
        /// <returns></returns>
        public string CreateLable(LableModel lable)
        {
            try
            {
                string message;
                if (lable != null)
                {
                    this.userContext.Lables.Add(lable);
                    this.userContext.SaveChanges();
                    message = "New Lable added Successfully";
                    return message;
                }

                message = "Failed to Add New Lable to Database";
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to update lable
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>string message</returns>
        public string UpdateLable(LableModel lable)
        {
            try
            {
                string message;
                if (lable.LableId != 0)
                {
                    this.userContext.Entry(lable).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "Lable updated Successfully";
                    return message;
                }

                return message = "Lable update Unsuccessfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Delete Lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>string message</returns>
        public string DeleteLable(int lableId)
        {
            try
            {
                if (lableId > 0)
                {
                    var lable = this.userContext.Lables.Find(lableId);
                    this.userContext.Lables.Remove(lable);
                    this.userContext.SaveChangesAsync();
                    return "Lable Deleted Successfully";
                }

                return "Unable to Delete Lable";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
