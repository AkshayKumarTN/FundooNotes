// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Context
{
    using FundooNotes;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// UserContext Class
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext" /> class.
        /// </summary>
        /// <param name="options">Context Options</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Field 'Users' of type DataBaseSet
        /// </summary>
        public DbSet<RegisterModel> Users { get; set; }

        /// <summary>
        /// Gets or sets Field 'FundooNotes' of type DataBaseSet
        /// </summary>
        public DbSet<NotesModel> FundooNotes { get; set; }
    }
}
