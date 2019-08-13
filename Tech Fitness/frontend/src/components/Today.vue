<template>
    <div class="current-values">
        <div> Calories Today! {{this.todayCals}} </div>
           
    </div>
</template>

<script>
export default {
    props: {
            userMeals: Array
        },
    data() {
        return {
            calorieCount: '',  
            allmeals: this.userMeals,
            today: '',

        }  
    },
        
        created() {
                console.log(this.allmeals); 
                var today = new Date();
                var dd = String(today.getDate()).padStart(2, '0');
                var mm = String(today.getMonth() + 1); //January is 0!
                var yyyy = today.getFullYear();
                today = mm + '/' + dd + '/' + yyyy;
                console.log(today);
                this.today = today;


        },
        methods: {
            getMealCals(meal){
                return meal.foods.reduce((acc, food) => acc+food.cal, 0)
            } 

        },
        computed: {
            todayMeals() {
                return this.allmeals.filter(meal => meal.date === '8/12/2019')
            },
            todayCals(){
                return this.todayMeals.reduce((acc, meal) => acc + this.getMealCals(meal), 0)
            },

    }
}

</script>

<style>

</style>
