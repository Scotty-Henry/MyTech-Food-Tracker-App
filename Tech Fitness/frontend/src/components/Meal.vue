<template>
    <div>
        <div> My Meal: 
            <ul>
                <li v-for="food in foodArray" 
                v-bind:key="food.id">
                {{food.name}} 
            </li>
            </ul> 

    <form class="form-signin form-group mt-1" @submit.prevent="submitMeal">
    
         <label id="mealactivity" for="activity" > Meal </label>
          <select id="activity" name="activity" class="selectpicker form-control" v-model="mealObj.meal_category">
              <option disabled value="">Select Meal</option>
              <option value="1">Breakfast</option>
              <option value="2">Lunch</option>
              <option value="3">Dinner</option>
              <option value="4">Snack - 1</option>
              <option value="5">Snack - 2</option>
            </select>
            <label id="date" for="date"> Date of Meal </label>
          <input type="date" id="date" name="date" class="form-control" placeholder="Date" v-model="mealObj.date"/>

        <b-button block type="submit" id="searchbutton" class="btn btn-success btn-md">Submit Meal</b-button>
    </form>


            <!-- <button id="addMeal" class="btn btn-success btn-md" @click="submitMeal">Submit Meal</button>   -->
        </div>
    </div>
</template>

<script>
import auth from '../auth';
import TFService from "@/TFService.js";

export default {
    name: "meal",
     props: {
         foodArray: Array 
          },
    data() {
      return {
          mealObj: {
              foods: this.foodArray,
              meal_category: '',
              date: '',
          }
        } 
    },
  methods: {
//        submitMeal() {
//            console.log(this.foodArray);
//       TFService.submitMeal(this.foodArray).then(response => {
//         console.log(response);
//       });

//   },
  submitMeal() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/addMeal`, {
        method: 'POST',
        headers: {
          Authorization: 'Bearer ' + auth.getToken(),
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.mealObj),
      })
        .then((response) => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .catch((err) => console.error(err));
    },
  
  
  
  
  
  }
  
    };

</script>
   
<style>
#date {
  margin-top: .5em;
}
</style>
