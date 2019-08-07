<template>
    <div class="profile">
        <router-link to="/CreateProfile">
        <b-img center img-top src="https://picsum.photos/125/125/?image=58" alt="Center image" id="image"></b-img>
        </router-link>
        <hr>
        <router-link to="/CreateProfile">
                <p id="username"> {{this.name}} </p>
            </router-link>
        <hr>
        <p>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et 
            dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip 
            ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore 
            eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia 
            deserunt mollit anim id est laborum.
        </p>
    </div>
</template>

<script>
export default {
name: 'profile',
  props: {
    name: String,
  }
  
}
</script>

<style>
#image {
    border-radius: 50%;
}
#username {
    text-decoration: none;
    color: black;
}
</style>

