// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using Experimental.System.Messaging;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// UserRepository Class
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Field userContext of type UserContext
        /// </summary>
        private readonly UserContext userContext;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="userContext">userContext Parameter</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Method to Encrypt User Password
        /// </summary>
        /// <param name="password">user password</param>
        /// <returns>encrypted password</returns>
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// This function Sends Message into MessageQueue.......
        /// </summary>
        public static void SendMessage()
        {
            var url = "Click on following link to reset your credentials for Fundoonotes App: Link";
            MessageQueue msmqQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                msmqQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                msmqQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            msmqQueue.Label = "url link";
            msmqQueue.Send(message);
        }

        /// <summary>
        /// This function Receives And Returns Message From MessageQueue
        /// </summary>
        /// <returns>returns String</returns>
        public static string ReceiverMessage()
        {
            MessageQueue receiver = new MessageQueue(@".\Private$\MyQueue");
            var receiving = receiver.Receive();
            receiving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = receiving.Body.ToString();
            return linkToBeSend;
        }

        /// <summary>
        /// Method to Add new User to the Database
        /// </summary>
        /// <param name="userData">userData parameter for this method</param>
        /// <returns>boolean result</returns>
        public bool Register(RegisterModel userData)
        {
            try
            {
                if (userData != null)
                {
                    userData.Password = EncodePasswordToBase64(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method for Login
        /// </summary>
        /// <param name="userLoginData">userLoginData parameter</param>
        /// <returns>boolean result</returns>
        public bool Login(LoginModel userLoginData)
        {
            try
            {
                string encodedPassword = EncodePasswordToBase64(userLoginData.Password);
                var loginUser = this.userContext.Users.Where(x => x.Email == userLoginData.Email && x.Password == encodedPassword).FirstOrDefault();
                if (loginUser != null)
                {
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Method to generate token for given User Email
        /// </summary>
        /// <param name="email">>User Email address</param>
        /// <returns>boolean result</returns>
        public bool ForgotPassword(string email)
        {
            try
            {
                var userCheck = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if (userCheck != null)
                {
                    SendMessage();
                    var messageBody = ReceiverMessage();
                    using (MailMessage mailMessage = new MailMessage("tnak369@gmail.com", email))
                    {
                        mailMessage.Subject = "Link to reset Password";
                        mailMessage.Body = messageBody;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("tnak369@gmail.com", "Password");
                        smtp.Port = 587;
                        smtp.Send(mailMessage);
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This function to Reset Password in the Database
        /// </summary>
        /// <param name="resetPasswordData">resetPasswordData parameter</param>
        /// <returns>boolean result</returns>
        public bool ResetPassword(ResetPasswordModel resetPasswordData)
        {
            try
            {
                string encodedPassword = EncodePasswordToBase64(resetPasswordData.NewPassword);
                var userPassword = this.userContext.Users.Where(x => x.Email == resetPasswordData.Email).FirstOrDefault();
                if (userPassword != null)
                {
                    userPassword.Password = encodedPassword;
                    this.userContext.Entry(userPassword).State = EntityState.Modified;
                    this.userContext.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// GenerateToken Method
        /// </summary>
        /// <param name="email">string email</param>
        /// <returns>token string</returns>
        public string GenerateToken(string email)
        {
            byte[] key = Convert.FromBase64String(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
