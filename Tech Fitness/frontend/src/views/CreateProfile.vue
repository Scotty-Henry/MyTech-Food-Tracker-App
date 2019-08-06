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
body {
  background: rgb(74,162,244);
  background: radial-gradient(circle, rgba(74,162,244,1) 0%, rgba(54,131,240,1) 100%);
}

#app {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-gap: 20px;
}

.search { 
  grid-column: 2 / 3;
  grid-row: 1;
}
.todo-list {
  grid-row: 2;
}
</style>

