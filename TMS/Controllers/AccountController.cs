using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TMS.Logic.Interface;
using TMS.Model;
using TMS.Models;

namespace TMS.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private Factory.Factory _factory;
        private IAccountLogic _account = null;

        /// <summary>
        /// Read the configuration file and creates the factory.
        /// </summary>
        /// <param name="configuration">Needed to read the appsettings.json connectionstring</param>
        public AccountController(IConfiguration configuration)
        {
            this._factory = new Factory.Factory(configuration);
            this._account = this._factory.AccountLogic();
        }

        /// <summary>
        /// Checks if email exist
        /// </summary>
        /// <param name="email">Email from form</param>
        /// <returns></returns>
        public IActionResult DoesEmailExist(string email)
        {
            bool exist = this._account.DoesEmailExist(email);
            if (!exist)
            {
                return Json(data: $"*The email: {email} does not exist.");
            }
            return Json(data: true);
        }

        /// <summary>
        /// Get request to login page
        /// </summary>
        /// <returns>Login page</returns>
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Post to the login function
        /// </summary>
        /// <param name="model">Expecting a loginviewmodel</param>
        /// <returns>If login true home page, Else login page with error messages from Loginviewmodel</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this._account.IsAccountValid(model.Email, model.Password))
                {
                    Account account = this._account.GetAccountByEmail(model.Email);
                    
                    //Set cookies
                    var claims = new List<Claim>
                    {
                        new Claim("Id", account.Id.ToString()),
                        new Claim(ClaimTypes.Email, account.Email),
                        new Claim(ClaimTypes.Role, account.Role.RoleName),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("index", "Home");
                }
            }
            return View(model);
        }

        /// <summary>
        /// Login action
        /// </summary>
        /// <returns>You to the login page</returns>
        [HttpGet]
        [Authorize]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            //Unset cookies
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["message"] = "You have succesfully logged off!";

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Get profile data
        /// </summary>
        /// <returns>Profile page using profileviewmodel</returns>
        [HttpGet]
        [Authorize]
        [Route("Profile")]
        public IActionResult Profile()
        {
            //get account id from cookies
            int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            Account account = this._account.GetAccountById(id);
            ProfileViewModel model = new ProfileViewModel(account);

            return View(model);
        }

        /// <summary>
        /// Post to the update action
        /// </summary>
        /// <param name="model">Expects Profileviewmodel</param>
        /// <returns>Shows you the account page certain messages</returns>
        [HttpPost]
        [Authorize]
        [Route("Profile/Update")]  
        public IActionResult EditProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Get old account to compare with the new one
                Account checkaccount = this._account.GetAccountById(model.Id);
                //Checks if the userinput has changed
                bool changed = checkaccount.Email != model.Email || checkaccount.FirstName != model.FirstName || checkaccount.LastName != model.LastName || checkaccount.PhoneNumber != model.PhoneNumber;

                if (changed)
                {
                    //copies viewmodel to model
                    Account account = model.CopyTo();
                    this._account.UpdateAccount(account);

                    TempData["message"] = "Account has been updated!";

                    return RedirectToAction("Profile", "Account");
                }
                TempData["errormessage"] = "Account cannot be updated!";
                return RedirectToAction("Profile", "Account");
            }

            return View("Profile", model);
        }

        /// <summary>
        /// Create a new address
        /// </summary>
        /// <param name="model">Requiress addressviewmodel</param>
        /// <returns>Shows you the account page with messages or shows the form with errors</returns>
        [HttpPost]
        [Authorize]
        [Route("Address/Create")]
        public IActionResult CreateAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get account id from cookies
                int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

                //copies viewmodel to model
                Address address = model.CopyTo();
                this._account.CreateAddress(address, id);

                TempData["message"] = "Address has been created!";
                return RedirectToAction("Profile", "Account");
            }
            return this.View("Address", model);
        }

        /// <summary>
        /// Get the address page
        /// </summary>
        /// <returns>the address page</returns>
        [HttpGet]
        [Authorize]
        [Route("Address")]
        public IActionResult Address()
        {
            return this.View("Address");
        }

        /// <summary>
        /// Get address by id
        /// </summary>
        /// <param name="id">id from the selected address</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("Address/{id}")]
        public IActionResult ReadAddress(int id)
        {
            //get account id from cookies
            int accountid = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            Address address = this._account.GetAddressById(id, accountid);
            if (address != null)
            {
                AddressViewModel model = new AddressViewModel(address);
                return this.View("Address", model);
            }

            TempData["errormessage"] = "You dont have permission to do this!";
            return RedirectToAction("Profile", "Account");
        }

        /// <summary>
        /// Post the Addressviemodel to this action to update the account
        /// </summary>
        /// <param name="model">Addressviewmodel is needed to update the address of the user</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("Address/Update")]
        public IActionResult EditAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                //get account id from cookies
                int accountid = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

                Address checkAddress = this._account.GetAddressById(model.Id, accountid);
                //Check if userinput has changes
                bool changed = checkAddress.Country != model.Country || checkAddress.City != model.City || checkAddress.StreetName != model.StreetName || checkAddress.StreetNumber != model.StreetNumber || checkAddress.ZipCode != model.ZipCode;

                if (changed)
                {
                    //copies viewmodel to model
                    Address address = model.CopyTo();

                    this._account.UpdateAddress(address);

                    TempData["message"] = "Address has been updated!";
                    return RedirectToAction("Profile", "Account", new { id = model.Id });
                }

                TempData["errormessage"] = "Address cannot be updated!";
                return RedirectToAction("Profile", "Account", new { id = model.Id });
            }
            return this.View("Address", model);
        }

        /// <summary>
        /// Delete address by id
        /// </summary>
        /// <param name="id">Deleted address id</param>
        /// <returns>Returns you to given action (view)</returns>
        [HttpGet]
        [Authorize]
        [Route("DeleteAddress/{id}")]
        public IActionResult DeleteAddress(int id)
        {
            //get account id from cookies
            int accountid = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            Address address = this._account.GetAddressById(id, accountid);

            if (address != null)
            {
                bool deleted = this._account.DeleteAddress(id);

                if (deleted)
                {
                    TempData["message"] = "Address has been deleted succesfully!";
                    return RedirectToAction("Profile", "Account");
                }

                TempData["errormessage"] = "Address could not be deleted!";
                return RedirectToAction("Profile", "Account");
            }
            TempData["errormessage"] = "You dont have permission to do this!";
            return RedirectToAction("Profile", "Account");
        }
    }
}