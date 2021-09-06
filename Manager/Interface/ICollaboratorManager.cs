// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// ICollaboratorManager Interface
    /// </summary>
    public interface ICollaboratorManager
    {
        public string AddCollaborator(CollaboratorsModel collaborators);
        /// <summary>
        /// Deletes Collaborator
        /// </summary>
        /// <param name="collaboratorId">collaboratorId</param>
        /// <returns>Returns boolean</returns>
        public bool DeleteCollaborator(int collaboratorId);

        /// <summary>
        /// Gets Collaborators
        /// </summary>
        /// <returns>Collaborators</returns>
        public IEnumerable<CollaboratorsModel> GetCollaborators();

    }
}
