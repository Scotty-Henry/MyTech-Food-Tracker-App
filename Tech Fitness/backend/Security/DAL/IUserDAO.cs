﻿using Security.Models;
using Security.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.DAL
{
    /// <summary>
    /// An interface for user data objects.
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(User user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);


        void CreateProfile(UserProfileModel userProfile);

        void UpdateProfile(UserProfileModel userProfile);

        UserProfileModel GetUserProfile(int id);

        void addMeal(Meal meal);

        List<Meal> getMealsbyUserID(int userID);

        List<DayNutrientAggModel> getNutritionbyMealandDate(int userID);

    }
}
