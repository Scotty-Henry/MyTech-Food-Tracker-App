<template>
    <div>
        <div> me: Check this shit out. Also me: **throws cooked spagetti at wall**
            <ul>
                <li v-for="meal in userMeals" v-bind:key="meal.mealID">
                        <ul>
                            <li v-for="food in meal.foods" v-bind:key="food.ndbno">
                                {{meal.date + '---' + meal.meal_category + '---' + food.name}}    
                            </li>
                        </ul> 
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
