<template>
  <div id="history-container" class="container">
    <div id="history-food" class="text-center">
      <b-table id="table" dark :items="allFood" responsive="sm"></b-table>
    </div>
  </div>
</template>

<script>
import TFService from "@/TFService.js";
import History from "@/components/History";

export default {
  name: "HistoryView",
  components: {
    History
  },
  data() {
    return {
      userMeals: [],
      fields: ["date", "meal_category", "foods"],
      allFood: []
    };
  },
  methods: {},
  created() {
    let foodItem = null;
    TFService.getMealbyUser().then(data => {
      data.forEach(mealObj => {
        let meal = {
          date: TFService.stringtoDate(mealObj.date),
          meal_category: mealObj.meal_category,
          userID: mealObj.userID,
          foods: []
        };
        mealObj.foods.forEach(food => {
          foodItem = {
            date: meal.date,
            category: meal.meal_category,
            name: food.name,
            ndbno: food.ndbno,
            cal: food.cal,
            carb: food.carb,
            fat: food.fat,
            pro: food.pro,
            qty: food.qty,
            unit: food.unit
          };
          meal.foods.push(foodItem);
        });

        this.userMeals.push(meal);
        this.allFood.push(foodItem);
      });
      console.log(this.userMeals);
    });
  }
};
</script>

<style>
#history-food {
  color: whitesmoke !important;
}
#history-container {
  margin-top: 5%;
  max-height: 90vh;
}
#table {
  padding-top: 5%;
  overflow: auto;
  max-height: 75vh;
}
::-webkit-scrollbar {
  display: none;
}
</style>
