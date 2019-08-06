<template>
  <div id="CreateProfile">
    <form class="review-form" @submit.prevent="onSubmit">
 
        <input type="text" id="name" name="name" placeholder="name" v-model="user.name"/>  
  
        <input type="submit" value="Submit">    
    
    </form>
  </div>
</template>

<script>
// import TodoSearch from '@/components/TodoSearch';
// import TodoList from '@/components/TodoList';

export default {
  name: 'CreateProfile',
  components: {
  },
  data() {
    return {
      user: {
          name: '',

      }     
    
    }
  },
  methods: {
    
  }
}
</script>

<style>


</style>

