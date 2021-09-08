// --------------------------------------------------------------------------------------------------------------------
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

    /// <summary>
    /// LableModel Class
    /// </summary>
    public class LableModel
    {
        /// <summary>
        /// Gets or sets Field 'LableId' of type integer
        /// </summary>
        [Key]
        public int LableId { get; set; }

        /// <summary>
        /// Gets or sets Field 'Lable' of type string
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// Gets or sets Field 'UserId' of type integer
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Field 'RegisterModel' of type RegisterModel
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets Field 'NotesId' of type integer
        /// </summary>
        [ForeignKey("NotesModel")]
        public int? NotesId { get; set; }

        /// <summary>
        /// Gets or sets Field 'NotesModel' of type NotesModel
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }
    }
}
