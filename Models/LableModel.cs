﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using FundooNotes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class LableModel
    {
        [Key]
        public int LableId { get; set; }
        public string Lable { get; set; }

        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }

        [ForeignKey("NotesModel")]
        public int? NotesId { get; set; }
        public virtual NotesModel NotesModel { get; set; }
    }
}