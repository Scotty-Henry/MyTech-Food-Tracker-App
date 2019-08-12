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
            data.forEach((mealObj) => { 
              let meal = 
                  { 
                  date: TFService.stringtoDate(mealObj.date),
                  meal_category: mealObj.meal_category,
                  userID: mealObj.userID,
                  foods: [  ], 
                  }  
                  mealObj.foods.forEach((food) => {
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
      })
       console.log(this.userMeals) 
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
