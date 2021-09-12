// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Managers.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// UserController Class
    /// </summary>
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;


        /// <summary>
        /// Field 'manager' of type IUserManager
        /// </summary>
        private readonly IUserManager manager;

        /// <summary>
        /// declaring a variable for session name
        /// </summary>
        private const string SessionName = "_FullName";

        /// <summary>
        /// declaring a variable for session email id
        /// </summary>
        private const string SessionEmail = "_EmailId";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class.
        /// </summary>
        /// <param name="manager">manager parameter for this constructor</param>
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this._logger = logger;
        }

        /// <summary>
        /// UserRegistration method for New User Registration
        /// </summary>
        /// <param name="userData"> RegisterModel Data </param>
        /// <returns> Response with Status And Message </returns>
        [HttpPost]
        [Route("api/Register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                HttpContext.Session.SetString(SessionName, userData.FirstName + " " + userData.LastName);
                HttpContext.Session.SetString(SessionEmail, userData.Email);
                _logger.LogInformation("TRYING TO REGISTER !!!");
                bool result = this.manager.Register(userData);
                if (result == true)
                {
                    string name = HttpContext.Session.GetString(SessionName);
                    string email = HttpContext.Session.GetString(SessionEmail);
                    _logger.LogInformation("Registration Successfull!!!!");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Registration Successfull!", Data = "Session || Name : " + name + "|| Email Id : " + email });
                }
                else
                {
                    _logger.LogInformation("Registration Unsuccessfull!!!");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Registration Unsuccessfull!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Login method for User Login
        /// </summary>
        /// <param name="userLoginData"> LoginModel Data</param>
        /// <returns> Response with Message </returns>
        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel userLoginData)
        {
            try
            {
               _logger.LogInformation("TRYING TO LOGIN !!!");
                string message = this.manager.Login(userLoginData);
                if (message.Equals("LOGIN SUCCESS"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string FirstName = database.StringGet("FirstName");
                    string LastName = database.StringGet("LastName");
                    int UserId = Convert.ToInt32(database.StringGet("UserId"));

                    RegisterModel data = new RegisterModel
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        UserId = UserId,
                        Email = userLoginData.Email
                    };

                    _logger.LogInformation("LOGIN SUCCESS!!!");
                    string tokenString = this.manager.GenerateToken(userLoginData.Email);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message, Data= tokenString });
                }
                else
                {
                    _logger.LogInformation("LOGIN UNSUCCESS!!!");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method for Forgot Password method Invocation
        /// </summary>
        /// <param name="email"> User Email </param>
        /// <returns> Response with Status And Message </returns>
        [HttpPost]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                bool result = this.manager.ForgotPassword(email);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check the Mail!" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method for Reset Password Method Invocation
        /// </summary>
        /// <param name="resetPasswordData"> ResetPasswordModel Data </param>
        /// <returns> Response with Status And Message </returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordData)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetPasswordData);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reset Successfull !" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Unsuccessfull!. Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
