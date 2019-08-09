<template>
    <div>
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
