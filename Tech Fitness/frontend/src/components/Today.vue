<template>
    <div class="current-values">
        <div> Calories Today: {{this.nutrientsToday.cal}} </div>
        <div> Carbs Today: {{this.nutrientsToday.carb}} </div>
        <div> Fat Today: {{this.nutrientsToday.carb}} </div>
        <div> Pro Today: {{this.nutrientsToday.pro}} </div>
           
    </div>
</template>

<script>
export default {
    props: {
            nutrientsToday: Object,
           
        },
    data() {
        return {  
            test: this.nutrientsToday
            // {
            //         cal: this.todayCals.cal,
            //         // pro: this.nutrientsToday.pro,
            //         // fat: this.nutrientsToday.carb,
            //         // carb: this.nutrientsToday.carb,  
            // }
        }  
    },
        
        created() {
                console.log(this.allmeals); 
                
        },
        
    
}

</script>

<style>

</style>
