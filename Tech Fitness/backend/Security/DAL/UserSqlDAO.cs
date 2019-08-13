using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Security.Models;
using Security.Models.Account;

namespace Security.DAL
{

    /// <summary>
    /// A SQL Dao for user objects.
    /// </summary>
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;
        private const string _getLastIdSQL = "select cast(SCOPE_IDENTITY() as int);";


        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public UserSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@username, @password, @salt, @role);", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", user.Id);                    

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET password = @password, salt = @salt, role = @role WHERE id = @id;", conn);                    
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void CreateProfile(UserProfileModel userProfile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO user_profile (id, name, birthdate, currWeight, goalWeight, height, activityLevel) " +
                                                     "VALUES (@id, @name, @birthdate, @currWeight, @goalWeight, @height, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@name", userProfile.name);
                    cmd.Parameters.AddWithValue("@id", userProfile.id);
                    cmd.Parameters.AddWithValue("@birthdate", userProfile.birthdate);
                    cmd.Parameters.AddWithValue("@currWeight", userProfile.currWeight);
                    cmd.Parameters.AddWithValue("@goalWeight", userProfile.goalWeight);
                    cmd.Parameters.AddWithValue("@height", userProfile.height);
                    cmd.Parameters.AddWithValue("@activityLevel", userProfile.activityLevel);
               
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void UpdateProfile(UserProfileModel userProfile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); 
                    SqlCommand cmd = new SqlCommand("UPDATE user_profile SET id = @id, name = @name, birthdate = @birthdate, currWeight = @currWeight, goalWeight = @goalWeight, height = @height, activityLevel = @activityLevel " +
                                                     "WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@name", userProfile.name);
                    cmd.Parameters.AddWithValue("@id", userProfile.id);
                    cmd.Parameters.AddWithValue("@birthdate", userProfile.birthdate);
                    cmd.Parameters.AddWithValue("@currWeight", userProfile.currWeight);
                    cmd.Parameters.AddWithValue("@goalWeight", userProfile.goalWeight);
                    cmd.Parameters.AddWithValue("@height", userProfile.height);
                    cmd.Parameters.AddWithValue("@activityLevel", userProfile.activityLevel);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        //Inserted in-order to maintain referential integrity

        public void addMeal(Meal meal)
        {
            try
            {
                //Declare List of ints to hold my food NDBNO's
                List<int> foodNDBNOs = new List<int>();

                const string insertMeal = "INSERT INTO meal (meal_type, user_id, meal_date) " +
                                                     "VALUES (@type, @user, @date);";

                //write query here to get list of all foods ndbno from DB. Returns list of ints called NDBNOArray 
                const string getFoodsNDBNO = "SELECT ndbno FROM food;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    int newMealID = 0;
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getFoodsNDBNO, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int NDBNO = Convert.ToInt16(reader["ndbno"]);
                        foodNDBNOs.Add(NDBNO);
                    }

                    cmd = new SqlCommand(insertMeal + _getLastIdSQL, conn);
                    cmd.Parameters.AddWithValue("@type", meal.meal_category);
                    cmd.Parameters.AddWithValue("@user", meal.userID);
                    cmd.Parameters.AddWithValue("@date", meal.date);
                    newMealID = (int)cmd.ExecuteScalar();

                    
                    foreach (FoodItem food in meal.foods)
                    {
                        //if food.ndbno not in my NDBNO array, then insert it 
                        if (!foodNDBNOs.Contains(Convert.ToInt16(food.ndbno)))
                        {
                            cmd = new SqlCommand("INSERT INTO food (ndbno, serving_size, food_name, protein, carb, fat, cal) " +
                                                             "VALUES (@ndbno, @serving_size, @food_name, @protein, @carb, @fat, @cal );", conn);
                            cmd.Parameters.AddWithValue("@ndbno", food.ndbno);
                            cmd.Parameters.AddWithValue("@serving_size", food.unit);
                            cmd.Parameters.AddWithValue("@food_name", food.name);
                            cmd.Parameters.AddWithValue("@protein", food.pro);
                            cmd.Parameters.AddWithValue("@carb", food.carb);
                            cmd.Parameters.AddWithValue("@fat", food.fat);
                            cmd.Parameters.AddWithValue("@cal", food.cal);
                            cmd.ExecuteNonQuery();
                        }
                        //regardless, insert into my meal transaction table
                        cmd = new SqlCommand("INSERT INTO meal_food (meal_id, ndbno, qty) " +
                                                     "VALUES (@meal_id, @ndbno, @qty);", conn);
                        cmd.Parameters.AddWithValue("@meal_id", newMealID);
                        cmd.Parameters.AddWithValue("@ndbno", food.ndbno );
                        cmd.Parameters.AddWithValue("@qty", food.qty);
                        cmd.ExecuteNonQuery();
                    }
  

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        //Inserted in order to maintain referential integrity
       
        public List<Meal> getMealsbyUserID(int userID)
        {
            try
            {
                //get data
                const string sql = @"select 
                                        user_profile.id, 
                                        meal.meal_date,
                                        meal_type.meal_category,
                                        meal_food.meal_id, 
                                        food.ndbno, 
                                        food.food_name, 
                                        food.cal, food.carb, 
                                        food.fat,  food.protein, 
                                        food.serving_size, 
                                        meal_food.qty
                                    from food
                                        join meal_food on food.ndbno = meal_food.ndbno
                                        join meal on meal.meal_id = meal_food.meal_id
                                        join meal_type on meal.meal_type = meal_type.meal_id
                                        join user_profile on user_profile.id = meal.user_id
                                    where user_profile.id = @userID
                                    order by meal_date;";
                List<Meal> MealList = new List<Meal>();
                //initialize result. Here it can be a list of meals or just 1 meal
                //List<Meal> lstMeal = new List<Meal>();

                //Meal meal = new Meal();
                //List<FoodItem> foodsList = new List<FoodItem>();

                //iterate thru data to retrieve food list per meal
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    HashSet<int> Rows = new HashSet<int>();
                   
                    Meal meal = new Meal();
                    if (reader.Read())
                    {
                        Rows.Add(PullNonUniqueIdentity(reader).GetHashCode());
                        meal = MapRowtoMeal(reader);
                        meal.foods = new List<FoodItem>();
                        FoodItem foodItem = MapRowtoFood(reader);
                        meal.foods.Add(foodItem);
                    }

                    while (reader.Read())
                    {
                        //If I'm on my first meal or a different meal
                        //Then the hash isnt contained in my set
                        if (!Rows.Contains(PullNonUniqueIdentity(reader).GetHashCode()))
                        {
                            Rows.Add(PullNonUniqueIdentity(reader).GetHashCode());
                            MealList.Add(meal);
                            meal = MapRowtoMeal(reader);
                            meal.foods = new List<FoodItem>();
                            FoodItem foodItem = MapRowtoFood(reader);
                            meal.foods.Add(foodItem);
                        }
                        // Else the hash IS in my set, aka the Meal exists already
                        else
                        {
                            FoodItem foodItem = MapRowtoFood(reader);
                            meal.foods.Add(foodItem);
                        }

                    }
                    MealList.Add(meal);

                    //while (reader.Read())
                    //{
                    //    //Map row to a meal (map the date, category, userID)
                    //    meal = MapRowtoMeal(reader);


                    //    //Create a list of foods in the meal (is this getting overwritten every row?)
                    //    meal.foods = new List<FoodItem>();

                    //    FoodItem foodItem = new FoodItem();
                    //    foodItem = MapRowtoFood(reader);
                    //    //Here is where the problem is.. A new 'meal' is taking the date of the first meal of that meal-category

                    //    if (lstMeal.Where(x => x.meal_category.Equals(meal.meal_category)).Any())
                    //    {
                    //        Meal foundMeal = lstMeal.Where(x => x.meal_category.Equals(meal.meal_category)).FirstOrDefault();
                    //        foundMeal.foods.Add(foodItem);
                    //    }
                    //    else
                    //    {
                    //        meal.foods.Add(foodItem);
                    //        //add meal to meal list
                    //        lstMeal.Add(meal);
                    //    }

                    //}
                }

                return MealList;
      
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        private string PullNonUniqueIdentity(SqlDataReader reader)
        {
            string nonUniquIdentity = "";
            string id = Convert.ToString(reader["id"]);
            string meal_date = Convert.ToString(reader["meal_date"]);
            string meal_id = Convert.ToString(reader["meal_id"]);
            nonUniquIdentity = id + meal_date + meal_id;
            return nonUniquIdentity;
        }


        public UserProfileModel GetUserProfile(int id)
        {
            UserProfileModel userProfile = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Distinct * FROM user_profile WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        userProfile = MapRowToUserProfile(reader);
                    }
                }

                return userProfile;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private FoodItem MapRowtoFood(SqlDataReader reader)
        {
            return new FoodItem()
            {
                ndbno = Convert.ToString(reader["ndbno"]),
                name = Convert.ToString(reader["food_name"]),
                fat = Convert.ToDouble(reader["fat"]),
                pro = Convert.ToDouble(reader["protein"]),
                carb = Convert.ToDouble(reader["carb"]),
                cal = Convert.ToInt16(reader["cal"]),
                unit = Convert.ToString(reader["serving_size"]),
                qty = Convert.ToInt16(reader["qty"])
          
            };
        }
        private Meal MapRowtoMeal(SqlDataReader reader)
        {
            return new Meal()
            {
      
                date = Convert.ToDateTime(reader["meal_date"]),
                userID = Convert.ToInt16(reader["id"]),
                meal_category = Convert.ToString(reader["meal_category"]),

            };
        }



        private User MapRowToUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"])
            };
        }
        private UserProfileModel MapRowToUserProfile(SqlDataReader reader)
        {
            return new UserProfileModel()
            {
                name = Convert.ToString(reader["name"]),
                birthdate = Convert.ToDateTime(reader["birthdate"]),
                currWeight = Convert.ToInt16(reader["currWeight"]),
                goalWeight = Convert.ToInt16(reader["goalWeight"]),
                activityLevel = Convert.ToString(reader["activityLevel"]),
                height = Convert.ToInt16(reader["height"])
            };
        }
    }
}
