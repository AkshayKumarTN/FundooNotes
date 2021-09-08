// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Manager
{
    using FundooNotes.Manager.Interface;
    using FundooNotes.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// LableManager class implements ILableManager interface
    /// </summary>
    public class LableManager : ILableManager
    {
        /// <summary>
        /// lable reference variable of type ILableRepository
        /// </summary>
        private readonly ILableRepository lable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableManager" /> class.
        /// </summary>
        /// <param name="lable">ILableRepository</param>
        public LableManager(ILableRepository lable)
        {
            this.lable = lable;
        }

        /// <summary>
        /// CreateLable Method
        /// </summary>
        /// <param name="lable">EditLabelsModel</param>
        /// <returns></returns>
        public string CreateLable(LableModel lable)
        {
            string message = this.lable.CreateLable(lable);
            return message;
        }

        /// <summary>
        /// UpdateLable Method
        /// </summary>
        /// <param name="lable">EditLabelsModel</param>
        /// <returns>string</returns>
        public string UpdateLable(EditLabelsModel lable)
        {
            string message = this.lable.UpdateLable(lable);
            return message;
        }

        /// <summary>
        /// RemoveLable Method
        /// </summary>
        /// <param name="lableId">lableId</param>
        /// <returns>string</returns>
        public string RemoveLable(int lableId)
        {
            string message = this.lable.RemoveLable(lableId);
            return message;
        }

        /// <summary>
        /// GetLableById Method
        /// </summary>
        /// <param name="lableId">lableId</param>
        /// <returns>LableModel</returns>
        public IEnumerable<LableModel> GetLableById(int lableId)
        {
            var message = this.lable.GetLableById(lableId);
            return message;
        }

        /// <summary>
        /// Method to Retrive Lables By LableName 
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="lableName">lableName</param>
        /// <returns>LableModel</returns>
        public IEnumerable<LableModel> RetriveLablesByLableName(int userId, string lableName)
        {
            var message = this.lable.RetriveLablesByLableName(userId, lableName);
            return message;
        }

        /// <summary>
        /// DeleteLabelFromUser Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="labelName">labelName</param>
        /// <returns>boolean</returns>
        public bool DeleteLabelFromUser(int userId, string labelName)
        {
            var message = this.lable.DeleteLabelFromUser(userId, labelName);
            return message;
        }
    }
}
