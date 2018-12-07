﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;




namespace fa18Team28_FinalProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        private PasswordValidator<AppUser> _passwordValidator;
        private AppDbContext _db;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signIn;

            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //TODO: This is the method where you create a new user
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,
                    PhoneNumber = model.PhoneNumber,
                    Birthday = model.Birthday,
                    SSN = model.SSN,
                    MiddleInitial = model.MiddleInitial,

                    //TODO: You will need to add all of the properties for your User model here
                    //Make sure that you have included ALL of the properties and that they match
                    //the model class EXACTLY!!
                    //FirstName = model.FirstName,
                    //LastName = model.LastName,

                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: Add user to desired role
                    //This will not work until you have seeded Identity OR added the "Customer" role 
                    //by navigating to the RoleAdmin controller and manually added the "Customer" role

                    await _userManager.AddToRoleAsync(user, "Customer");
                    //another example
                    await _userManager.AddToRoleAsync(user, "Manager");
                    await _userManager.AddToRoleAsync(user, "Employee");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        //GET: Account/Index
        public ActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.StreetAddress = user.StreetAddress;
            ivm.PhoneNumber = user.PhoneNumber;


            return View(ivm);
        }

        //Logic for change account information
        // GET: /Account/ChangeInformation
        public ActionResult ChangeInformation()
        {
            return View();
        }

        //*****Logic to change account information*****
        //GET: /Account/Edit
        public ActionResult Edit()
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            EditViewModel evm = new EditViewModel();

            //populate the view model
            evm.FirstName = user.FirstName;
            evm.LastName = user.LastName;
            evm.Email = user.Email;
            evm.PhoneNumber = user.PhoneNumber;
            evm.StreetAddress = user.StreetAddress;

            return View(evm);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;

                // Get the userprofile
                AppUser user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.StreetAddress = model.StreetAddress;
                user.PhoneNumber = model.PhoneNumber;

                _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Index", "Home"); // or whatever
            }

            return View(model);
        }

        //*****Logic for change password*****
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }


        public ActionResult AddCreditCard()
        {
            string username = User.Identity.Name;

            // Fetch the userprofile
            AppUser user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Construct the viewmodel
            CreditCardViewModel ccvm = new CreditCardViewModel();

            //populate the view model
            ccvm.CreditCard1 = user.CreditCard1;
            ccvm.CreditCard2 = user.CreditCard2;
            ccvm.CreditCard3 = user.CreditCard3;
            

            return View(ccvm);
        }

        [HttpPost]
        public ActionResult AddCreditCard(CreditCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;

                // Get the userprofile
                AppUser user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));

                // Update fields
                user.CreditCard1 = model.CreditCard1;
                user.CreditCard2 = model.CreditCard2;
                user.CreditCard3 = model.CreditCard3;
                

                _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Index", "Home"); // or whatever
            }

            return View(model);
        }

        //GET:/Account/AccessDenied
        public ActionResult AccessDenied(String ReturnURL)
        {
            return View("Error", new string[] { "Access is denied" });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}