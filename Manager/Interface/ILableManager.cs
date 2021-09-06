// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILableManager
    {
        public string CreateLable(LableModel lable);
        public string UpdateLable(LableModel lable);
    }
}
