// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ILableManager interface
    /// </summary>
    public interface ILabelManager
    {
        /// <summary>
        /// CreateLabel Method Declaration
        /// </summary>
        /// <param name="label">LabelModel</param>
        /// <returns>string</returns>
        public string CreateLabel(LabelModel label);

        /// <summary>
        /// UpdateLabel Method Declaration
        /// </summary>
        /// <param name="label">LabelModel</param>
        /// <returns>string</returns>
        public string UpdateLabel(LabelModel label);

        /// <summary>
        /// RemoveLabel Method Declaration
        /// </summary>
        /// <param name="labelId">labelId</param>
        /// <returns>string</returns>
        public string RemoveLabel(int labelId);

        /// <summary>
        /// GetLabelById Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>LabelModel</returns>
        public IEnumerable<LabelModel> GetLabelById(int userId);

        /// <summary>
        /// Method to get Notes of Same lableName by its lableId
        /// </summary>
        /// <param name="lableId">label id</param>
        /// <returns>Notes</returns>
        public IEnumerable<NotesModel> RetriveNotesByLabelId(int lableId);

        /// <summary>
        /// DeleteLabelFromUser Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="labelName">labelName</param>
        /// <returns>Boolean</returns>
        bool DeleteLabelFromUser(int userId, string labelName);
    }
}
