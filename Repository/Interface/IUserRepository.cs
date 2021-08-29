using FundooNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository 
    {
        public bool Register(RegisterModel userData);
        
    }
}
