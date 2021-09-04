// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorsModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CollaboratorsModel Class
    /// </summary>
    public class CollaboratorsModel
    {
        /// <summary>
        /// Gets or sets Field 'CollaboratorID' of type integer
        /// </summary>
        [Key]
        public int CollaboratorId { get; set; }

        /// <summary>
        /// Gets or sets Field 'SenderEmail' of type string
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets Field 'ReceiverEmail' of type string
        /// </summary>
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Gets or sets Field 'NoteId' of type integer
        /// </summary>
        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets Field 'NotesModel' of type NotesModel
        /// </summary>
        public virtual NotesModel NotesModel { get; set; }
    }
}
