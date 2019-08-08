<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">
        <button type="button" class="btn btn-primary btn-md" id="dashboard">Dashboard</button>
      </router-link>
      <router-link to="/CreateProfile">
        <button type="button" class="btn btn-primary btn-md" id="profile">Profile</button>
      </router-link>
    </div>
    <router-view/>
  </div>
</template>

<style>
#nav {
  display: inline-block;
}
#nav > a {
  padding-right: .5em;
}
.btn-primary {
  color:white !important;
}
</style>
