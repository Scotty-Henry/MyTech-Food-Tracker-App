<template>
    <div>
        <!-- <router-link to="/Search-Food">
            <button type="button" class="btn btn-light" role="button">Add Food</button>
        </router-link> -->
        <div> My Meal: 
            <ul>
                <li v-for="food in foodArray" 
                v-bind:key="food.id">
                {{food.name}} 
            </li>
            </ul>      
        </div>
    </div>
</template>

<script>

export default {
    name: "meal",
    foodArray: [],
     props: {
         foodItem: Object
            },
  methods: {
  addFood() {}
    
  }
    };

</script>
   
<style>

</style>
