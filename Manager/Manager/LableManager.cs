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

    public class LableManager : ILableManager
    {
        private readonly ILableRepository lable;

        public LableManager(ILableRepository lable)
        {
            this.lable = lable;
        }

        public string CreateLable(LableModel lable)
        {
            string message = this.lable.CreateLable(lable);
            return message;
        }

        public string UpdateLable(LableModel lable)
        {
            string message = this.lable.UpdateLable(lable);
            return message;
        }
    }
}
