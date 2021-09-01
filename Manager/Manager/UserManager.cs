// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Manager
{
    using System;
    using FundooNotes.Managers.Interface;
    using FundooNotes.Repository.Interface;

    /// <summary>
    /// UserManager class implements IUserManager interface
    /// </summary>
    public class UserManager : IUserManager
    {
        /// <summary>
        /// repository reference variable of type IUserRepository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="repository">repository parameter</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Method to call Register Method which belongs to IUserRepository interface
        /// </summary>
        /// <param name="userData">userData parameter</param>
        /// <returns>boolean result</returns>
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to call Login Method which belongs to IUserRepository interface
        /// </summary>
        /// <param name="userLoginData">userLoginData parameter</param>
        /// <returns>boolean result</returns>
        public bool Login(LoginModel userLoginData)
        {
            try
            {
                return this.repository.Login(userLoginData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgot password Method 
        /// </summary>
        /// <param name="email">email string parameter</param>
        /// <returns>boolean result</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Reset Password Method 
        /// </summary>
        /// <param name="resetPasswordData">resetPasswordData parameter</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPasswordModel resetPasswordData)
        {
            try
            {
                return this.repository.ResetPassword(resetPasswordData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateToken(string email)
        {
            try
            {
                return this.repository.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
