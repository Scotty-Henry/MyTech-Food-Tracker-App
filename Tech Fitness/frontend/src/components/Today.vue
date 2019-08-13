<template>
    <div class="current-values">
        <div> Test a total calorie count! {{this.TotalCaloriesTest}}</div>
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
                TotalCaloriesTest: Number,
                },
            }
        },
        //This need to be on a computed:: currently not working to start getting metrics by 
        //day/week/month. For tomorrow
        beforeMount() {
            getCaloriesOnMeal()
            {
                let calories = 0;
                userMeals.forEach((meal) => {
                meal.foods.forEach((food) => {calories+=food.cal});
                this.data.TotalCaloriesTest = calories;
                });
             }
        },
        
    }
</script>

<style>

</style>
