// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ResetPasswordModel class
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets Field 'Email' of type string
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Field 'NewPassword' of type string
        /// </summary>
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets Field 'ConfirmNewPassword' of type string
        /// </summary>
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
