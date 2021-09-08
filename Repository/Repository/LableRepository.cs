﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

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
        /// Method to Remove Lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>string message</returns>
        public string RemoveLable(int lableId)
        {
            try
            {
                if (lableId > 0)
                {
                    var lable = this.userContext.Lables.Find(lableId);
                    var result = this.userContext.Lables.Where(x => x.UserId == lable.UserId && x.NotesId == null && x.Lable == lable.Lable).ToList();
                    if (result.Count > 0)
                    {
                        this.userContext.Lables.Remove(lable);
                        this.userContext.SaveChangesAsync();
                        return "Lable Removed Successfully";
                    }
                    else
                    {
                        lable.NotesId = null;
                        this.userContext.Entry(lable).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        return "Lable Removed Successfully";

                    }
                }

                return "Unable to Removed Lable";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get lable by its id
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>lable details</returns>
        public IEnumerable<LableModel> GetLableById(int lableId)
        {
            try
            {
                IEnumerable<LableModel> result;
                var lables = this.userContext.Lables.Where(x => x.LableId == lableId);
                if (lables != null)
                {
                    result = lables;
                    return result;
                }

                result = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<LableModel> RetriveLables(int userId)
        {
            try
            {
                IEnumerable<LableModel> result;
                var lables = this.userContext.Lables.Where(x => x.UserId == userId).ToList();
                if (lables != null)
                {
                    result = lables;
                    return result;
                }

                result = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteLabelFromUser(int userId, string labelName)
        {
            try
            {
                var getAllLabels = this.userContext.Lables.Where(x => x.UserId == userId && x.Lable.Equals(labelName)).ToList();
                if (getAllLabels != null)
                {
                    this.userContext.Lables.RemoveRange(getAllLabels);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
