
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RockeyWC.Models.ViewModels;
using RockeyWC.Models;

namespace RockeyWC.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userMgr,
                SignInManager<IdentityUser> signInMgr,
                RoleManager<IdentityRole> roleMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
            //IdentitySeedData.EnsurePopulated(userMgr).Wait();

        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        // Register view returned for user input upon demand for authentication
        [HttpGet]
        //[Authorize(Roles = "Admin,OfficeManager")] // Either authorization works.  To force both authorizations simultaneously you stack the Authorize decorations
        public ViewResult Register(string returnUrl)
        {
            return View(new RegisterModel
            {
                ReturnUrl = returnUrl
            });
        }

        // Post from login web page
        [HttpPost]
        //[Authorize(Roles = "Admin,OfficeManager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            // If the data was entered properly
            if (ModelState.IsValid)
            {
                // Identify the user based on the login values
                IdentityUser user =
                    await userManager.FindByNameAsync(registerModel.Name);

                // If the user is un-known
                if (user == null)
                {
                    // Sign out if already logged in under another user
                    await signInManager.SignOutAsync();

                    // Add them in as a user
                    user = new IdentityUser(registerModel.Name);
                    var password = registerModel.Password.Length == 0 ? "Secret123$" : registerModel.Password;
                    await userManager.CreateAsync(user, password);

                    // Sign them in and go to the admin page
                    if ((await signInManager.PasswordSignInAsync(user,
                            registerModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(registerModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }

            // Error for bad register attempt
            ModelState.AddModelError("", "Bad User name or User name is already taken");
            return View(registerModel);
        }

        [AllowAnonymous] // Must allow anyone to fail to log in
        [HttpGet]
        public ViewResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        // Assign roles automatically
        public async Task<IActionResult> AssignRole(RegisterModel registerModel)
        {
            // Look for Natasha
            IdentityUser user = await userManager.FindByNameAsync(registerModel.Name);

            // If Natasha is found
            if (user != null)
            {
                // Insure there is an Office Manager role

                // Office Manage Name and Role object defined
                var RoleName = registerModel.Role;
                IdentityRole ThisRole;

                // Get the role from the Role Manager
                ThisRole = await roleManager.FindByNameAsync(RoleName);
                if (ThisRole == null)
                {

                    // If it does not exist, make it.  Save a copy for demonstration, even though we are not using it
                    IdentityResult Result = await roleManager.CreateAsync(new IdentityRole(RoleName));
                    if (Result.Succeeded) ThisRole = await roleManager.FindByNameAsync(RoleName);
                }

                // if Natasha is not assigned that role, assign now
                if (!(await userManager.IsInRoleAsync(user, RoleName)))
                {
                    await userManager.AddToRoleAsync(user, RoleName);
                }
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
