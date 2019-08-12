<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">
        <button type="button" class="btn btn-primary btn-md" id="dashboard">Dashboard</button>
      </router-link>
      <router-link to="/EditProfile">
        <button type="button" class="btn btn-primary btn-md" id="profile">Profile</button>
      </router-link>
      <router-link to="/Login">
        <logout id="logout"></logout>
      </router-link> 
      <router-link to="/Search-Food">
            <button type="button" class="btn btn-primary" role="button">Add Food</button>
      </router-link> 
      <!-- Probably should move this link -->
      <router-link to="/History-View">
          <button type="button" class="btn btn-primary" role="button">History</button>
      </router-link> 
    </div>
    <router-view/>
  </div>
</template>

<script>
import Logout from '@/components/Logout';

export default {
  name: "app",
  components: {
    Logout
  },
  Data () {
    return {
      invalidCredentials: false
    }
  },
  methods: {
    logout() {
        auth.logout();
        this.$router.push('/login');     
    },
  },
}
</script>

<style>
#nav {
  display: inline-block;
  margin: .75em;
}
#nav > a, #logout {
  padding-right: .5em;
}
.btn-primary {
  color:white !important;
}

</style>
