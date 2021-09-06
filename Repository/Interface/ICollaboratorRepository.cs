// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Interface
{

    /// <summary>
    /// ICollaboratorRepository Class
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="collaborators">CollaboratorsModel</param>
        /// <returns>Returns string</returns>
        public string AddCollaborator(CollaboratorsModel collaborators);
        /// <summary>
        /// Deletes Collaborator
        /// </summary>
        /// <param name="collaboratorId">collaboratorId</param>
        /// <returns>Returns boolean</returns>
        public bool DeleteCollaborator(int collaboratorId);
    }
}
