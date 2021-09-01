namespace FundooNotes.Repository.Repository
{
    using System;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;    

    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddNewNote(NotesModel note)
        {
            this.userContext.FundooNotes.Add(note);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string RemoveNote(int id)
        {
            try
            {
                var note = this.userContext.FundooNotes.Find(id);
                this.userContext.FundooNotes.Remove(note);
                this.userContext.SaveChangesAsync();
                return "Note Deleted Successfully"; ;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
