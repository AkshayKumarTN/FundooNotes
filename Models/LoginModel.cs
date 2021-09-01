// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// LoginModel Class
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets Field 'Email' of type string
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Field 'Password' of type string
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
