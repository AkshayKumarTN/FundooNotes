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
    public interface ILableRepository
    {
        public string CreateLable(LableModel lable);
        public string UpdateLable(EditLabelsModel lable);
        public string RemoveLable(int lableId);
        public IEnumerable<LableModel> GetLableById(int lableId);
        public IEnumerable<LableModel> RetriveLables(int userId);
        bool DeleteLabelFromUser(int userId, string labelName);
    }
}
