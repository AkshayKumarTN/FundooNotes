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
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// label reference variable of type ILableRepository
        /// </summary>
        private readonly ILabelRepository label;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager" /> class.
        /// </summary>
        /// <param name="label">ILableRepository</param>
        public LabelManager(ILabelRepository label)
        {
            this.label = label;
        }

        /// <summary>
        /// CreateLabel Method
        /// </summary>
        /// <param name="label">LabelModel</param>
        /// <returns></returns>
        public string CreateLabel(LabelModel label)
        {
            string message = this.label.CreateLabel(label);
            return message;
        }

        /// <summary>
        /// UpdateLabel Method
        /// </summary>
        /// <param name="label">LabelModel</param>
        /// <returns>string</returns>
        public string UpdateLabel(LabelModel label)
        {
            string message = this.label.UpdateLabel(label);
            return message;
        }

        /// <summary>
        /// RemoveLabel Method
        /// </summary>
        /// <param name="labelId">labelId</param>
        /// <returns>string</returns>
        public string RemoveLabel(int labelId)
        {
            string message = this.label.RemoveLabel(labelId);
            return message;
        }

        /// <summary>
        /// GetLabelById Method
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>LabelModel</returns>
        public IEnumerable<LabelModel> GetLabelById(int userId)
        {
            var message = this.label.GetLabelById(userId);
            return message;
        }

        /// <summary>
        /// Method to get Notes of Same lableName by its lableId
        /// </summary>
        /// <param name="lableId">label id</param>
        /// <returns>Notes</returns>
        public IEnumerable<NotesModel> RetriveNotesByLabelId(int lableId)
        {
            var message = this.label.RetriveNotesByLabelId(lableId);
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
            var message = this.label.DeleteLabelFromUser(userId, labelName);
            return message;
        }
    }
}
