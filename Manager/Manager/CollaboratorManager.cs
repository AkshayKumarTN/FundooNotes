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
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// CollaboratorManager Class
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository collaborator;

        public CollaboratorManager(ICollaboratorRepository collaborator)
        {
            this.collaborator = collaborator;
        }

        public string AddCollaborator(CollaboratorsModel collaborator)
        {
            string message = this.collaborator.AddCollaborator(collaborator);
            return message;
        }

        public bool DeleteCollaborator(int collaboratorId)
        {
            bool result = this.collaborator.DeleteCollaborator(collaboratorId);
            return result;
        }
    }
}
