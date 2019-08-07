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
  </div>
</template>

<script>
export default {
    components: {},
  data() {
    return {
      food: {
        name: '',
        results: [],
      }
    };
  },
  methods: {
    handleSubmit(){
        tf-service.getFoods(this.food.name)
        .then( (results) => {
            this.results = results;
        });
    }
  }
};
</script>

<style>

</style>
