
<template>
  <b-container id="search-container" class="container">   
    <b-row>
      <b-col>
        <div id="search-food" class="text-center">
          
          <div id="table" class="text-center">
            <b-table
            selectable
            select-mode="single"
            striped
            hover
            dark 
            :items="userMeals.date" 
            :fields="fields" 
            @row-selected="rowSelected"
            responsive="sm">
            </b-table>
         </div>
        </div>
      </b-col>
      <b-col id="mealcol">
        <div id="search-food" class="text-center justify-content-center align-items-center">
        <div>
            <b-card
              id="foodcard"
              tag="article"
              style="max-width: 30rem;"
              class="mb-2"
              bg-variant="dark" 
              header="Food Item Info:"
              text-variant="white"
            >
            </b-card>
        </div>
      </div>

       </b-col>
    </b-row>
</b-container>
  
</template>

<script>
import TFService from "@/TFService.js";
import Meal from '@/components/Meal';

export default {
  name: "SearchFood",
  components: {
    Meal,
  },
  data() {
    return {
      selected: '',  
      foodArray: [],
      food: {
        name: "",
        results: [], 
        userMeals: [],
      },
      fields: ["name"]
    };
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
#search-food {
  color: whitesmoke !important;
  margin-top: 7.5%;
  justify-content: center;
}
#table {
  margin-top: 3.5%;
  max-height: 60vh;
  overflow: auto;
}
#foodsearchform {
  display: inline;
}
#ndbnosearchform {
  display: inline;
}
#foodbutton {
  display: inline;
  margin-top: 2%;
}
#searchbutton {
  display: inline;
  margin-top: 2%;
}
::-webkit-scrollbar {
  display: none;
}
#foodcard {
  margin-top: 5%;
  justify-content: center;
}

</style>



