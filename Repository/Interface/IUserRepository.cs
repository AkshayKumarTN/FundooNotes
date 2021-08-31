using FundooNotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository 
    {
        public bool Register(RegisterModel userData);

        public bool Login(LoginModel userLoginData);
        public bool ForgotPassword(string email);
        bool ResetPassword(ResetPasswordModel resetPasswordData);
    }
}
