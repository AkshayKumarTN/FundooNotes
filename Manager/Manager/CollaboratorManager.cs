// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager.Manager
{
    using FundooNotes.Manager.Interface;
    using FundooNotes.Repository.Interface;
    using System.Collections.Generic;

    /// <summary>
    /// CollaboratorManager class implements ICollaboratorManager interface
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// collaborator reference variable of type ICollaboratorRepository
        /// </summary>
        private readonly ICollaboratorRepository collaborator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager" /> class.
        /// </summary>
        /// <param name="collaborator">ICollaboratorRepository</param>
        public CollaboratorManager(ICollaboratorRepository collaborator)
        {
            this.collaborator = collaborator;
        }

        /// <summary>
        /// AddCollaborator Method
        /// </summary>
        /// <param name="collaborator">CollaboratorsModel</param>
        /// <returns>string</returns>
        public string AddCollaborator(CollaboratorsModel collaborator)
        {
            string message = this.collaborator.AddCollaborator(collaborator);
            return message;
        }

        /// <summary>
        /// DeleteCollaborator Method
        /// </summary>
        /// <param name="collaboratorId">collaboratorId</param>
        /// <returns>boolean</returns>
        public bool DeleteCollaborator(int collaboratorId)
        {
            bool result = this.collaborator.DeleteCollaborator(collaboratorId);
            return result;
        }

        /// <summary>
        /// GetCollaborators Method
        /// </summary>
        /// <returns>CollaboratorsModels</returns>
        public IEnumerable<CollaboratorsModel> GetCollaborators()
        {
            IEnumerable<CollaboratorsModel> result = this.collaborator.GetCollaborators();
            return result;
        }
    }
}
