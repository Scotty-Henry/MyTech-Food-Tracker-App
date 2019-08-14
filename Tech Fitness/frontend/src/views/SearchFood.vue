<template>
  <b-container id="search-container" class="container">   
    <div id="search-food" class="text-center">
      <b-col>
      <form class="form-signin form-group mt-5" @submit.prevent="handleSubmit">
        <h1 class="h3 mb-3 font-weight-normal">Find a food!</h1>
        <label for="name" class="sr-only" id="food-search">Food name</label>
        <input
          id="item"
          type="text"
          class="form-control"
          placeholder="Nom nom nom . . ."
          v-model="food.name"
          required
          autofocus
        />
        <button type="submit" id="searchbutton" class="btn btn-success btn-md">Search!</button>
      </form>
      <form class="form-signin form-group mt-5" @submit.prevent="handleNDBNO">
        <label for="meal-form-ndbno" class="sr-only" id="add-food">Add by ndbno</label>
        <input
          id="meal-form-ndbno"
          type="text"
          class="form-control"
          placeholder="ndbno"
          v-model="foodItem.ndbno"
          autofocus
        />
        <label for="meal-form-qty" class="sr-only" id="add-qty">Qty</label>
        <input
          id="meal-form-qty"
          type="text"
          class="form-control"
          placeholder="Qty."
          v-model="foodItem.qty"
          autofocus
        />
        <button type="submit" id="foodbutton" class="btn btn-success btn-md">Add Food!</button>
      </form>

      <div>Food:  {{this.foodItem.name}} </div>
      <div>My food's cals: {{this.foodItem.cal}} </div>
      <div>My food's pro: {{this.foodItem.pro}} </div>
      <div>My food's fat: {{this.foodItem.fat}} </div>
      <div>My food's carbs: {{this.foodItem.carb}} </div>

      <meal id="meal" :foodArray="this.foodArray"></meal>
      </b-col>
      <b-col>
      <div id="table" class="text-left">
          <b-table
           selectable
           select-mode="single"
           striped
           hover
           dark 
           :items="food.results" 
           :fields="fields" 
           @row-selected="rowSelected"
           responsive="sm">
           </b-table>
      </div>
      </b-col>
    </div>
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
      foodItem:{
          ndbno: '',
          name: '',
          fat: '',
          pro: '',
          carb: '',
          cal: '',
          unit: '', 
          qty: ''
      },  
      foodArray: [],
      food: {
        name: "",
        results: [], 
      },
      fields: ["name", "ndbno"]
    };
  },
  methods: {
    handleSubmit() {
      TFService.getFoods(this.food.name).then(response => {
        this.food.results = response.list.item;
        console.log(response.list.item);
      });
    },

    rowSelected(items) {
      this.selected = items;
      this.foodItem.ndbno = items.ndbno;
    },
    
    handleNDBNO() {
      TFService.getFood(this.foodItem.ndbno).then(response => {
          let currentFood = 
          {
          ndbno: this.foodItem.ndbno,
          cal: TFService.findNutrient('Energy', response.report.food.nutrients),
          pro: TFService.findNutrient('Protein', response.report.food.nutrients),
          fat: TFService.findNutrient('Total lipid (fat)', response.report.food.nutrients),
          carb: TFService.findNutrient('Carbohydrate, by difference', response.report.food.nutrients),
          name: response.report.food.name,
          unit: response.report.food.ru,
          qty: this.foodItem.qty
          }
          this.foodItem.name = currentFood.name;
          this.foodItem.fat = currentFood.fat;
          this.foodItem.pro = currentFood.pro;
          this.foodItem.carb = currentFood.carb;
          this.foodItem.cal = currentFood.cal;
          this.foodArray.push(currentFood);
      });
    },

  }, 
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
