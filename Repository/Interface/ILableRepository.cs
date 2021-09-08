// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ILableRepository interface
    /// </summary>
    public interface ILableRepository
    {
        /// <summary>
        /// CreateLable Method Declaration
        /// </summary>
        /// <param name="lable">LableModel</param>
        /// <returns>string</returns>
        public string CreateLable(LableModel lable);

        /// <summary>
        /// UpdateLable Method Declaration
        /// </summary>
        /// <param name="lable">EditLabelsModel</param>
        /// <returns>string</returns>
        public string UpdateLable(EditLabelsModel lable);

        /// <summary>
        /// RemoveLable Method Declaration
        /// </summary>
        /// <param name="lableId">lableId</param>
        /// <returns>string</returns>
        public string RemoveLable(int lableId);

        /// <summary>
        /// GetLableById Method Declaration
        /// </summary>
        /// <param name="lableId">lableId</param>
        /// <returns>LableModel</returns>
        public IEnumerable<LableModel> GetLableById(int lableId);

        /// <summary>
        /// RetriveLables Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>LableModel</returns>
        public IEnumerable<LableModel> RetriveLables(int userId);

        /// <summary>
        /// DeleteLabelFromUser Method Declaration
        /// </summary>
        /// <param name="userId">userId</param>
        /// <param name="labelName">labelName</param>
        /// <returns>Boolean</returns>
        bool DeleteLabelFromUser(int userId, string labelName);
    }
}
