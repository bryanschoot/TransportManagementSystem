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
        #region [Fields]
        private Factory.Factory _factory;
        private IAccountLogic _account = null;
        #endregion

        #region [Constructor]
        public AccountController(IConfiguration configuration)
        {
            _factory = new Factory.Factory(configuration);
            this._account = this._factory.AccountLogic();
        }
        #endregion

        #region [JSON]
        public IActionResult DoesEmailExist(string email)
        {
            bool exist = this._account.DoesEmailExist(email);

            if (!exist)
            {
                return Json(data: $"*The email: {email} does not exist.");
            }
            return Json(data: true);
        }
        #endregion

        #region Login
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this._account.IsAccountValid(model.Email, model.Password))
                {
                    Account account = this._account.GetAccountByEmail(model.Email);
                    
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
        #endregion

        #region Logout
        [HttpGet]
        [Authorize]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            TempData["message"] = "You have succesfully logged off!";

            return RedirectToAction("Login");
        }
        #endregion

        #region Profile
        [HttpGet]
        [Authorize]
        [Route("Profile")]
        public IActionResult Profile()
        {
            int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

            Account account = this._account.GetAccountById(id);
            ProfileViewModel model = new ProfileViewModel(account);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("Profile/Update")]  
        public async Task<IActionResult> EditProfile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account checkaccount = this._account.GetAccountById(model.Id);
                bool changed = checkaccount.Email != model.Email || checkaccount.FirstName != model.FirstName || checkaccount.LastName != model.LastName || checkaccount.PhoneNumber != model.PhoneNumber;

                if (changed)
                {
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
        #endregion

        #region Address
        [HttpPost]
        [Authorize]
        [Route("Address/Create")]
        public async Task<IActionResult> CreateAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

                Address address = model.CopyTo();
                this._account.CreateAddress(address, id);

                TempData["message"] = "Address has been created!";
                return RedirectToAction("Profile", "Account");
            }
            return this.View("Address", model);
        }

        [HttpGet]
        [Authorize]
        [Route("Address")]
        public async Task<IActionResult> Address()
        {
            return this.View("Address");
        }

        [HttpGet]
        [Authorize]
        [Route("Address/{id}")]
        public IActionResult ReadAddress(int id)
        {
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

        [HttpPost]
        [Authorize]
        [Route("Address/Update")]
        public async Task<IActionResult> EditAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                int accountid = Convert.ToInt32(User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault());

                Address checkAddress = this._account.GetAddressById(model.Id, accountid);
                bool changed = checkAddress.Country != model.Country || checkAddress.City != model.City || checkAddress.StreetName != model.StreetName || checkAddress.StreetNumber != model.StreetNumber || checkAddress.ZipCode != model.ZipCode;

                if (changed)
                {
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

        [HttpGet]
        [Authorize]
        [Route("DeleteAddress/{id}")]
        public IActionResult DeleteAddress(int id)
        {
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
        #endregion
    }
}