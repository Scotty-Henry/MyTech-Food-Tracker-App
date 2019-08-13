<template>
    <div class="current-values">
        <div> Test a total calorie count!</div>
            <ul>
                <li v-for="meal in userMeals" v-bind:key="meal.mealID">
                     {{meal.date + '---' + meal.meal_category}}        
                </li>
            </ul> 
    </div>
</template>

<script>
export default {
    props: {
            userMeals: Array
        },
    data() {
            return {
                form: {
                weight: '',
                },
                 calorieCount: ''
            }
        },
        //This need to be on a computed:: currently not working to start getting metrics by 
        //day/week/month. For tomorrow
        created() {
                let allmeals = this.userMeals;
                //console.log(allmeals);
  
                let calories = 0;

                allmeals.forEach((meal) => {
                meal.foods.forEach((food) => {calories+=food.cal});
                console.log(calories)
                })
                 this.calorieCount = calories;

        },
        
    }
</script>

<style>

</style>
