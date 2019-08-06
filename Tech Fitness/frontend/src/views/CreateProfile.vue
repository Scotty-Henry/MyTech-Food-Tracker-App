<template>
  <div id="CreateProfile">
    <form class="review-form" @submit.prevent="createprofile">
 
        <input type="text" id="name" name="name" placeholder="name" v-model="user.name"/>  
  
        <button type="submit">Create my profile</button>    
    
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
      createprofile() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/createprofile`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
            //here can i just push them to their dashboard? I'm only expecting a 200
        // .then((response) => {
        //   if (response.ok) {
        //     return response.text();
        //   } else {
        //     this.invalidCredentials = true;
        //   }
        // })
        // .then((token) => {
        //   if (token != undefined) {
        //     if (token.includes('"')) {
        //       token = token.replace(/"/g, '');
        //     }
        //     auth.saveToken(token);
        //     this.$router.push('/');
        //   }
        // })
        // .catch((err) => console.error(err));
    },
    
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

