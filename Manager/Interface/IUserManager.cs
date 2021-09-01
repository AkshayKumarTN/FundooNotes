// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Managers.Interface
{
    /// <summary>
    /// IUserManager interface
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Register Method Declaration
        /// </summary>
        /// <param name="userData">userData parameter for this method</param>
        /// <returns>boolean result</returns>
        bool Register(RegisterModel userData);

        /// <summary>
        /// Login Method Declaration 
        /// </summary>
        /// <param name="userLoginData">userLoginData parameter</param>
        /// <returns>string result</returns>
        string Login(LoginModel userLoginData);

        /// <summary>
        /// Forgot password method Declaration
        /// </summary>
        /// <param name="email">email string</param>
        /// <returns>boolean result</returns>
        bool ForgotPassword(string email);

        /// <summary>
        /// Reset Password Method Declaration
        /// </summary>
        /// <param name="resetPasswordData">resetPasswordData parameter</param>
        /// <returns>boolean result</returns>
        bool ResetPassword(ResetPasswordModel resetPasswordData);

        /// <summary>
        /// GenerateToken method Declaration
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GenerateToken(string email);
    }
}
