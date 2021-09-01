// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace Models
{
    using FundooNotes;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// NotesModel Class
    /// </summary>
    public class NotesModel
    {
        /// <summary>
        /// Gets or sets Field 'NotesId' of type integer
        /// </summary>
        [Key]
        public int NotesId { get; set; }

        /// <summary>
        /// Gets or sets Field 'Title' of type string
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets Field 'Description' of type string
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Field 'Reminder' of type string
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// Gets or sets Field 'Collaborator' of type string
        /// </summary>
        public string Collaborator { get; set; }

        /// <summary>
        /// Gets or sets Field 'Color' of type string
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Field 'Image' of type string
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets Field 'Lable' of type string
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// Gets or sets Field 'Pin' of type Boolean
        /// </summary>
        public bool Pin { get; set; } = false;

        /// <summary>
        /// Gets or sets Field 'Archieve' of type Boolean
        /// </summary>
        public bool Archieve { get; set; } = false;

        /// <summary>
        /// Gets or sets Field 'UserId' of type integer
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Field 'RegisterModel' of type RegisterModel
        /// </summary>
        public RegisterModel RegisterModel { get; set; }
    }
}
