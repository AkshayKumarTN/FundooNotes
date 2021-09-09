// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// LabelModel Class
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets Field 'LabelId' of type integer
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets Field 'Label' of type string
        /// </summary>
        public string LabelName { get; set; }

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
        /// Gets or sets Field 'NoteId' of type integer
        /// </summary>
        [ForeignKey("NotesModel")]
        public int? NoteId { get; set; }

        /// <summary>
        /// Gets or sets Field 'NotesModel' of type NotesModel
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }
    }
}
