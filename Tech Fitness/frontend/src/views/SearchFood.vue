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
    <b-table
      :items="food.results"
      :fields="fields"
      responsive="sm"
    ></b-table>

  </div>
</template>

<script>
import TFService from "@/TFService.js"

export default {
  name: "SearchFood",
  components: {},
  data() {
    return {
      food: {
        name: "",
        results: []
      },
      fields: ['report.food.name', 'report.food.nutrients[0].name'],
    };
  },
  methods: {
    handleSubmit() {
      TFService.getFoods(this.food.name).then(results => {
        this.results = results;
      });
    }
  }
};
</script>

<style>
</style>
