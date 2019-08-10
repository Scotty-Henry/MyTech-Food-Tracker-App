<template>
    <div>
        <div> Givin it the ol' college try 
            <ul>
                <li v-for="meal in userMeals" 
                v-bind:key="meal.mealID">
                        {{meal.mealID}} 
                </li>
            </ul> 
        </div>
    </div>
</template>

<script>
import auth from '../auth';
import TFService from "@/TFService.js";
export default {
    name: "meal",
     props: {
         userMeals: Array
            },
    data() {
    return {
        }

    },
  methods: {
  }
  
    };

</script>
   
<style>

</style>
