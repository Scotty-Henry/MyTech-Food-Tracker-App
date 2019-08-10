<template>
  <div id="search-container" class="container">   
    <div id="search-food" class="text-center">

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
                foods: [
                    {
                    ndbno: data.foods.ndbno,
                    name: data.foods.name,
                    cal: data.foods.cal,
                    carb: data.foods.carb,
                    fat: data.foods.fat,
                    pro: data.foods.pro,
                    qty: data.foods.qty,
                    unit: data.foods.unit,
                    }
                ],
                }
                this.userMeals.push(meal);
    });


    }
    
    
};
</script>

<style>
#search-food {
  color: whitesmoke !important;
}
#table {
  padding-top: 5%;
}
#foodbutton {
  margin: .5em;
}
#searchbutton {
  margin: .5em;
}
/* .table {
    color:whitesmoke !important;
} */
</style>
