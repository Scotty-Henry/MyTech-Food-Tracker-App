<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">
        <button
          v-if="validateUser()"
          type="button"
          class="btn btn-primary btn-md"
          id="dashboard"
        >Dashboard</button>
      </router-link>
      <router-link v-if="validateUser()" to="/EditProfile">
        <button type="button" class="btn btn-primary btn-md" id="profile">Profile</button>
      </router-link>
<<<<<<< HEAD
=======
      <!-- <router-link v-if="validateUser()" to="/Login"> -->
        <!-- <logout id="logout"></logout> -->
      <!-- </router-link> -->
>>>>>>> 7605992ef429893582f8dc8ad8c4a94c5131f527
      <router-link v-if="validateUser()" to="/Search-Food">
        <button type="button" class="btn btn-primary" role="button">Add Food</button>
      </router-link>
      <!-- Probably should move this link -->
      <router-link v-if="validateUser()" to="/History-View">
        <button type="button" class="btn btn-primary" role="button">History</button>
      </router-link>
      <router-link v-if="validateUser()" to="/Login">
        <button type="button" class="btn btn-primary" role="button" @click="handleLogout">Logout</button>
      </router-link>
    </div>
    <router-view />
  </div>
</template>

<script>
import auth from "@/auth";

export default {
  name: "app",
  components: {
    // eslint-disable-next-line
    auth,
  },
  Data () {
    return {
      invalidCredentials: false
    }
  },
  methods: {
    handleLogout() {
      auth.logout();
    },
    validateUser() {
      return auth.getToken() === null ? false:true;
    }
  },
};
</script>

<style>
#nav {
  display: inline-block;
  margin: 0.75em;
}
#nav > a,
#logout {
  padding-right: 0.5em;
}
.btn-primary {
  color: white !important;
}
</style>
