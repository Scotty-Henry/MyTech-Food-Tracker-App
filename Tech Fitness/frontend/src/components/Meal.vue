<template>
  <div>
    <div>
      My Meal:
      <ul>
        <li v-for="food in foodArray" v-bind:key="food.id">{{food.name}}</li>
      </ul>

      <form class="form-signin form-group mt-5" @submit.prevent="submitMeal">
        <label id="mealactivity" for="activity">Meal</label>
        <select
          id="activity"
          name="activity"
          class="selectpicker form-control"
          v-model="mealObj.meal_category"
        >
          <option disabled value>Select Meal</option>
          <option value="1">Breakfast</option>
          <option value="2">Lunch</option>
          <option value="3">Dinner</option>
          <option value="4">Snack - 1</option>
          <option value="5">Snack - 2</option>
        </select>
        <label id="date" for="date">Date of Meal</label>
        <input
          type="date"
          id="date"
          name="date"
          class="form-control"
          placeholder="Date"
          v-model="mealObj.date"
        />

        <button type="submit" id="searchbutton" class="btn btn-success btn-md">Submit Meal</button>
      </form>

      <!-- <button id="addMeal" class="btn btn-success btn-md" @click="submitMeal">Submit Meal</button>   -->
    </div>
  </div>
</template>

<script>
import auth from "../auth";
import TFService from "@/TFService.js";

export default {
  name: "meal",

  data() {
    return {
      foodDict: {
         favItem: { mealKey: '', mObj: {}, count: 0}
      },
      mealObj: {
        foods: [],
        meal_category: "",
        date: ""
      },
      userMeals: []
    };
  },
  created() {
    this.getFavMeals();
  },
  methods: {
    //        submitMeal() {
    //            console.log(this.foodArray);
    //       TFService.submitMeal(this.foodArray).then(response => {
    //         console.log(response);
    //       });

    //   },
    getFavMeals() {
      let foodObj = {};
      TFService.getMealbyUser().then(data =>
        data.forEach(mealObj => {
          let meal = {
            date: TFService.stringtoDate("01-01-2000"),
            meal_category: mealObj.meal_category,
            userID: mealObj.userID,
            foods: [],
          }
          mealObj.foods.forEach(food => {
            let foodItem = {
              ndbno: food.ndbno,
              name: food.name,
              cal: food.cal,
              carb: food.carb,
              fat: food.fat,
              pro: food.pro,
              qty: food.qty,
              unit: food.unit
            };
            meal.foods.push(foodItem);
          });
          let key = '';
          meal.foods.sort((a, b) => (a.name > b.name) ? 1 : (a.name === b.name) ? ((a.ndbno > b.ndbno) ? 1 : -1) : -1 );
          meal.foods.forEach(food => {
            key += food.name;
          })
          if (key in foodObj){
            foodObj[key].count += 1;
          }
          else {
            foodObj[key] = { mObj: meal, count: 1 }
          }
          console.log(foodObj);
          //this.userMeals.push(meal);
        })
      );
      
      //             let meal =
      //                 {
      //                 date: TFService.stringtoDate(mealObj.date),
      //                 meal_category: mealObj.meal_category,
      //                 userID: mealObj.userID,
      //                 foods: [  ],
      //                 }
      //                 mealObj.foods.forEach((food) => {
      //                               let foodItem = {
      //                                 ndbno: food.ndbno,
      //                                 name: food.name,
      //                                 cal: food.cal,
      //                                 carb: food.carb,
      //                                 fat: food.fat,
      //                                 pro: food.pro,
      //                                 qty: food.qty,
      //                                 unit: food.unit,
      //                                 }
      //                                 meal.foods.push(foodItem);
      //                               });

      //           this.userMeals.push(meal);
      //           }
      // }
    },
    compareMeals(a, b) {
  // Use toUpperCase() to ignore character casing
  const firstMeal = a.name.toUpperCase();
  const secondMeal = b.name.toUpperCase();

  let comparison = 0;
  if (firstMeal > secondMeal) {
    comparison = 1;
  } else if (firstMeal < secondMeal) {
    comparison = -1;
  }
  return comparison;
},
    submitMeal() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/addMeal`, {
        method: "POST",
        headers: {
          Authorization: "Bearer " + auth.getToken(),
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.mealObj)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .catch(err => console.error(err));
    }
  }
};
</script>
   
<style>
#date {
  margin-top: 0.5em;
}
</style>
