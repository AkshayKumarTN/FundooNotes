using Experimental.System.Messaging;
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace FundooNotes.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                if(userData !=null)
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

        // this function Convert to Encord your Password....
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

        // This function Checks for Login....
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
            }catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        // This function Sends Mail To UserEmail with a Link to Reset Password....
        public bool ForgotPassword(string email)
        {
            try
            {
                var userCheck = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if (userCheck != null)
                {
                    SendMessage();
                    var messageBody = receiverMessage();
                    using (MailMessage mailMessage = new MailMessage("tnak369@gmail.com", email))
                    {
                        mailMessage.Subject = "Link to reset Password";
                        mailMessage.Body = messageBody;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient Smtp = new SmtpClient();
                        Smtp.Host = "smtp.gmail.com";
                        Smtp.EnableSsl = true;
                        Smtp.UseDefaultCredentials = false;
                        Smtp.Credentials = new NetworkCredential("tnak369@gmail.com", "Password");
                        Smtp.Port = 587;
                        Smtp.Send(mailMessage);
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

        // This function Sends Message into MessageQueue....
        public static void SendMessage()
        {
            var url = "Click on following link to reset your credentials for Fundoonotes App: https://localhost:44381/api/ResetPassword";
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

        // This function Receives And Returns Message From MessageQueue....
        public static string receiverMessage()
        {
            MessageQueue receiver = new MessageQueue(@".\Private$\MyQueue");
            var receiving = receiver.Receive();
            receiving.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = receiving.Body.ToString();
            return linkToBeSend;
        }

        // This function to Reset Password in the Database.......
        // Reference : https://www.learnentityframeworkcore.com/dbcontext/modifying-data.....
        public bool ResetPassword(ResetPasswordModel resetPasswordData)
        {
            try
            {
                string encodedPassword = EncodePasswordToBase64(resetPasswordData.NewPassword);
                var userPassword = this.userContext.Users.Where(x => x.Email == resetPasswordData.Email).FirstOrDefault();
                if (userPassword != null)
                {
                    userPassword.Password = encodedPassword;
                    userContext.Entry(userPassword).State = EntityState.Modified;
                    userContext.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

    }
}
