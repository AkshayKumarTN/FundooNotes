// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;
    

    /// <summary>
    /// LableRepository Class
    /// </summary>
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// Field userContext of type UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableRepository" /> class.
        /// </summary>
        /// <param name="userContext">UserContext</param>
        public LabelRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to Create/Add New Label
        /// </summary>
        /// <param name="Label"></param>
        /// <returns></returns>
        public string CreateLabel(LabelModel label)
        {
            try
            {
                string message;
                if (label.NoteId == null)
                {
                    var result = this.userContext.Labels.Where(x => x.LabelName == label.LabelName && x.UserId == label.UserId && x.NoteId == null).SingleOrDefault();
                    if (result == null)
                    {
                        this.userContext.Labels.Add(label);
                        this.userContext.SaveChanges();
                        message = "New Label added Successfully";
                        return message;
                    }
                    message = "Failed to Add New Label to Database";
                    return message;
                }
                else
                {
                    var result = this.userContext.Labels.Where(x => x.LabelName == label.LabelName && x.UserId == label.UserId && x.NoteId == label.NoteId).SingleOrDefault();                   
                    
                    if (result == null)
                    {
                        this.userContext.Labels.Add(label);
                        this.userContext.SaveChanges();
                        label.NoteId = null;
                        label.LabelId = 0;
                        this.userContext.Labels.Add(label);
                        this.userContext.SaveChanges();
                        message = "New Label added Successfully";
                        return message;
                    }
                    message = "Failed to Add New Label to Database";
                    return message;
                }               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to update Label
        /// </summary>
        /// <param name="Label">Label parameter</param>
        /// <returns>string message</returns>
        public string UpdateLabel(LabelModel Label)
        {
            try
            {

                var result1 = this.userContext.Labels.Where(x => x.UserId == Label.UserId && x.LabelId == Label.LabelId && x.NoteId == null).SingleOrDefault();
                var labelList = this.userContext.Labels.Where(x => x.LabelName == result1.LabelName && x.UserId == result1.UserId).ToList();
                var result2 = this.userContext.Labels.Where(x => x.LabelName == Label.LabelName && x.UserId == Label.UserId && x.NoteId == null).SingleOrDefault();
                if (labelList.Count > 0)
                {
                    if(result2 != null)
                    {
                        var RemoveLabel = this.userContext.Labels.Find(Label.LabelId);
                        labelList.Remove(RemoveLabel);
                        this.userContext.Labels.Remove(RemoveLabel);
                        this.userContext.SaveChanges();
                    }
                    foreach (var i in labelList)
                    {
                        i.LabelName = Label.LabelName;
                    }
                    this.userContext.Labels.UpdateRange(labelList);
                    this.userContext.SaveChanges();
                    return "Label updated Successfully";
                }

                return "Label update Unsuccessfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Remove Label
        /// </summary>
        /// <param name="id">Label id</param>
        /// <returns>string message</returns>
        public string RemoveLabel(int labelId)
        {
            try
            {

                var Label = this.userContext.Labels.Find(labelId);
                if (Label != null)
                {
                    var result = this.userContext.Labels.Where(x => x.UserId == Label.UserId && x.NoteId == null && x.LabelName == Label.LabelName).ToList();
                    this.userContext.Labels.Remove(Label);
                    this.userContext.SaveChangesAsync();
                    return "Label Removed Successfully";
                }
                return "Unable to Removed Label";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get Label by its id
        /// </summary>
        /// <param name="id">Label id</param>
        /// <returns>Label details</returns>
        public IEnumerable<LabelModel> GetLabelById(int userId)
        {
            try
            {
                IEnumerable<LabelModel> result;
                var Labels = this.userContext.Labels.Where(x => x.UserId == userId && x.NoteId == null);
                if (Labels != null)
                {
                    result = Labels;
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

        /// <summary>
        /// Method to get Notes of Same lableName by its lableId
        /// </summary>
        /// <param name="lableId">label id</param>
        /// <returns>Notes</returns>
        public IEnumerable<NotesModel> RetriveNotesByLabelId(int lableId)
        {
            try
            {
                IEnumerable<NotesModel> result;
                var lable = this.userContext.Labels.Where(x => x.LabelId == lableId).SingleOrDefault();
                var labeledNotes = (from n in this.userContext.FundooNotes
                                    join l in this.userContext.Labels
                                    on n.NoteId equals l.NoteId
                                    where l.LabelName == lable.LabelName && l.UserId == lable.UserId
                                    select n).ToList();
                if (labeledNotes.Count > 0)
                {
                    return labeledNotes;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DeleteLabel From User Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="labelName">labelName</param>
        /// <returns>Returns boolean</returns>
        public bool DeleteLabelFromUser(int userId, string labelName)
        {
            try
            {
                var getAllLabels = this.userContext.Labels.Where(x => x.UserId == userId && x.LabelName.Equals(labelName)).ToList();
                if (getAllLabels != null)
                {
                    this.userContext.Labels.RemoveRange(getAllLabels);
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
