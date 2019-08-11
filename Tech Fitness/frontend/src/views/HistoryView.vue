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
      //not currently working. Need to read my array of meals from API into JS object.
      TFService.getMealbyUser().then((data) => {
          window.console.log(data);
            data.forEach((mealObj) => {
              console.log(mealObj) 
              console.log(mealObj.date) 
              let meal = 
                  { 
                  date: mealObj.date,
                  meal_category: mealObj.meal_category,
                  userID: mealObj.userID,
                  foods: [ mealObj.foods.forEach((food) => {
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
                                })
                        ], 
                  }    
            this.userMeals.push(meal);         
      })
    })
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
