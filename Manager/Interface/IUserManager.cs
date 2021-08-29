using FundooNotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Managers.Interface
{
    public interface IUserManager
    {
        bool Register(RegisterModel userData);
        bool Login(LoginModel userLoginData);
    }
}
