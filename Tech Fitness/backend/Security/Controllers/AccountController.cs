using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.DAL;
using Security.Models;
using Security.Models.Account;
using Security.Providers.Security;

namespace Security.Controllers
{
    /// <summary>
    /// Creates a new account controller used to authenticate the user.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ITokenGenerator tokenGenerator;
        private IPasswordHasher passwordHasher;
        private IUserDAO userDao;

        /// <summary>
        /// Creates a new account controller.
        /// </summary>
        /// <param name="tokenGenerator">A token generator used when creating auth tokens.</param>
        /// <param name="passwordHasher">A password hasher used when hashing passwords.</param>
        /// <param name="userDao">A data access object to store user data.</param>
        public AccountController(ITokenGenerator tokenGenerator, IPasswordHasher passwordHasher, IUserDAO userDao)
        {
            this.tokenGenerator = tokenGenerator;
            this.passwordHasher = passwordHasher;
            this.userDao = userDao;
        }

        /// <summary>
        /// Registers a user and provides a bearer token.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult Register(AuthenticationModel model)
        {
            // Does user already exist
            if (userDao.GetUser(model.Username) != null)
            {
                return BadRequest(new
                {
                    Message = "Username has already been taken."
                });
            }

            // Generate a password hash
            var passwordHash = passwordHasher.ComputeHash(model.Password);

            // Create a user object
            var user = new User { Password = passwordHash.Password, Salt = passwordHash.Salt, Role = "User", Username = model.Username };

            // Save the user
            userDao.CreateUser(user);

            // Generate a token
            var token = tokenGenerator.GenerateToken(user.Username, user.Role);

            // Return the token
            return Ok(token);
        }


        /// <summary>
        /// Authenticates the user and provides a bearer token.
        /// </summary>
        /// <param name="model">An object including the user's credentials.</param> 
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(AuthenticationModel model)
        {
            // Assume the user is not authorized
            IActionResult result = Unauthorized();

            // Get the user by username
            var user = userDao.GetUser(model.Username);

            // If we found a user and the password has matches
            if (user != null && passwordHasher.VerifyHashMatch(user.Password, model.Password, user.Salt))
            {
                // Create an authentication token
                var token = tokenGenerator.GenerateToken(user.Username, user.Role);

                // Switch to 200 OK
                result = Ok(token);
            }

            return result;
        }

        [HttpPost("createprofile")]
        //[Authorize(Roles = "User")]
        public IActionResult CreateProfile(UserProfileModel model)
        {
            IActionResult result = Ok();

            //This is off my token
            string user = User.Identity.Name;

            //this is from the model body handend from vue
            string name = model.name;

            //find my user in the users table by the name on their token (given during log in)
            User currentUser = userDao.GetUser(User.Identity.Name);

            //get the current users id
            int currentUserId = currentUser.Id;

            //use this id to add it to my profile model so the key's match.
            model.id = currentUserId;

            userDao.CreateProfile(model);

            return result;
        }

        [HttpPut("updateprofile")]
        //[Authorize(Roles = "User")]
        public IActionResult UpdateProfile(UserProfileModel model)
        {
            IActionResult result = Ok();

            //This is off my token
            string user = User.Identity.Name;

            //this is from the model body handend from vue
            string name = model.name;

            //find my user in the users table by the name on their token (given during log in)
            User currentUser = userDao.GetUser(User.Identity.Name);

            //get the current users id
            int currentUserId = currentUser.Id;

            //use this id to add it to my profile model so the key's match.
            model.id = currentUserId;

            userDao.UpdateProfile(model);

            return result;
        }

        [HttpPost("addMeal")]
        //[Authorize(Roles = "User")]
        public IActionResult addMeal (Meal meal)
        {
            IActionResult result = Ok();

            //find my user in the users table by the name on their token (given during log in)
            User currentUser = userDao.GetUser(User.Identity.Name);

            //use this id to add it to my profile model so the key's match.
            meal.userID = currentUser.Id;



            userDao.addMeal(meal);


            return result;
        }

        [HttpGet("getMealbyUser")]
        //[Authorize(Roles = "User")]
        public ActionResult<List<Meal>> getMealsbyUser()
        {
            IActionResult result = Ok();

            List<Meal> allMeals = new List<Meal>();
            //This is off my token
            string user = User.Identity.Name;


            //find my user in the users table by the name on their token (given during log in)
            User currentUser = userDao.GetUser(User.Identity.Name);

            //get the current users id
            int currentUserId = currentUser.Id;

            allMeals = userDao.getMealsbyUserID(currentUserId);

            return allMeals;
        }

        /// <summary>
        /// Currently, I am only routed here from 'create profile'. 
        /// SHould be only able to 'create' profile once, then should update profile.
        /// When a user updates their profile, must update DB. 
        /// </summary>
        /// <returns></returns>
        [HttpGet("dashboard")]
        [Authorize(Roles = "User")]
        public ActionResult<UserProfileModel> Dashboard()
        {
            UserProfileModel userProfile = new UserProfileModel();
          
            //Pulls the username from login off the token
            string user = User.Identity.Name;

            //Find the current user from their name
            User currentUser = userDao.GetUser(User.Identity.Name);

            //Get the users profile from their ID
            userProfile = userDao.GetUserProfile(currentUser.Id);

            return userProfile;
        }
    }
}