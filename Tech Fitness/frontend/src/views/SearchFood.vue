<template>
  <div id="search-container" class="container">
    <div id="search-food" class="text-center">
      <form class="form-signin form-group mt-5" @submit.prevent="handleSubmit">
        <h1 class="h3 mb-3 font-weight-normal">Find a food!</h1>
        <br>
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
        <label for="name" class="sr-only" id="add-food">Add by ndbno</label>
        <input
          id="meal"
          type="text"
          class="form-control"
          placeholder="ndbno"
          v-model="foodItem.ndbno"
          autofocus
        />
        <button type="submit" id="foodbutton" class="btn btn-success btn-md">Add Food!</button>
      </form>
      <!-- Need to make each item clickable? -->
      <div id="table" class="text-left">
        <b-table dark :items="food.results" :fields="fields" responsive="sm"></b-table>
      </div>
    </div>
  </div>
</template>

<script>
import TFService from "@/TFService.js";

export default {
  name: "SearchFood",
  components: {},
  data() {
    return {
      foodItem:{
          ndbno: '',
          fat: '',
          pro: '',
          carb: '',
          cal: '',
      },     
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
    handleNDBNO() {
      TFService.getFood(this.foodItem.ndbno).then(response => {
        //let obj = response.find(o => o.name === 'Energy');
      
        console.log(response.report.food.nutrients);

        //console.log(obj);
      });
    }
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
