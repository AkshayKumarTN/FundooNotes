// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditLabelsModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// EditLabelsModel Class
    /// </summary>
    public class EditLabelsModel
    {
        /// <summary>
        /// Gets or sets Field 'NewLableName' of type string
        /// </summary>
        public string NewLableName { get; set; }

        /// <summary>
        /// Gets or sets Field 'LableName' of type string
        /// </summary>
        public string LableName { get; set; }

        /// <summary>
        /// Gets or sets Field 'UserId' of type integer
        /// </summary>
        public int UserId { get; set; }
    }
}
