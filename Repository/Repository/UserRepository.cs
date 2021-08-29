using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // this function Checks for Login....
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
    }
}
