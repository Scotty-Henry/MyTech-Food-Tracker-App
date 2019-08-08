<template>
  <div id="search-food" class="text-center">
    <form class="form-signin form-group mt-5" @submit.prevent="handleSubmit">
      <h1 class="h3 mb-3 font-weight-normal">Find a food!</h1>
      <label for="name" class="sr-only">Food name</label>
      <input
        type="text"
        class="form-control"
        placeholder="Nom nom nom . . ."
        v-model="food.name"
        required
        autofocus
      />
      <button type="submit">Search</button>
    </form>
    <form class="form-signin form-group mt-5" @submit.prevent="handleNDBNO">
      <label for="name" class="sr-only">Add by ndbno</label>
      <input
        type="text"
        class="form-control"
        placeholder="ndbno"
        v-model="foodItem.ndbno"
        autofocus
      />
      <button type="submit">Add Food!</button>
    </form>
    <!-- Need to make each item clickable? -->
    <b-table dark :items="food.results" :fields="fields" responsive="sm"></b-table>
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
/* .table {
    color:whitesmoke !important;
} */
</style>
