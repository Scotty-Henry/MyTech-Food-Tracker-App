<template>
    <div>
        <div> My Meal: 
            <ul>
                <li v-for="food in foodArray" 
                v-bind:key="food.id">
                {{food.name}} 
            </li>
            </ul> 
            <button id="addMeal" class="btn btn-success btn-md" @click="submitMeal">Submit Meal</button>  
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
        body: JSON.stringify(this.foodArray),
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

</style>
