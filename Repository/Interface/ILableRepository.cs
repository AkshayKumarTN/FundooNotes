﻿// --------------------------------------------------------------------------------------------------------------------
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
        public string UpdateLable(LableModel lable);
        public string DeleteLable(int lableId);
    }
}