<template>
  <div id="history-container" class="container">   
    <div id="history-food" class="text-center">

      <history id="history" :userMeals="this.userMeals"></history>
      <!-- Need to make each item clickable?
      <div id="table" class="text-left">
          <b-table dark :items="food.results" :fields="fields" responsive="sm"></b-table>
      </div> -->
    </div>
</div>
  
</template>

<script>
import TFService from "@/TFService.js";
import History from '@/components/History';

export default {
  name: "HistoryView",
  components: {
    History,
  },
  data() {
    return {
            userMeals: [],
            }

  },
  methods: {
   
  },
  created()
    {
        TFService.getMealbyUser().then((data) => {
            window.console.log(data);
            let meal = 
                {
                date: data.date,
                mealID: data.mealID,
                meal_category: data.meal_category,
                userID: data.userID,
                foods: [], 
                }
          data.foods.forEach(food => {
            let foodItem = {
              ndbno: food.ndbno,
              name: food.name,
              cal: food.cal,
              carb: food.carb,
              fat: food.fat,
              pro: food.pro,
              qty: food.qty,
              unit: food.unit,
              }
              meal.foods.push(foodItem);
          });      
                this.userMeals.push(meal);
    });


    }
    
    
};
</script>

<style>
#history-food {
  color: whitesmoke !important;
}
#table {
  padding-top: 5%;
}

</style>
